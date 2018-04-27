using Microsoft.EntityFrameworkCore;  
  
namespace WebApp.Models  
{  
    public class EmployeeContext : DbContext  
    {  
        public EmployeeContext (DbContextOptions<EmployeeContext> options)  
            : base(options)  
        {  
        }  
  
        public DbSet<WebApp.Models.Employees> Employee { get; set; }  
    }  
}