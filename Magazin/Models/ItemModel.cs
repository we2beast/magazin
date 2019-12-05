using BusinessLayer.Domain;

namespace Magazin.Models
{ 
    public class ItemListModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
    }
}