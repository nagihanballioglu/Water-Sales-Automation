using SuSatisOtomasyonu.Entity;
using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.Helper
{
   static class HelperCustomer
    {
       
        static public Customers AddCustomers(Customers customer)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                customer.CreateDate = DateTime.Now;
                db.Customers.Add(customer);
               
                if (db.SaveChanges() > 0)
                {
                    return customer;
                }
                else
                    return customer;
            }
        }

        public static List<Customers> GetCustomers(string gc)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                return db.Customers
                    .Where(c => c.FirstName.Contains(gc)).OrderByDescending(c => c.CreateDate).ToList();
            }
        }
       

        public static Customers UpdateCustomers(Customers c)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                c.CreateDate = DateTime.Now;
                db.Entry(c).State = EntityState.Modified;
                db.Customers.Add(c);
                db.SaveChanges();
                return c;
            }   
        }

        static public bool DeleteCustomers(int ID)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                var customerdelete = db.Customers.Find(ID);
                db.Customers.Remove(customerdelete);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
       
        public static List<CustomerModel> CusstomerModelDon(List<Customers> customers)
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();

            foreach (var item in customers)
            {
                CustomerModel cm = new CustomerModel();
                {

                    cm.CustomerID = item.CustomerID;
                    cm.FirstName = item.FirstName;
                    cm.LastName = item.LastName;
                    cm.Phone = item.Phone;
                    cm.Address = item.Address;
                }

                customerModels.Add(cm);
            }

            return customerModels;
        }
    }
}
