using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedEfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var city = new Models.City
                {
                    Name = "S.Pererburg",
                    CountryId = 1
                };

                context.Cities.Add(city);
                context.SaveChanges();

                Console.WriteLine(city.Country.Name); 
            }
            Console.Read();
        }
    }
}
