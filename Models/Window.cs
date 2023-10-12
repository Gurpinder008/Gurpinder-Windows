using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gurpinder_Windows.Models
{
    public class WindowGenreViewModel
    {
        public List<Window> Windows { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}

namespace Gurpinder_Windows.Models
{
    public class Window
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Material { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Size { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }
    }
}
