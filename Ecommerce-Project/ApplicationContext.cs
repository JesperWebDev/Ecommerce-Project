using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
