//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vjezba.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prodavacs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodavacs()
        {
            this.Narudzbes = new HashSet<Narudzbes>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string DoB { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Narudzbes> Narudzbes { get; set; }
    }
}