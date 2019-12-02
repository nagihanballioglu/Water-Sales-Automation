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
    public partial class Form2 : Form
    {
        public Form2()
        {
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

            Helper.HelperCustomer.AddCustomers(newCustomer);
             
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
    }
}
