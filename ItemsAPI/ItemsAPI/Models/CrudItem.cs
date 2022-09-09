using System;

namespace ItemsAPI.Models
{
    public class CrudItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
    }
}
