using CRUD_Using_Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Using_Repository.Data
{
    public class ApplicationContext :DbContext
    {  
        //Creating DbContext Constructor 
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {

        }

        //registering User (model) and generating Users table in DbSet
        public DbSet<User>Users { get; set; }
    }
}
