using System.Data.SqlClient;

namespace calenderApp
{
    public partial class Form1 : Form
    {
        DateTime currentDate = DateTime.Now.Date;
        int[,] dataGrid;
        private string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        Label namelabel1 = new Label();
        Label namelabel2 = new Label();
        Label namelabel3 = new Label();
        Label namelabel4 = new Label();
        Label namelabel5 = new Label();
        Label namelabel6 = new Label();
        Label namelabel7 = new Label();


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tableLayoutPanel1.ColumnCount = 36;
            tableLayoutPanel1.RowCount = 30;


            namelabel1.Text = "会社名1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 1);

            namelabel2.Text = "会社名2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 2);

            namelabel3.Text = "会社名3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 3);

            namelabel4.Text = "会社名4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 4);

            namelabel5.Text = "会社名5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 5);

            namelabel6.Text = "会社名6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 6);

            namelabel7.Text = "会社名7";
            namelabel7.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel7, 0, 7);


            for (int i = 0; i < 31; i++)
            {                
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(dateLabel, i + 1, 0);
                currentDate = currentDate.AddDays(1);
            }
            /*
            for (int i = 1; i < 32; i++)
            {
                Button button = new Button();
                button.Text = "s" + i;
                button.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button, i, 1);
            }
            */
            /*
            dataGrid = new int[31, 7];
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Label label = new Label();
                    label.Text = dataGrid[i, j].ToString();
                    label.Dock = DockStyle.Fill;
                    //label.TextAlign = ContentAlignment.MiddleCenter;
                    //ラベルのテキスト配置を中央センターに指定
                    label.Click += Datalabel_Click;
                    //セル内のクリックイベントにメソッドを追加

                    tableLayoutPanel1.Controls.Add(label, i + 1, j + 1);

                }
            }
            */



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DateTime targetDate = DateTime.Now.Date;
                connection.Open();
                String selectQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate;";
                for (int i = 0; i < 31; i++)
                {
                    
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@targetDate", targetDate);
                        Object dateStatus = command.ExecuteScalar();

                        if(dateStatus != null)
                        {
                            Label dateLabel = new Label();
                            dateLabel.Text = dateStatus.ToString();
                            dateLabel.Dock = DockStyle.Fill;
                            dateLabel.Click += Datalabel_Click;
                            tableLayoutPanel1.Controls.Add(dateLabel, i, 1);
                            targetDate = targetDate.AddDays(1);
                        }
                    }
           
                }
            }

        }
        private void Datalabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;

            int row = tableLayoutPanel1.GetRow(clickedLabel);
            int column = tableLayoutPanel1.GetColumn(clickedLabel);
            dataGrid[column - 1, row - 1] = 1 - dataGrid[column - 1, row - 1];
            //tableLayoutのセル番号と配列のindex番号は合わないので-1して使っている

            clickedLabel.Text = dataGrid[column - 1, row - 1].ToString();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}