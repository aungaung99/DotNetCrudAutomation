# Task:
Add a migration and update the database

# Commands:
- dotnet ef dbcontext scaffold --project .\QuickFood_MerchantPOS.Server "Server=.;Database=MerchantPOS;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --namespace QuickFood_MerchantPOS.Server.Entities --context-dir Data --context QuickFood_MerchantPOSDbContext --context-namespace QuickFood_MerchantPOS.Server.Data --data-annotations --no-onconfiguring -f 

# Notes:
- Run in Developer PowerShell