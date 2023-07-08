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
    public partial class FrmPayments : Form
    {
        public FrmPayments()
        {
            InitializeComponent();
        }
        public Customers Customers { get; set; }

        public Orders Orders { get; set; }
        public Payments Payments { get; set; }
        private void FrmPayments_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if(nmOdeme.Value==0)
            {
                errorProvider1.SetError(nmOdeme, "Lütfen geçerli bir fiyat giriniz");
                nmOdeme.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmOdeme, "");
            }
            Payments.order_id = txSiparişId.Text;
            Payments.payment_type = cbOdemeTuru.Text;
            Payments.payment_date = dtTarih.Text;

            DialogResult = DialogResult.OK;
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
