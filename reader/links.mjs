export const main = 'trureturing'
export const theories = 'trureturing-source-theories'
const organization = 'the-omega-institute'
const local = 'https://repository.invalid'

export const isManuscript = path => /^docs\/develop\/(?:archive\/)?theory\/.+\.md$/i.test(path)
export const isLibraryNote = path => /^Library\/.+\.md$/i.test(path)
export const validPath = path => typeof path === 'string' && !/[\\\u0000-\u001f]/.test(path) &&
  path.split('/').every(part => part && part !== '.' && part !== '..')
const encodePath = path => path.split('/').map(encodeURIComponent).join('/')

export function owner(path, sourceFiles, from = main) {
  if (isManuscript(path) || path.startsWith('Meta/Digestion/')) return theories
  if (path.startsWith('Library/')) return main
  if (from === theories && sourceFiles.has(path)) return theories
  return main
}

export function sourceUrl(repo, path, raw = false, directory = false) {
  const root = raw ? 'https://raw.githubusercontent.com' : 'https://github.com'
  const view = raw ? 'dev' : directory ? 'tree/dev' : 'blob/dev'
  return `${root}/${organization}/${repo}/${view}/${encodePath(path)}`
}

export function readerUrl(site, path, repo = owner(path, new Set())) {
  const url = new URL(site)
  url.search = ''
  url.hash = ''
  url.searchParams.set('path', path)
  if (repo !== owner(path, new Set())) url.searchParams.set('repo', repo)
  return url.href
}

// Resolve with repository-root semantics before choosing a destination repository.
export function resolveLink(href, current, site, sourceFiles, image = false) {
  if (href.startsWith('#') || !href) return href
  const url = new URL(href, local + '/' + encodePath(current.path))
  if (url.origin !== local) return href
  const path = decodeURIComponent(url.pathname.slice(1)).replace(/\/$/, '')
  if (!validPath(path)) return href
  const repo = owner(path, sourceFiles, current.repo)
  if (!image && /\.md$/i.test(path)) return readerUrl(site, path, repo) + url.hash
  return sourceUrl(repo, path, image, url.pathname.endsWith('/')) + url.search + url.hash
}
