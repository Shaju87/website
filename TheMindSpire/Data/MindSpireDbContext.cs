using Microsoft.EntityFrameworkCore;
using TheMindSpire.Models.ContactData;
using TheMindSpire.Models.EmpData;

namespace TheMindSpire.Data
{
    public class MindSpireDbContext : DbContext
    {
        public MindSpireDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MindSpireData> EmployeesData { get; set; }

        public DbSet<ContactUs> ContactUsData { get; set; }

    }
}
