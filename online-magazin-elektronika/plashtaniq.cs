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
    public partial class plashtaniq : Form
    {
        private readonly string _conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""New Database"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public plashtaniq()
        {
            InitializeComponent();

            nudDiscountPct.Minimum = 0;
            nudDiscountPct.Maximum = 100;
            nudDiscountPct.DecimalPlaces = 2;
            nudDiscountPct.Increment = 0.25M;
        }

        private void plashtaniq_Load(object sender, EventArgs e)
        {
            // Load all orders (you could filter by CustomersID or date, etc.)
            using (var cn = new SqlConnection(_conn))
            using (var da = new SqlDataAdapter(@"
                SELECT 
                    OrderID,
                    CustomerID,
                    ProductsId,
                    OrderDate,
                    TotalAmount
                FROM dbo.Orders
            ", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                dgvOrders.DataSource = dt;
            }

            // Ensure columns show in a readable order/format:
            dgvOrders.Columns["OrderID"].HeaderText = "Order #";
            dgvOrders.Columns["CustomerID"].HeaderText = "Customer #";
            dgvOrders.Columns["ProductsId"].HeaderText = "Product #";
            dgvOrders.Columns["OrderDate"].HeaderText = "Date";
            dgvOrders.Columns["TotalAmount"].HeaderText = "Total";
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            txtOrderID.Text = dgvOrders.CurrentRow.Cells["OrderID"].Value.ToString();
            txtOriginal.Text = dgvOrders.CurrentRow.Cells["TotalAmount"].Value.ToString();

            // Reset discount fields
            nudDiscountPct.Value = 0;
            txtDiscountAmt.Clear();
            txtAmountDue.Clear();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtOriginal.Text, out var original)) return;

            var pct = nudDiscountPct.Value / 100m;
            var discount = Math.Round(original * pct, 2);
            var amountDue = Math.Round(original - discount, 2);

            txtDiscountAmt.Text = discount.ToString("F2");
            txtAmountDue.Text = amountDue.ToString("F2");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                MessageBox.Show("Please select an order first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtAmountDue.Text))
            {
                MessageBox.Show("Please click ‘Apply Discount’ to compute the final amount.", "No Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = int.Parse(txtOrderID.Text);
            decimal newTotal = decimal.Parse(txtAmountDue.Text);

            // UPDATE the TotalAmount in your Orders table
            using (var cn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(@"
                UPDATE dbo.Orders
                   SET TotalAmount = @newTotal
                 WHERE OrderID     = @oid;
            ", cn))
            {
                cmd.Parameters.AddWithValue("@newTotal", newTotal);
                cmd.Parameters.AddWithValue("@oid", orderId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Order total updated successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the grid so the new total appears
            plashtaniq_Load(this, EventArgs.Empty);
        }
    }
}
