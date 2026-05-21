# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
npm run dev          # start dev server (Vite)
npm run build        # type-check + build (vue-tsc && vite build)
npm run lint         # ESLint
npm run test:unit    # Vitest unit tests
npm run test:e2e     # Cypress e2e tests
```

When running locally, the app auto-detects `localhost`/`127.0.0.1` and switches Axios `baseURL` to `http://localhost:5209/` (the .NET API). In production it targets `https://farmerapi20250306133102-b8ejbnf8c4a0hve5.westus-01.azurewebsites.net`.

## Architecture

**Stack:** Vue 3 + TypeScript, Ionic Vue (UI), Vite, Capacitor (cross-platform), jeep-sqlite (web SQLite via WASM).

**Entry point — `src/main.ts`**  
Bootstraps Capacitor SQLite on `DOMContentLoaded` (creates a local `db_vite` database), then mounts the Vue app. The SQLite layer is web-only scaffolding; the real data comes from the REST API via Axios.

**Auth flow**  
- `sessionStorage` holds `AccessToken`, `Id`, `FirstName`, `LastName`, `Email`, `Role` after login.  
- `localStorage` holds `RefreshToken`; `main.ts` calls the refresh-token endpoint on load to restore the session.  
- The router guard in `src/router/index.ts` redirects unauthenticated users to `/Login` and non-Admin users away from `/AdminPage`.

**Routing — `src/router/index.ts`**  
Lazy-loads all pages. Default route redirects to `/SignUp`. The wildcard `/:id` route maps to `FolderPage`.

**Service layer — `src/scripts/`**  
- `PostService.ts` — `postSer` singleton: fetch all posts, create, delete. Exported `Post` interface lacks `postId`.  
- `UserPost.ts` — `usersPost` singleton: fetch posts by current user (`/api/posts/user/:id`), edit (PUT), create, delete. Exported `Post` interface includes `postId`. Also holds `convertExpireDate` logic (numeric days → ISO string).  
Both services share `getCropIcon()` for mapping cropType strings to icon assets in `src/images/icons/`.

**Global shell — `src/App.vue`**  
Renders the side menu and top toolbar. Menu items are role-gated at render time (Farmer/Admin see Home + Profile; Admin also sees Admin link). "Create Post" in the toolbar opens `CreatePost.vue` in a modal.

**Pages — `src/pages/`**  
Role-gated at the component level (`v-if="isAuthorized"`) in addition to the router guard. `AdminPage.vue` uses Chart.js + chartjs-plugin-datalabels to render user/post stats dashboards.

**Shared components — `src/components/`**  
`Board.vue` is the main post feed rendered on `/Home`. `CreatePost.vue` and `EditPost.vue` are modal forms that delegate to the service singletons.
