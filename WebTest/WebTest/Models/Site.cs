using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Site
    {
        public int SiteID { get; set; }
        public int CountryID { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public string Location { get; set; }
        public int Pistes { get; set; }
        public int Difficulty { get; set; }
        public double BeerPrice { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM d}", ApplyFormatInEditMode = true)]
        public DateTime SeasonStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM d}", ApplyFormatInEditMode = true)]
        public DateTime SeasonEnd { get; set; }
        public virtual Country CountryIn { get; set; }
    }
}
