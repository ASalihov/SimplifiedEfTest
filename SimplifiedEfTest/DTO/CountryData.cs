using SimplifiedEfTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedEfTest.DTO
{
    public class CountryData : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CityData> Cities { get; set; }
    }
}
