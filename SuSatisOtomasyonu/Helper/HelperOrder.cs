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
    static class HelperOrder
    {
        static public Orders AddOrders(Orders order)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
               order.CreateDate = DateTime.Now;
                db.Orders.Add(order);

                if (db.SaveChanges() > 0)
                {
                    return order;
                }
                else
                    return order;
            }
        }

        public static List<Orders> GetOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                List<Orders> orders = db.Orders.Include("Customers").
                    OrderByDescending(o => o.CreateDate).ToList();

                return orders;
            }
        }

        public static List<Orders> GetTodaysOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                DateTime today = DateTime.Now;

                List<Orders> orders = db.Orders.Include("Customers").
                    OrderByDescending(o => o.CreateDate).Where(o =>
                    (o.CreateDate.Year == today.Year &&
                        o.CreateDate.Month == today.Month &&
                        o.CreateDate.Day == today.Day)).ToList();

                return orders;
            }
        }

        static public bool DeleteOrders(int ID)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                var orderdelete = db.Orders.Find(ID);
                db.Orders.Remove(orderdelete);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool DeleteAllOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                List<Orders> orders = GetOrders();

                db.Orders.RemoveRange(db.Orders);
                db.SaveChanges();

                return true;
            }
        }

        public static Orders UpdateOrders(Orders o)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {

                o.CreateDate = DateTime.Now;
                db.Entry(o).State = EntityState.Modified;
                db.Orders.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public static bool UpdateOrder(int orderId, string orderStatus)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Orders order = db.Orders.Where(o => o.OrderID == orderId).FirstOrDefault();

                order.Status = orderStatus;
                order.CreateDate = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }

        public static List<OrderModel> OrderModelDon(List<Orders> orders)
        {
            List<OrderModel> ordersModel = new List<OrderModel>();

            foreach (var item in orders)
            {
                OrderModel om = new OrderModel();
                {
                    
                    om.OrderID = item.OrderID;
                    om.Customers.FirstName = item.Customers.FirstName;
                    om.Customers.LastName = item.Customers.LastName;
                   
                    om.Customers.Address = item.Customers.Address;
                    om.price = item.price;
                     om.Status = item.Status;
                  
                }

                ordersModel.Add(om);
            }

            return ordersModel;
        }
    }
    public enum OrderStatus
        {
            processing,
            transit,
            delivered
        }
    }

