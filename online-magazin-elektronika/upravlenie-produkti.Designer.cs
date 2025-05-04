namespace online_magazin_elektronika
{
    partial class upravlenie_produkti
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            listBox1 = new ListBox();
            buttonBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(337, 40);
            label1.Name = "label1";
            label1.Size = new Size(430, 30);
            label1.TabIndex = 1;
            label1.Text = "Добавяне или редактиране на продукти";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(337, 123);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(591, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(133, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(629, 226);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(95, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(337, 226);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(286, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(591, 321);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(133, 27);
            textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(337, 321);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(133, 27);
            textBox6.TabIndex = 6;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(338, 378);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(132, 48);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Добави";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 12F);
            buttonEdit.Location = new Point(580, 378);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(158, 48);
            buttonEdit.TabIndex = 9;
            buttonEdit.Text = "Редактирай (по id)";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(358, 92);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 10;
            label2.Text = "Продукт id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(365, 199);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 11;
            label3.Text = "Описание";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(612, 92);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 12;
            label4.Text = "Продукт име";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(639, 199);
            label5.Name = "label5";
            label5.Size = new Size(47, 21);
            label5.TabIndex = 13;
            label5.Text = "Цена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(353, 291);
            label6.Name = "label6";
            label6.Size = new Size(93, 21);
            label6.TabIndex = 14;
            label6.Text = "Количество";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(612, 291);
            label7.Name = "label7";
            label7.Size = new Size(83, 21);
            label7.TabIndex = 15;
            label7.Text = "Категория";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(45, 40);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(251, 379);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBack.Location = new Point(741, 7);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(48, 38);
            buttonBack.TabIndex = 17;
            buttonBack.Text = "->";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // upravlenie_produkti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBack);
            Controls.Add(listBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "upravlenie_produkti";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "upravlenie_produkti";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button buttonAdd;
        private Button buttonEdit;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListBox listBox1;
        private Button buttonBack;
    }
}