using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using hw1_ef_core.Services;

namespace hw1_ef_core
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            Service service = new Service(new AppDbContext(optionsBuilder.Options, config));
            service.CreateCategory(new Models.Category { Name = "Fitness", Description = "Physical activities, workouts" });
            foreach (var t in service.ReadCategory())
            {
                Console.WriteLine(t);
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(service.FindCategoryById(4));
            service.DeleteCategory(6);
            Console.WriteLine("-------------------------------------------------------");
            foreach (var t in service.ReadCategory())
            {
                Console.WriteLine(t);
                Console.WriteLine();
            }

        }
    }
}
