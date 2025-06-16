namespace online_magazin_elektronika
{
    partial class plashtaniq
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvOrders = new DataGridView();
            label1 = new Label();
            txtOrderID = new TextBox();
            txtOriginal = new TextBox();
            label2 = new Label();
            label3 = new Label();
            nudDiscountPct = new NumericUpDown();
            label4 = new Label();
            txtDiscountAmt = new TextBox();
            txtAmountDue = new TextBox();
            label5 = new Label();
            btnApply = new Button();
            btnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscountPct).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(33, 26);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(271, 368);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(351, 26);
            label1.Name = "label1";
            label1.Size = new Size(93, 21);
            label1.TabIndex = 1;
            label1.Text = "Поръчка id:";
            // 
            // txtOrderID
            // 
            txtOrderID.Font = new Font("Segoe UI", 12F);
            txtOrderID.Location = new Point(346, 58);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(100, 29);
            txtOrderID.TabIndex = 2;
            // 
            // txtOriginal
            // 
            txtOriginal.Font = new Font("Segoe UI", 12F);
            txtOriginal.Location = new Point(562, 58);
            txtOriginal.Name = "txtOriginal";
            txtOriginal.ReadOnly = true;
            txtOriginal.Size = new Size(133, 29);
            txtOriginal.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(560, 26);
            label2.Name = "label2";
            label2.Size = new Size(138, 21);
            label2.TabIndex = 3;
            label2.Text = "Оригинална сума:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(346, 122);
            label3.Name = "label3";
            label3.Size = new Size(97, 21);
            label3.TabIndex = 5;
            label3.Text = "Отстъпка %:";
            // 
            // nudDiscountPct
            // 
            nudDiscountPct.Location = new Point(344, 145);
            nudDiscountPct.Name = "nudDiscountPct";
            nudDiscountPct.Size = new Size(120, 23);
            nudDiscountPct.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(565, 122);
            label4.Name = "label4";
            label4.Size = new Size(148, 21);
            label4.TabIndex = 7;
            label4.Text = "Отстъпка стойност:";
            // 
            // txtDiscountAmt
            // 
            txtDiscountAmt.Font = new Font("Segoe UI", 12F);
            txtDiscountAmt.Location = new Point(568, 145);
            txtDiscountAmt.Name = "txtDiscountAmt";
            txtDiscountAmt.ReadOnly = true;
            txtDiscountAmt.Size = new Size(138, 29);
            txtDiscountAmt.TabIndex = 8;
            // 
            // txtAmountDue
            // 
            txtAmountDue.Font = new Font("Segoe UI", 12F);
            txtAmountDue.Location = new Point(351, 227);
            txtAmountDue.Name = "txtAmountDue";
            txtAmountDue.ReadOnly = true;
            txtAmountDue.Size = new Size(100, 29);
            txtAmountDue.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(349, 200);
            label5.Name = "label5";
            label5.Size = new Size(97, 21);
            label5.TabIndex = 9;
            label5.Text = "За плащане:";
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI", 14.25F);
            btnApply.Location = new Point(344, 329);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(159, 65);
            btnApply.TabIndex = 11;
            btnApply.Text = "Постави отстъпка";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnPay
            // 
            btnPay.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.Location = new Point(536, 329);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(159, 65);
            btnPay.TabIndex = 12;
            btnPay.Text = "Плати и затвори";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // plashtaniq
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPay);
            Controls.Add(btnApply);
            Controls.Add(txtAmountDue);
            Controls.Add(label5);
            Controls.Add(txtDiscountAmt);
            Controls.Add(label4);
            Controls.Add(nudDiscountPct);
            Controls.Add(label3);
            Controls.Add(txtOriginal);
            Controls.Add(label2);
            Controls.Add(txtOrderID);
            Controls.Add(label1);
            Controls.Add(dgvOrders);
            Name = "plashtaniq";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "plashtaniq";
            Load += plashtaniq_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscountPct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private Label label1;
        private TextBox txtOrderID;
        private TextBox txtOriginal;
        private Label label2;
        private Label label3;
        private NumericUpDown nudDiscountPct;
        private Label label4;
        private TextBox txtDiscountAmt;
        private TextBox txtAmountDue;
        private Label label5;
        private Button btnApply;
        private Button btnPay;
    }
}