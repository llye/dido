using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace databaseLayerProject.Models.Mock
{
    public class Prodavac
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Adress { get; set; }

        public string DoB { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Narudzbe> Narudzbe { get; set; }

        
    }
}