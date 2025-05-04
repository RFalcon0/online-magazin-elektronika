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
    public partial class upravlenie_produkti : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""New Database"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private class ProductDisplayItem
        {
            public int ProductID { get; set; }
            public string DisplayName { get; set; }
            public override string ToString()
            {
                return DisplayName;
            }
        }

        public upravlenie_produkti()
        {
            InitializeComponent();
            UpdateProductList();

            this.FormClosing += (s, e) => Application.Exit();
        }

        private void UpdateProductList()
        {
            listBox1.DataSource = null;

            var products = new List<ProductDisplayItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT ProductID, ProductName FROM Products ORDER BY ProductName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new ProductDisplayItem
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    DisplayName = $"{reader["ProductName"]} (ID: {reader["ProductID"]})"
                                });
                            }
                        }

                        listBox1.DisplayMember = "DisplayName";
                        listBox1.ValueMember = "ProductID";
                        listBox1.DataSource = products;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading product list: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            listBox1.SelectedIndex = -1;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Product Name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            if (!decimal.TryParse(textBox3.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Category cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }
            if (!int.TryParse(textBox6.Text, out int stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative Stock Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Products (ProductName, Description, Price, StockQuantity, Category)
                               VALUES (@ProductName, @Description, @Price, @StockQuantity, @Category)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(textBox4.Text) ? (object)DBNull.Value : textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                    cmd.Parameters.AddWithValue("@Category", textBox5.Text.Trim());
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            UpdateProductList();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add product.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Database error: {sqlEx.Message}\nError Number: {sqlEx.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox1.Text, out int productID))
            {
                MessageBox.Show("Please enter a valid numeric Product ID to edit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Product Name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            if (!decimal.TryParse(textBox3.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Category cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }
            if (!int.TryParse(textBox6.Text, out int stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative Stock Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Products
                               SET ProductName = @ProductName,
                                   Description = @Description,
                                   Price = @Price,
                                   StockQuantity = @StockQuantity,
                                   Category = @Category
                               WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(textBox4.Text) ? (object)DBNull.Value : textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                    cmd.Parameters.AddWithValue("@Category", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateProductList();
                        }
                        else
                        {
                            MessageBox.Show($"No product found with ID {productID} to update.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Database error: {sqlEx.Message}\nError Number: {sqlEx.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ProductDisplayItem selectedProduct)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", selectedProduct.ProductID);
                        try
                        {
                            conn.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    textBox1.Text = reader["ProductID"].ToString();
                                    textBox2.Text = reader["ProductName"].ToString();
                                    textBox3.Text = Convert.ToDecimal(reader["Price"]).ToString("F2");
                                    textBox4.Text = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString();
                                    textBox5.Text = reader["Category"].ToString();
                                    textBox6.Text = reader["StockQuantity"].ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error retrieving product details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
    }
}
