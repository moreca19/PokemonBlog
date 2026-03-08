# PokemonBlog

A monorepo containing a Pokemon blog platform with ASP.NET Core backend and React frontend.

## Project Structure

```
PokemonBlog/
├── backend/          # ASP.NET Core Web API
└── frontend/         # React application (coming soon)
```

## Backend

.NET 8.0 API with Entity Framework Core and PostgreSQL.

**Prerequisites:**
- .NET 8.0 SDK
- Docker Desktop

**Setup:**

1. Start the PostgreSQL database:
```bash
docker-compose up -d
```

2. Run the backend:
```bash
cd backend
dotnet run
```

3. View API documentation:
```
http://localhost:5150/swagger
```

**Database:**
- PostgreSQL running in Docker on port 5431
- Connection string in `appsettings.json`
- Database schema is created automatically on first run
- To stop the database: `docker-compose down`
- To remove all data: `docker-compose down -v`

**API Endpoints:**
- `/api/user` - User management
- `/api/post` - Blog posts
- `/api/comment` - Comments
- `/api/decklist` - Pokemon deck lists

## Frontend

Coming soon - React application for the Pokemon blog UI.

## Development

Run backend:
```bash
cd backend && dotnet run
```

Frontend will be added later.

## Tests

**Backend (xUnit):**
```bash
cd backend
dotnet test
```
Add tests in `backend/PokemonBlog.Tests/` as `*Tests.cs`. Mark methods with `[Fact]` (or `[Theory]` for parameterized tests). Use `Microsoft.EntityFrameworkCore.InMemory` for tests that need a database. [xUnit docs](https://xunit.net/docs/getting-started)

**Frontend (Jest):**
```bash
cd frontend
npm test
```
Add tests as `*.test.js` or `*.test.jsx` next to your components, or in a `__tests__` folder. Use `test()` or `it()` with React Testing Library (`render`, `screen`, `userEvent`). [Jest docs](https://jestjs.io/docs/getting-started) · [React Testing Library docs](https://testing-library.com/react)
