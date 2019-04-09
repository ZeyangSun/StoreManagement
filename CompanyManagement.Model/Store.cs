namespace CompanyManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [Required]
        [StringLength(512)]
        public string City { get; set; }

        [Required]
        [StringLength(16)]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(15)]
        public string Longitude { get; set; }

        [StringLength(15)]
        public string Latitude { get; set; }

        public virtual Company Company { get; set; }
    }
}
