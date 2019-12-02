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
    public partial class Form4 : Form
    {
       private readonly Customers customer;
        public Form4(Customers customer)
        {
            this.customer = customer;
            //textBox1.Text = customer.FirstName;
            //textBox2.Text = customer.LastName;
            //maskedTextBox1.Text = customer.Phone;
            //textBox4.Text = customer.Address;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Customers newCustomer = new Customers();
            {
                newCustomer.FirstName = textBox1.Text;
                newCustomer.LastName = textBox2.Text;
                newCustomer.Phone = maskedTextBox1.Text;
                newCustomer.Address = textBox4.Text;

            }
            Helper.HelperCustomer.UpdateCustomers(newCustomer);
            //Helper.HelperCustomer.AddCustomers(newCustomer);

            bool success = true;
            if (success)
            {
                MessageBox.Show("Kayıt Başarılı");
                this.Close();

            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!!!");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            textBox1.Text = customer.FirstName;
            textBox2.Text = customer.LastName;
            maskedTextBox1.Text = customer.Phone;
            textBox4.Text = customer.Address;
        }
    }
}
