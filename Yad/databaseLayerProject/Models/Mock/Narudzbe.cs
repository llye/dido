using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace databaseLayerProject.Models.Mock
{
    public class Narudzbe
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Kupac))]
        public int? KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }

        [ForeignKey(nameof(Car))]
        public int? CarId { get; set; }
        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Ducani))]
        public int? DucaniId { get; set; }
        public virtual Ducani Ducani { get; set; }

        [ForeignKey(nameof(Prodavac))]
        public int? ProdavacId { get; set; }
        public virtual Prodavac Prodavac { get; set; }

        public int cijena { get; set; }

        [NotMapped]
        public double profit { get; set; }

    }
}