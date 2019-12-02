using SuSatisOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuSatisOtomasyonu.BLL
{
    public partial class Form3 : Form
    {

        private readonly Customers customer;
       
        public Form3(Customers customer)
        {
            this.customer = customer;
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = customer.FirstName;
            textBox2.Text = customer.LastName;
            maskedTextBox1.Text = customer.Phone;
            textBox3.Text = customer.Address;
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            Orders order = new Orders();
            {
                order.price = textBox4.Text;
               // order.Status = Helper.HelperOrder.OrderStatus.processing.ToString();
                order.CustomerID = this.customer.CustomerID;

                Helper.HelperOrder.AddOrders(order);
                bool success = true;
                if (success)
                {
                    MessageBox.Show("Sipariş Kaydedildi");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız!!!");
                }
            }
        }

       
    }
}
