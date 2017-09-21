using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KraigsList.Data
{
    public partial class Ad
    {
        public Ad()
        {
            Images = new List<Image>();
        }

        public int AdId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Phone { get; set; }
        public DateTime Timestamp { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Email { get; set; }
        public string ActiveId { get; set; }
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public Category Category { get; set; }
        
        public ICollection<Image> Images { get; set; }
    }
}