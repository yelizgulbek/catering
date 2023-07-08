using cateringproject.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cateringproject.BL
{
    public static class BLogic
    {
        public static bool MüşteriEkle(Customers m)
        {
            try
            {
                int res = DataLayer.MüşteriEkle(m);
                return (res > 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata Oluştu : "  +ex.Message);
                return false;
            }
           
        }

        internal static DataSet MüşteriGetir(string filtre)
        {
            try
            {
                DataSet ds = DataLayer.MüşteriGetir(filtre);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu : " + ex.Message);
                return null;
            }
        }

        internal static bool MüşteriGüncelle(Customers m)
        {
            try
            {
                int res = DataLayer.MüşteriGüncelle(m);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu : " + ex.Message);
                return false;
            }
        }

        internal static bool MüşteriSil(string customer_id)
        {
            try
            {
                int res = DataLayer.MüşteriSil(customer_id);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu : " + ex.Message);
                return false;
            }
        }
    }
}
