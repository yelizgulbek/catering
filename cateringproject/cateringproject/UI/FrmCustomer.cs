using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cateringproject.UI
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public Customers Customers { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtAd)) return;
            if (!ErrorControl(txtSoyad)) return;
            if (!ErrorControl(txtmail)) return;
            if (!ErrorControl(txtTel)) return;
            if (!ErrorControl(txtAdr)) return;

            Customers.first_name = txtAd.Text;
            Customers.last_name = txtSoyad.Text;
            Customers.email = txtmail.Text;
            Customers.phone = txtTel.Text;
            Customers.address = txtAdr.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }

            }
            if (c is MaskedTextBox)
            { 
                if (!((MaskedTextBox)c).MaskFull)
                {
                    errorProvider1.SetError(c, "eksik veya hatalı");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            return true;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            txtID.Text = Customers.customer_id.ToString();
            if(Güncelleme)
            {
                txtAd.Text = Customers.first_name;
                txtSoyad.Text = Customers.last_name;
                txtmail.Text = Customers.email;
                txtTel.Text = Customers.phone;
                txtAdr.Text = Customers.address;

            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
