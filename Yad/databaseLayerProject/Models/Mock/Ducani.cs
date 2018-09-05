using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace databaseLayerProject.Models.Mock
{
    public class Ducani
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string Manager { get; set; }

        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Range(-180, 180)]
        public decimal Longitude { get; set; }

        public virtual ICollection<Narudzbe> Narudzbe { get; set; }
    }
}