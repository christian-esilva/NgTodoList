using NgTodoList.Data.Mappings;
using NgTodoList.Domain;
using System.Data.Entity;

namespace NgTodoList.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("NgTodoListConnectionString")
        {
            Database.SetInitializer(new DataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TodoMap());
        }
    }

    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var user = new User("Christian Silva", "christian.eds@hotmail.com", "123456");
            context.Users.Add(user);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
