using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace databaseLayerProject.Models.Mock
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Brand  { get; set; }

        [Required]
        public string Name { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        [Required]
        public string Description { get; set; }

        public List<string> Features { get; set; }

        public virtual ICollection<Narudzbe> Narudzbe { get; set; }
    }
}