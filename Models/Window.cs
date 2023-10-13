using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gurpinder_Windows.Models
{
    public class Window
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Style { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Material { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Size { get; set; }

        [Range(1, 1000)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Range(1, 5)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }
    }
}
