using SuSatisOtomasyonu.Entity;
using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuSatisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ListeleSipariş(Helper.HelperOrder.GetTodaysOrders());
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCustomers();
            ListOrders();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            BLL.Form2 ff = new BLL.Form2();
            ff.Show();


        }

        private void Button6_Click(object sender, EventArgs e)
        {

            var customer = new Customers();
            {
                customer.CustomerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                customer.FirstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                customer.LastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                customer.Phone = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                customer.Address = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            BLL.Form4 güncelleme = new BLL.Form4(customer);
            güncelleme.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var customer = new Customers();
            {
                //customer.CustomerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                //customer.FirstName = dataGridView1.CurrentRow.Cells["Müşteri Adı"].Value.ToString();
                //customer.LastName = dataGridView1.CurrentRow.Cells["Müşteri Soyadı"].Value.ToString();
                //customer.Address = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
                //customer.Phone = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();

            }

            BLL.Form3 siparis = new BLL.Form3(customer);
            siparis.Show();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());

            bool deleted = Helper.HelperOrder.DeleteOrders(orderID);


            if (deleted)
            {
                MessageBox.Show("Sipariş Silindi");
                 ListOrders();
            }
            else
            {
                MessageBox.Show("Sipariş Silinemedi");
                
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            bool success = Helper.HelperCustomer.DeleteCustomers(Convert.ToInt32(id));


            if (success)
            {
                 ListCustomers();
            }
        }

        private void ListeleSipariş(List<Orders> orderList)
        {
            List<OrderModel> orders = Helper.HelperOrder.OrderModelDon(orderList);

            if (orders.Count > 0)
            {
                dataGridView2.Rows.Clear();

                dataGridView2.ColumnCount = 7;
                dataGridView2.Columns[0].Name = "ID";
                dataGridView2.Columns[1].Name = "Ad";
                dataGridView2.Columns[2].Name = "Soyad";
                dataGridView2.Columns[3].Name = "Adres";
                dataGridView2.Columns[4].Name = "Tutar";
                dataGridView2.Columns[5].Name = "Durum";

                for (int i = 0; i < orders.Count; i++)
                {
                    i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = orders[i].OrderID;
                    dataGridView2.Rows[i].Cells[1].Value = orders[i].Customers.FirstName;
                    dataGridView2.Rows[i].Cells[2].Value = orders[i].Customers.LastName;
                    dataGridView2.Rows[i].Cells[3].Value = orders[i].Customers.Address;
                   dataGridView2.Rows[i].Cells[4].Value = orders[i].price;
                    dataGridView2.Rows[i].Cells[5].Value = orders[i].Status;

                switch (orders[i].Status)
                    {
                        case "processing":
                            dataGridView2.Rows[i].Cells[5].Value = "Sipariş Alındı";
                            break;
                        case "transit":
                            dataGridView2.Rows[i].Cells[5].Value = "Yola Çıktı";
                            break;
                        case "delivered":
                            dataGridView2.Rows[i].Cells[5].Value = "Teslim Edildi";
                            break;

                        default:
                            dataGridView2.Rows[i].Cells[5].Value = orders[i].Status;
                            break;
                    }
                }
            }
        }


        private void ListOrders()
        {
            List<Orders> orders = Helper.HelperOrder.GetOrders();
            ListeleSipariş(orders);
            
        }

        private void ListCustomers()
        {
            List<CustomerModel> customers = Helper.HelperCustomer.CusstomerModelDon(Helper.HelperCustomer.GetCustomers(textBox1.Text));


            if (customers.Count > 0)
            {
                dataGridView1.Rows.Clear();

                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Ad";
                dataGridView1.Columns[2].Name = "Soyad";
                dataGridView1.Columns[3].Name = "Telefon";
                dataGridView1.Columns[4].Name = "Adres";


                for (int i = 0; i < customers.Count; i++)
                {
                    i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = customers[i].CustomerID;
                    dataGridView1.Rows[i].Cells[1].Value = customers[i].FirstName;
                    dataGridView1.Rows[i].Cells[2].Value = customers[i].LastName;
                dataGridView1.Rows[i].Cells[3].Value = customers[i].Phone;
                    dataGridView1.Rows[i].Cells[4].Value = customers[i].Address;
                }
            }
        }

        private void UpdateOrderStatus(string orderStatus)
        {
            int orderID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());

            bool success = Helper.HelperOrder.UpdateOrder(orderID, orderStatus);
               

            if (success)
            {
                ListOrders();
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            ListCustomers();
            ListeleSipariş(Helper.HelperOrder.GetOrders());
          
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            string orderTransit = Helper.OrderStatus.transit.ToString();
            UpdateOrderStatus(orderTransit);

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            string orderDelivered = Helper.OrderStatus.delivered.ToString();
            UpdateOrderStatus(orderDelivered);

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //int orderID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());

            bool deleted = Helper.HelperOrder.DeleteAllOrders();


            if (deleted)
            {
                MessageBox.Show("Tüm Siparişler Silindi.","Başlık",MessageBoxButtons.OK, MessageBoxIcon.Information);
                 ListOrders();
            }
            else
            {
                MessageBox.Show("Lütfen tekrar deneyiniz.");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ListCustomers();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ListOrders();
        }
    }
}
