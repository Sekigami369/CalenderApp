namespace calenderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnCount = 36;

            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            for (int i = 1; i < 32; i++)
            {
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Font = new Font(dateLabel.Font.FontFamily, 9);
                dateLabel.Dock = DockStyle.Fill;

                Label dataLabel = new Label();
                dataLabel.Text = "Žõ";
                dataLabel.ForeColor = Color.Red;
                dataLabel.Dock = DockStyle.Fill;

                tableLayoutPanel1.Controls.Add(dateLabel, i, 0);
                tableLayoutPanel1.Controls.Add(dataLabel, i, 0);
                currentDate = currentDate.AddDays(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}