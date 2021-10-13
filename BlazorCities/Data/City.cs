using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCities.Data
{
    public class City
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int? Population { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FoundationDate { get; set; }
    }
}
