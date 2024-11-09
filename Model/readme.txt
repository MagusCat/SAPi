### Used Commands

# Create Model
Scaffold-DbContext -Connection "Server=.\SQLEXPRESS2022;Database=SAPm;Trusted_Connection=True;"  -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Force -Context SapContext -DataAnnotations

# Optimize the mode [Be must run again if the model is modifed]
Optimize-DbContext -OutputDir Data/Instance -Context SAPiMeContext