using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SimplifiedEfTest.Models;
using SimplifiedEfTest.DTO;

namespace SimplifiedEfTest
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //  --- DTO TO ENTITY ---
                cfg.CreateMap<CountryData, Country>()
                    .ForMember(dest => dest.Cities, src => src.Ignore());
                  //.ForMember(dest => dest.Cities, src => src.MapFrom(x => x.Cities.Select(z => new City() { Id = z.Id, Population = z.Population, Name = z.Name }).ToArray()));
                cfg.CreateMap<CityData, City>();

                //  --- ENTITY TO DTO ---
                cfg.CreateMap<Country, CountryData>();
                cfg.CreateMap<City, CityData>();
            });
        }
    }
    public static class AutoMapperExtensions
    {
        // Entity to dto
        public static TDTO ToDTO<TDTO>(this object entity) where TDTO : IDTO
        {
            return Mapper.Map<TDTO>(entity);
        }

        // collections
        public static IEnumerable<TDTO> ToDtoList<TDTO>(this IEnumerable<object> objList) where TDTO : IDTO
        {
            return Mapper.Map<IEnumerable<object>, IEnumerable<TDTO>>(objList);
        }

        // DTO to Entity
        public static TEntity ToEntity<TEntity>(this IDTO dto) where TEntity : class
        {
            return Mapper.Map<TEntity>(dto);
        }

        // collections
        public static IEnumerable<TEntity> ToEntityList<TEntity>(this IEnumerable<IDTO> dtoList) where TEntity : class
        {
            return Mapper.Map<IEnumerable<IDTO>, IEnumerable<TEntity>>(dtoList);
        }
    }

    public interface IDTO
    {
    }
}