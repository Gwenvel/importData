using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KraigsList.Data
{
    public partial class Category
    {
        public Category()
        {
            Ads = new List<Ad>();
        }
        
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}
