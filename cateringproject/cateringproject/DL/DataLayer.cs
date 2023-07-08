using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace cateringproject.DL
{
    public static class DataLayer
    {
        static MySqlConnection conn = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "yeliz_gülbek",
                UserID = "root",
                Password = "",

                AllowUserVariables = true,
                UseCompression = true,
            }.ConnectionString
            );

        public static int MüşteriEkle(Customers m)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("AddCustomer", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@customer_id",m.customer_id );
                komut.Parameters.AddWithValue("@first_name", m.first_name);
                komut.Parameters.AddWithValue("@last_name", m.last_name);
                komut.Parameters.AddWithValue("@email", m.email);
                komut.Parameters.AddWithValue("@phone", m.phone);
                komut.Parameters.AddWithValue("@address", m.address);

                int res = komut.ExecuteNonQuery();
                return res;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int MüşteriSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("AddCustomerSil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id",id);
                
                int res = komut.ExecuteNonQuery();
                return res;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int MüşteriGüncelle(Customers m)
        {   
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("AddCustomerGuncelle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@customer_id", m.customer_id);
                komut.Parameters.AddWithValue("@first_name", m.first_name);
                komut.Parameters.AddWithValue("@last_name", m.last_name);
                komut.Parameters.AddWithValue("@email", m.email);
                komut.Parameters.AddWithValue("@phone", m.phone);
                komut.Parameters.AddWithValue("@address", m.address);

                int res = komut.ExecuteNonQuery();
                return res;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet MüşteriGetir(string filtre)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut;
                if (string.IsNullOrEmpty(filtre))
                {

                    komut = new MySqlCommand("AddCustomerHepsi", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    
                }
                else
                {
                    komut = new MySqlCommand("AddCustomerBul", conn);

                    komut.Parameters.AddWithValue("@filtre",filtre);
                  
                }
                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);
                return dataSet;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
