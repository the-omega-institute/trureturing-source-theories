import MarkdownIt from 'markdown-it'
import texmath from 'markdown-it-texmath'
import katex from 'katex'
import DOMPurify from 'dompurify'
import GithubSlugger, { slug } from 'github-slugger'
import { main, theories, isManuscript, validPath, owner, readerUrl, sourceUrl, resolveLink } from './links.mjs'

const $ = id => document.getElementById(id)
const site = new URL('./', location.href)
const params = new URLSearchParams(location.search)

function catalogue(sourceFiles, library) {
  const collection = $('collection')
  const search = $('search')
  const groups = {
    theory: sourceFiles.filter(path => path.startsWith('docs/develop/theory/') && isManuscript(path)),
    archive: sourceFiles.filter(path => path.startsWith('docs/develop/archive/') && isManuscript(path)),
    library
  }
  if (Object.hasOwn(groups, params.get('collection'))) collection.value = params.get('collection')
  search.value = params.get('q') || ''
  function display() {
    const query = search.value.trim().toLowerCase()
    const paths = groups[collection.value].filter(path => path.toLowerCase().includes(query))
    const list = document.createDocumentFragment()
    for (const path of paths) {
      const item = document.createElement('li')
      const link = document.createElement('a')
      link.href = readerUrl(site, path)
      link.textContent = path.replace(/^docs\/develop\/(?:archive\/)?theory\/|^Library\//, '').replace(/\.md$/, '')
      item.append(link)
      list.append(item)
    }
    $('results').replaceChildren(list)
    $('count').textContent = `${paths.length.toLocaleString()} documents`
    const url = new URL(site)
    url.searchParams.set('collection', collection.value)
    if (query) url.searchParams.set('q', search.value)
    history.replaceState(null, '', url)
  }
  search.addEventListener('input', display)
  collection.addEventListener('change', display)
  display()
  $('catalogue').hidden = false
}

function formatMarkdown(source, current, sourceFiles) {
  const md = new MarkdownIt({ html: true }).use(texmath, { engine: katex, delimiters: ['dollars', 'brackets'] })
  // Leave TeX as text until its portion of a long volume approaches the viewport.
  for (const name of ['math_inline', 'math_inline_double', 'math_block', 'math_block_eqno']) {
    md.renderer.rules[name] = (tokens, index) => {
      const token = tokens[index]
      const display = name !== 'math_inline'
      const tag = display && token.block ? 'div' : 'span'
      const number = name === 'math_block_eqno' ? ' (' + md.utils.escapeHtml(token.info) + ')' : ''
      return `<${tag} class="${display ? 'display-math' : 'inline-math'}">${md.utils.escapeHtml(token.content)}</${tag}>${number}`
    }
  }
  const fragment = DOMPurify.sanitize(md.render(source), {
    RETURN_DOM_FRAGMENT: true, USE_PROFILES: { html: true }, FORBID_TAGS: ['form', 'style'],
    FORBID_ATTR: ['style', 'srcset']
  })
  const slugger = new GithubSlugger()
  for (const heading of fragment.querySelectorAll('h1,h2,h3,h4,h5,h6')) {
    const slug = slugger.slug(heading.textContent)
    if (!heading.id) heading.id = slug
  }
  for (const node of fragment.querySelectorAll('a[href], img[src]')) {
    const image = node.tagName === 'IMG'
    const attribute = image ? 'src' : 'href'
    try {
      node.setAttribute(attribute, resolveLink(node.getAttribute(attribute), current, site, sourceFiles, image))
    } catch {
      node.removeAttribute(attribute)
    }
  }
  return fragment
}

function displayMath(article) {
  const observer = new IntersectionObserver(entries => {
    for (const entry of entries) {
      if (!entry.isIntersecting) continue
      const element = entry.target
      observer.unobserve(element)
      katex.render(element.textContent, element, { output: 'mathml', trust: false,
        displayMode: element.classList.contains('display-math'), throwOnError: false })
    }
  }, { rootMargin: '400px' })
  for (const element of article.querySelectorAll('.display-math,.inline-math')) observer.observe(element)
}

function followFragment(article) {
  if (!location.hash) return
  const id = decodeURIComponent(location.hash.slice(1))
  const escaped = CSS.escape(id)
  let target = article.querySelector('#' + escaped + ',a[name="' + escaped + '"]')
  if (!target) {
    // Manuscript citations also use abbreviated headings and ordinary spaces for ideographic spaces.
    const matches = [...article.querySelectorAll('h1,h2,h3,h4,h5,h6')].filter(heading => {
      const normalized = slug(heading.textContent.replace(/\s+/gu, ' '))
      return normalized === id || normalized.startsWith(id + '-')
    })
    if (matches.length === 1) target = matches[0]
  }
  target?.scrollIntoView()
  return target
}

async function openDocument(path, sourceFiles) {
  if (!validPath(path) || !path.endsWith('.md')) throw new Error('Invalid Markdown path')
  const repo = params.get('repo') || owner(path, sourceFiles)
  if (![main, theories].includes(repo)) throw new Error('Unknown repository')
  const source = $('source')
  source.href = sourceUrl(repo, path)
  source.hidden = false
  const response = await fetch(sourceUrl(repo, path, true))
  if (!response.ok) throw new Error(`Could not load ${path} (HTTP ${response.status})`)
  const article = $('document')
  article.replaceChildren(formatMarkdown(await response.text(), { path, repo }, sourceFiles))
  article.hidden = false
  displayMath(article)
  document.title = (article.querySelector('h1')?.textContent || path) + ' · Trureturing'
  followFragment(article)
  window.addEventListener('hashchange', () => followFragment(article))
}

try {
  const response = await fetch('catalogue.json')
  if (!response.ok) throw new Error('Could not load the document catalogue')
  const { sourceFiles, library } = await response.json()
  if (params.has('path')) await openDocument(params.get('path'), new Set(sourceFiles))
  else catalogue(sourceFiles, library)
  $('status').hidden = true
} catch (error) {
  $('status').textContent = error.message
}
