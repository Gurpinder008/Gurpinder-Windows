using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gurpinder_Windows.Models
{
    public class WindowStyleViewModel
    {
        public List<Window> Windows { get; set; }
        public SelectList Styles { get; set; }
        public string WindowStyle { get; set; }
        public string SearchString { get; set; }
    }
}

