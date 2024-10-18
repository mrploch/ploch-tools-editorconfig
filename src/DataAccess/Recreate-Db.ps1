Remove-Item Migrations -Recurse -Force -Confirm:$false
dotnet ef database drop -f
dotnet ef migrations add InitialCreate
dotnet ef database update