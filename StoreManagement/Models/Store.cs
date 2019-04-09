namespace StoreManagement.Models
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
        
        [RegularExpression("^[a-zA-Z\u0080-\u024F]+(?:([\\ \\-\\']|(\\.\\ ))[a-zA-Z\u0080-\u024F]+)*$", ErrorMessage = "City is required and must be properly formatted.")]
        public string City { get; set; }

        [Required]
        [StringLength(16)]
        [RegularExpression("^((\\d{5}-\\d{4})|(\\d{5})|(\\d{4})|(\\d{6})|(\\d{3}\\s\\d{2})|(\\d{2}\\s\\d{3})|([A-Z]\\d[A-Z]\\s\\d[A-Z]\\d))$", ErrorMessage = "Zip code is required and must be properly formatted.")]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z\u0080-\u024F]+(?:([\\ \\-\\']|(\\.\\ ))[a-zA-Z\u0080-\u024F]+)*$", ErrorMessage = "Country is required and must be properly formatted.")]
        public string Country { get; set; }

        [StringLength(15)]
        public string Longitude { get; set; }

        [StringLength(15)]
        public string Latitude { get; set; }

        public virtual Company Company { get; set; }
    }
}
