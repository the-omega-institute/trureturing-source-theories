import { execFileSync } from 'node:child_process'
import { mkdir, copyFile, writeFile } from 'node:fs/promises'
import { build } from 'esbuild'
import { isLibraryNote, isManuscript } from './links.mjs'

const [mainTree, mainRevision = 'HEAD'] = process.argv.slice(2)
if (!mainTree) throw new Error('Usage: npm run build -- <main repository> [revision]')

function tree(repository, options, revision, paths = []) {
  const names = execFileSync('git', ['-C', repository, 'ls-tree', ...options, '--name-only', '-z',
    revision, '--', ...paths], { encoding: 'utf8' })
  return names.split('\0').filter(Boolean)
}

const roots = tree('..', [], 'HEAD').filter(name => name !== 'Meta')
const sourceFiles = tree('..', ['-r'], 'HEAD', roots)
const library = tree(mainTree, ['-r'], mainRevision, ['Library']).filter(isLibraryNote)
if (!library.length || !sourceFiles.some(isManuscript)) throw new Error('Empty reading catalogue')

await mkdir('dist', { recursive: true })
await Promise.all(['index.html', 'reader.css'].map(path => copyFile(path, 'dist/' + path)))
await writeFile('dist/catalogue.json', JSON.stringify({ sourceFiles, library }))
await build({ entryPoints: ['reader.mjs'], bundle: true, minify: true, outfile: 'dist/reader.js',
  platform: 'browser', format: 'esm', target: 'es2022', legalComments: 'linked' })
