import test from 'node:test'
import assert from 'node:assert/strict'
import { main, theories, resolveLink, validPath, readerUrl, sourceUrl } from './links.mjs'

const site = 'https://the-omega-institute.github.io/trureturing-source-theories/'
const input = { repo: theories, path: 'docs/develop/theory/ARITHMETIC_HOLOGRAPHIC_RT.md' }
const note = { repo: main, path: 'Library/QuantumBounds/codex2026finitertvariation.md' }
const files = new Set([input.path, note.path, 'README.md'])

test('cross-repository documents remain in the reader in both directions', () => {
  assert.equal(resolveLink('../../../' + note.path + '#result', input, site, files), readerUrl(site, note.path) + '#result')
  assert.equal(resolveLink('../../' + input.path + '#a', note, site, files), readerUrl(site, input.path) + '#a')
})
test('local fragments, images, escaped filenames, source code and external links', () => {
  assert.equal(resolveLink('#a', input, site, files), '#a')
  assert.equal(resolveLink('OTHER%20VOLUME.md#abc', input, site, files), readerUrl(site, 'docs/develop/theory/OTHER VOLUME.md') + '#abc')
  assert.equal(resolveLink('../../../README.md', input, site, files), readerUrl(site, 'README.md', theories))
  assert.equal(resolveLink('../../../D5/Some.lean#L3', input, site, files), sourceUrl(main,'D5/Some.lean') + '#L3')
  assert.equal(resolveLink('https://example.org/paper', note, site, files), 'https://example.org/paper')
  const media = 'docs/develop/theory/figure.png'
  assert.equal(resolveLink('figure.png', input, site, new Set([media]), true), sourceUrl(theories, media, true))
  assert.equal(validPath('../other.md'), false)
})
