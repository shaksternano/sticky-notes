# Sticky Notes

An ASP.NET Core 10 API with a Solid.js, TypeScript, pnpm, and Tailwind frontend.

## Structure

- `src/StickyNotes.Api` — .NET 10 Web API backend
- `src/WebApp` — Solid.js frontend managed with pnpm

## Development

Start the API and frontend in separate terminals:

```bash
dotnet run --project src/StickyNotes.Api
cd src/WebApp
pnpm install
pnpm dev
```

The Vite development server runs at `http://localhost:5173` and proxies `/api` requests to the API.

## Production

```bash
dotnet build src/StickyNotes.Api -c Release
dotnet run --project src/StickyNotes.Api -c Release
```

The Release build runs `pnpm install --frozen-lockfile`, builds the frontend into `wwwroot`, and the API serves the resulting SPA.
