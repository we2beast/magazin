using System;
using System.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
