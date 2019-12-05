using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Domain;

namespace Magazin.Models
{
    public class CartLine
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Summ { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public decimal Total;

        public Cart()
        {
            Total = ComputeTotalValue();
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => (decimal)e.Item.Price * e.Quantity);
        }

        public void AddItem(Item item, int quantity)
        {
            CartLine line = lineCollection.Where(g => g.Item.Code == item.Code).FirstOrDefault();

            if (line == null)
            {
                CartLine linecol = new CartLine();
                linecol.Item = item;
                linecol.Quantity = quantity;
                linecol.Summ = (decimal)item.Price;
                lineCollection.Add(linecol);
            }
            else
            {
                line.Quantity += quantity;
                line.Summ = line.Quantity * (decimal)line.Item.Price;
            }
        }

        public void RemoveLine(Item item)
        {
            lineCollection.RemoveAll(l => l.Item.Code == item.Code);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
