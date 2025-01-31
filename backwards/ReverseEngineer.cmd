dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer


dotnet ef dbcontext scaffold "Server=localhost;Database=PotLuck; User Id=sa; Password=password0!;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YourDbContext -f
dotnet ef dbcontext scaffold "Server=localhost;Database=PotLuck; User Id=sa; Password=password0!; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YourDbContext -f

"Default": "Server=localhost; Database=<insert db name>; User Id=sa; Password=your_password123"