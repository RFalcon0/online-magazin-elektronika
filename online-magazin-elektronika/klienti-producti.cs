using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace online_magazin_elektronika
{
    public partial class klienti_producti : Form
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""New Database"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        // keep a local list of products so we can pull back the price later
        private List<Product> _products = new List<Product>();

        public klienti_producti()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }

        private void klienti_producti_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products.Clear();
            listBox1.Items.Clear();

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT ProductID, ProductName, StockQuantity, Price 
                FROM dbo.Products
            ", cn))
            {
                cn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var p = new Product
                        {
                            ProductID = rdr.GetInt32(rdr.GetOrdinal("ProductID")),
                            ProductName = rdr.GetString(rdr.GetOrdinal("ProductName")),
                            StockQuantity = rdr.GetInt32(rdr.GetOrdinal("StockQuantity")),
                            Price = rdr.GetDecimal(rdr.GetOrdinal("Price"))
                        };
                        _products.Add(p);
                        listBox1.Items.Add(p);
                    }
                }
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedItem is Product p))
            {
                MessageBox.Show("Моля изберете продукт от листа.");
                return;
            }

            string firstName = textBox4.Text.Trim();
            string lastName = textBox3.Text.Trim();
            string email = textBox6.Text.Trim();
            string phone = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Моля добавете име и фамилия.");
                return;
            }

            using (var cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        
                        int newCustomerId;
                        using (var cmdCust = new SqlCommand(@"
                    INSERT INTO dbo.Customers (FirstName, LastName, Email, Phone)
                    VALUES (@fn, @ln, @em, @ph);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ", cn, tran))
                        {
                            cmdCust.Parameters.AddWithValue("@fn", firstName);
                            cmdCust.Parameters.AddWithValue("@ln", lastName);
                            cmdCust.Parameters.AddWithValue("@em", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                            cmdCust.Parameters.AddWithValue("@ph", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);

                            newCustomerId = (int)cmdCust.ExecuteScalar();
                        }

                        
                        using (var cmdOrder = new SqlCommand(@"
                    INSERT INTO dbo.Orders (CustomerID, OrderDate, TotalAmount, ProductsId)
                    VALUES (@cid, @dt, @amt, @pid);
                ", cn, tran))
                        {
                            cmdOrder.Parameters.AddWithValue("@cid", newCustomerId);
                            cmdOrder.Parameters.AddWithValue("@dt", DateTime.Now);
                            cmdOrder.Parameters.AddWithValue("@amt", p.Price);
                            cmdOrder.Parameters.AddWithValue("@pid", p.ProductID);
                            cmdOrder.ExecuteNonQuery();
                        }

                        tran.Commit();
                        MessageBox.Show($"Поръчката е готова! CustomerID = {newCustomerId}");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Грешка при поръчка: " + ex.Message);
                    }
                }
            }

            // clear inputs
            textBox4.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox5.Clear();
        }


        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int StockQuantity { get; set; }
            public decimal Price { get; set; }

            // this is what appears in listBox1
            public override string ToString()
                => $"{ProductID} – {ProductName} (Количество: {StockQuantity}, Цена: {Price:C})";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Product p)
            {
                textBox1.Text = p.ProductID.ToString();
                textBox2.Text = p.ProductName;
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
