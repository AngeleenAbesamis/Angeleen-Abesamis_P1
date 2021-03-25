using System.Collections.Generic;

namespace BeautyStoreMVC.Models
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public List<ShowProductViewModel> products { get; set; }
    }
}
