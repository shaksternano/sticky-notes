import { defineConfig } from 'vite';
import solid from 'vite-plugin-solid';
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
    plugins: [solid(), tailwindcss()],
    build: { outDir: '../StickyNotes.API/wwwroot', emptyOutDir: true },
    server: {
        port: 5173,
        proxy: { '/api': 'http://localhost:5254' },
    },
});
