using System;
using System.Collections.Generic;
using System.Text;

namespace WebSpider.Insfrastracture
{
    public class StorageOptions
    {
        public StorageType StorageType { get; set; }
        public string ConnectionString { get; set; }
        public string FilingSavepath { get; set; }
    }
}
