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
