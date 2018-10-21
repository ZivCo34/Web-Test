using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}
