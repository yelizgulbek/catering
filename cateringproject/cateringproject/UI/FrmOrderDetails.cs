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
    public partial class FrmOrderDetails : Form
    {
        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        public Customers Customers { get; set; }
        public Menus Menus { get; set; }

        public Order_details Order_Details { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtMenuId)) return;
            if (!ErrorControl(txtMiktar)) return;
            if (!ErrorControl(txtSiparis)) return;

            Order_Details.order_id = txtSiparis.Text;
            Order_Details.menu_id = txtMenuId.Text;
            Order_Details.quantity = txtMiktar.Text;
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

        private void FrmOrderDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
