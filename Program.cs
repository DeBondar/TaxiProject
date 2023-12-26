using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaxiProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                //Додавання даних
                context.drivers.Add(new models.Driver() { Name = "Den Fory"});
                context.SaveChanges();

                //Редагування даних                
                var driver = context.drivers.Where(a => a.LicenseNumber == 6).First();
                driver.Name = "Alex Koll";
                context.SaveChanges();

                //Видалення даних
                context.drivers.Remove(context.drivers.Where(a => a.LicenseNumber == 5).First());
                context.SaveChanges();
            }
        }
    }
}