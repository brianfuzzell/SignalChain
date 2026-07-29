# Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18+)
- [PostgreSQL](https://www.postgresql.org/download/)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

### Server Setup
1. Clone the repo and open a terminal in the project root.
2. Restore .NET dependencies: `dotnet restore`
3. Set your database connection string using .NET user secrets (keeps it out of source control):
    ```
    dotnet user-secrets set "SignalChainDbConnectionString" "Host=localhost;Database=SignalChain;Username=<your-postgres-user>;Password=<your-postgres-password>"
    ```
4. Set an admin password secret. This is used to hash the password for the seeded accounts (`Administrator`, `ajohnson`, `rjohnson`) — the app will not start without it: `dotnet user-secrets set "AdminPassword" "<choose-a-password>"`
5. Apply migrations to create the database schema and seed data: `dotnet ef database update`
6. Run the API: `dotnet run`

The API will run at `https://localhost:5001` (matches the proxy target the client expects).

### Client Setup
1. In a separate terminal, navigate to the `client` folder: `cd client`
2. Install dependencies: `npm install`
3. Start the dev server: `npm run dev`

Vite will open the app in your browser and proxy `/api` requests to the running .NET API.

### Logging In
Three seeded user accounts are available after running migrations, all using the password you set as `AdminPassword` above:
- `Administrator` (Admin role)
- `ajohnson`
- `rjohnson`

### Running Tests
- Client: `cd client && npm test`
