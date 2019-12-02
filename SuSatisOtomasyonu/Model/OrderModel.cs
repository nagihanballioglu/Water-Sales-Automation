using SuSatisOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.Model
{
    class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }
        public string price { get; set; }
       
       // public Customers Customer { get; set; }
        public CustomerModel Customers = new CustomerModel();
    }
}
