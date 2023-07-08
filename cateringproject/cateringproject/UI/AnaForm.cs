using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cateringproject.UI;
using cateringproject.BL;
namespace cateringproject
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            DataSet ds = BLogic.MüşteriGetir(toolStripTextBox1.Text);
            if (ds != null)

                dataGridView1.DataSource = ds.Tables[0];
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnMüşteriEkle_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer()
            {
                Text = "Müşteri ekle",
                Customers = new Customers() { customer_id= Guid.NewGuid() },
            };
        tekrar:
            var sonuc = frmCustomer.ShowDialog();
            if(sonuc==DialogResult.OK)
            {
                bool b=BLogic.MüşteriEkle(frmCustomer.Customers);
                if (b)
                {
                    DataSet ds = BLogic.MüşteriGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }
        }

        private void btnMüşteriDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FrmCustomer frmCustomer = new FrmCustomer()
            {
                Text = "Müşteri Güncelle",
                Güncelleme=true,
                Customers = new Customers()
                {
                    customer_id = Guid.Parse(row.Cells[0].Value.ToString()),
                    first_name=row.Cells[1].Value.ToString(),
                    last_name = row.Cells[2].Value.ToString(),
                    email = row.Cells[3].Value.ToString(),
                    phone = row.Cells[4].Value.ToString(),
                    address = row.Cells[5].Value.ToString(),

                },
            };
            var sonuc = frmCustomer.ShowDialog();
            if(sonuc==DialogResult.OK)
            {
                bool b = BLogic.MüşteriGüncelle(frmCustomer.Customers);
                if (b)
                {
                    row.Cells[1].Value = frmCustomer.Customers.first_name;
                    row.Cells[2].Value = frmCustomer.Customers.last_name;
                    row.Cells[3].Value = frmCustomer.Customers.email;
                    row.Cells[4].Value = frmCustomer.Customers.phone;
                    row.Cells[5].Value = frmCustomer.Customers.address;

                }
            }
        }

        private void btnMüşteriBul_Click(object sender, EventArgs e)
        {

            DataSet ds = BLogic.MüşteriGetir(toolStripTextBox1.Text);
            if (ds != null)

                dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnMüşteriSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var customer_id = row.Cells[0].Value.ToString();

            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
           
            if(sonuc==DialogResult.OK)
            {
                bool b = BLogic.MüşteriSil(customer_id);
                if (b)
                {
                    DataSet ds = BLogic.MüşteriGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];

                }
            }
        }
    }
}
