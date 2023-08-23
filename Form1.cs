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
            /*
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.ColumnCount = 36;

            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            for (int i = 1; i < 32; i++)
            {
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Font = new Font(dateLabel.Font.FontFamily, 9);
                dateLabel.Dock = DockStyle.Fill;



                tableLayoutPanel1.Controls.Add(dateLabel, i, 0);

                currentDate = currentDate.AddDays(1);
            }
            
            Label dataLabel = new Label();
            dataLabel.Text = "ŠÖ";
            dataLabel.ForeColor = Color.Red;
            dataLabel.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(dataLabel, 1, 0);
            */
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.ColumnCount = 31;
            /*
            for (int i = 0; i < 4; i++)
            {
                Button button = new Button();
                button.Text = "Row" + (i + 1);
                button.Dock = DockStyle.Fill;

                tableLayoutPanel1.Controls.Add(button, 0, i);
                
            }
            */
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < 31; i++)
            {
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(dateLabel, i, 0);
                currentDate = currentDate.AddDays(1);
            }


            Button button2 = new Button();
            button2.Text = "sub";
            tableLayoutPanel1.Controls.Add(button2, 0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}