using SimplifiedEfTest.DTO;
using SimplifiedEfTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedEfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfiguration.Configure();
            using (var context = new Context())
            {
                var countryDTO = context.Countries.FirstOrDefault(x => x.Id == 1).ToDTO<CountryData>();
                countryDTO.Cities.Add(new CityData { CountryId = countryDTO.Id, Name = "new city", Population = 100000 });
                countryDTO.Cities.FirstOrDefault(x => x.Id == 4).Name = "another name";

                //var countryEntity = countryDTO.ToEntity<Country>();

                var newCities = AutoMapper.Mapper.Map<IEnumerable<City>>(countryDTO.Cities);

                var country = context.Countries.FirstOrDefault(x => x.Id == 1);
                //AutoMapper.Mapper.Map(countryDTO.Cities, country.Cities);

                foreach (var cityDTO in countryDTO.Cities)
                {
                    if (cityDTO.Id == 0)
                    {
                        country.Cities.Add(cityDTO.ToEntity<City>());
                    }
                    else
                    {
                        AutoMapper.Mapper.Map(cityDTO, country.Cities.SingleOrDefault(c => c.Id == cityDTO.Id)); 
                    }
                }

                AutoMapper.Mapper.Map(countryDTO, country);

                context.SaveChanges();

                Console.WriteLine("");
            }
            Console.Read();
        }
    }
}
