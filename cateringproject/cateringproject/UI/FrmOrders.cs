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
    public partial class FrmOrders : Form
    {
        public FrmOrders()
        {
            InitializeComponent();
        }
        public Customers Customers { get; set; }
        public Orders Orders { get; set; }
        public Menus Menus { get; set; }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Orders.customer_id = txtMusteriId.Text;
            Orders.event_date = txtTeslimat.Text;
            Orders.order_date = dtSipariş.Text;
            Orders.event_type = txtSiparişTür.Text;
            Orders.guest_count = nmSayı.ToString();
            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        

        private void FrmOrders_Load(object sender, EventArgs e)
        {
            txtMusteriId.Text = Customers.ToString();
            
        }
    }
}
