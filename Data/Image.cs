using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KraigsList.Data
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string URL { get; set; }
        public bool IsPrimary { get; set; }
        public int AdId { get; set; }
        
        [JsonIgnore]
        public Ad Ad { get; set; }
    }
}