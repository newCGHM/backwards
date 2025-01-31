dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef dbcontext scaffold "Server=localhost;Database=PotLuck; User Id=sa; Password=password0!; Encrypt=False; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YourDbContext -f

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


"ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
}

dotnet ef migrations add InitialCreate
dotnet ef database update