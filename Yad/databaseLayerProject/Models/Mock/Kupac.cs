using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace databaseLayerProject.Models.Mock
{
    public class Kupac
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Narudzbe> Narudzbe { get; set; }

    }
}
