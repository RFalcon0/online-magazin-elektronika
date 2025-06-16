namespace online_magazin_elektronika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosing += (s, e) => Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            upravlenie_produkti upr = new upravlenie_produkti();
            upr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            klienti_producti kl = new klienti_producti();
            kl.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plashtaniq pl = new plashtaniq();
            pl.Show();
            this.Hide();
        }
    }
}
