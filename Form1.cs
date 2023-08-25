using System.Data.SqlClient;


namespace calenderApp
{
    public partial class Form1 : Form
    {
        Label namelabel1 = new Label();
        Label namelabel2 = new Label();
        Label namelabel3 = new Label();
        Label namelabel4 = new Label();
        Label namelabel5 = new Label();
        Label namelabel6 = new Label();
        Label namelabel7 = new Label();
        DbHelper dbHelper = new DbHelper();

        String selectQuery = "SELECT Status FROM dateSchedule Whe ;";
        String upDateQuery = "UPDATE ;";
        String insertQuery = "INSERT INTO ()VALUES();";

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbHelper.ExecuteNonQuery(selectQuery);

            tableLayoutPanel1.ColumnCount = 36;
            tableLayoutPanel1.RowCount = 30;


            namelabel1.Text = "‰ïŽÐ–¼1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 1);

            namelabel2.Text = "‰ïŽÐ–¼2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 2);

            namelabel3.Text = "‰ïŽÐ–¼3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 3);

            namelabel4.Text = "‰ïŽÐ–¼4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 4);

            namelabel5.Text = "‰ïŽÐ–¼5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 5);

            namelabel6.Text = "‰ïŽÐ–¼6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 6);

            namelabel7.Text = "‰ïŽÐ–¼7";
            namelabel7.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel7, 0, 7);


            DateTime currentDate = DateTime.Now;
            for (int i = 1; i < 32; i++)
            {
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(dateLabel, i, 0);
                currentDate = currentDate.AddDays(1);
            }
            for (int i = 1; i < 32; i++)
            {
                Button button = new Button();
                button.Text = "s" + i;
                button.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button, i, 1);

            }
            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "f" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 2);
            }

            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "g" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 3);
            }

            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "h" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 4);
            }

            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "j" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 5);
            }


            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "l" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 6);
            }

            for (int i = 1; i < 32; i++)
            {
                Button button2 = new Button();
                button2.Text = "a" + i;
                button2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button2, i, 7);
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}