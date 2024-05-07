using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Goods
    {
        public int GoodsId { get; set; }

        public string Name { get; set;}

        public string Intenational { get; set;}

        public string DataBegin { get; set; }

        public string DataEnd { get; set; }

        public bool Availability { get; set; }

        public string RF { get; set; }

        public string Producer { get; set; }

        public int ProducerId { get; set; }


        public string Batch { get; set; }

        public float Price { get; set; }

        public int Total { get; set; }
    }
}
