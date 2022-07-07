using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Dtos
{
    public class ProductDto //Dto -> Data Transfer Objects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CartegoryId { get; set; }
        public string CartegoryName { get; set; }
    }
}
