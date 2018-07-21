using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CityCountryApp.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }  
         [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}