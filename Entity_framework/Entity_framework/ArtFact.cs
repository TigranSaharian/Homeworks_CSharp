//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity_framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArtFact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArtFact()
        {
            this.ArtFactInfoIds = new HashSet<ArtFactInfoId>();
        }
    
        public int ArtFactId { get; set; }
        public string Name { get; set; }
        public int Material { get; set; }
        public int Category { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public int Price { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreationPlace { get; set; }
        public byte[] DrawingImage { get; set; }
    
        public virtual CategoryInfo CategoryInfo { get; set; }
        public virtual MaterialInfo MaterialInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtFactInfoId> ArtFactInfoIds { get; set; }
    }
}