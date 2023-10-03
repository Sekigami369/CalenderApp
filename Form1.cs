using System.Data.SqlClient;

namespace calenderApp
{
    public partial class Form1 : Form
    {

        public string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        //public string connectionString = "Server=localhost\\SQLEXPRESS;Database=DBsekigami;Trusted_Connection=True;";
        Label namelabel1 = new Label();
        Label namelabel2 = new Label();
        Label namelabel3 = new Label();
        Label namelabel4 = new Label();
        Label namelabel5 = new Label();
        Label namelabel6 = new Label();
        Label namelabel7 = new Label();
        Label namelabel8 = new Label();
        Label namelabel9 = new Label();
        Label namelabel10 = new Label();
        Label namelabel11 = new Label();
        Label namelabel12 = new Label();
        Label namelabel13 = new Label();
        Label namelabel14 = new Label();
        Label namelabel15 = new Label();
        Label namelabel16 = new Label();
        Label namelabel17 = new Label();
        Label namelabel18 = new Label();
        Label namelabel19 = new Label();
        Label namelabel20 = new Label();
        Label namelabel21 = new Label();
        Label namelabel22 = new Label();
        Label namelabel23 = new Label();
        Label namelabel24 = new Label();

        //Panel clickedPanel;
        int row;
        int column;
        public DateTime BatchUpdaterStartDate { get; set; }



        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            CalenderDateShow(startDate);
            FactoryNameShow();
            SelectShowStatus(startDate);
        }

        //会社名・部署名を表示させるメソッド
        private void FactoryNameShow()
        {
            namelabel1.TextAlign = ContentAlignment.MiddleCenter;
            namelabel1.Text = "会社名1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 0);

            namelabel2.TextAlign = ContentAlignment.MiddleCenter;
            namelabel2.Text = "会社名2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 3);

            namelabel3.TextAlign = ContentAlignment.MiddleCenter;
            namelabel3.Text = "会社名3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 6);

            namelabel4.TextAlign = ContentAlignment.MiddleCenter;
            namelabel4.Text = "会社名4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 10);

            namelabel5.TextAlign = ContentAlignment.MiddleCenter;
            namelabel5.Text = "会社名5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 14);

            namelabel6.TextAlign = ContentAlignment.MiddleCenter;
            namelabel6.Text = "会社名6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 15);

            namelabel7.TextAlign = ContentAlignment.MiddleCenter;
            namelabel7.Text = "会社名7";
            namelabel7.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel7, 0, 16);

            namelabel8.TextAlign = ContentAlignment.MiddleCenter;
            namelabel8.Text = "車体";
            namelabel8.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel8, 1, 0);

            namelabel9.TextAlign = ContentAlignment.MiddleCenter;
            namelabel9.Text = "整備";
            namelabel9.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel9, 1, 1);

            namelabel10.TextAlign = ContentAlignment.MiddleCenter;
            namelabel10.Text = "塗装";
            namelabel10.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel10, 1, 2);

            namelabel11.TextAlign = ContentAlignment.MiddleCenter;
            namelabel11.Text = "車体";
            namelabel11.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel11, 1, 3);

            namelabel12.TextAlign = ContentAlignment.MiddleCenter;
            namelabel12.Text = "油圧";
            namelabel12.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel12, 1, 4);

            namelabel13.TextAlign = ContentAlignment.MiddleCenter;
            namelabel13.Text = "塗装";
            namelabel13.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel13, 1, 5);

            namelabel14.TextAlign = ContentAlignment.MiddleCenter;
            namelabel14.Text = "車体";
            namelabel14.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel14, 1, 6);

            namelabel15.TextAlign = ContentAlignment.MiddleCenter;
            namelabel15.Text = "整備";
            namelabel15.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel15, 1, 7);

            namelabel16.TextAlign = ContentAlignment.MiddleCenter;
            namelabel16.Text = "塗装";
            namelabel16.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel16, 1, 8);

            namelabel17.TextAlign = ContentAlignment.MiddleCenter;
            namelabel17.Text = "油圧";
            namelabel17.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel17, 1, 9);

            namelabel18.TextAlign = ContentAlignment.MiddleCenter;
            namelabel18.Text = "車体";
            namelabel18.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel18, 1, 10);

            namelabel19.TextAlign = ContentAlignment.MiddleCenter;
            namelabel19.Text = "整備";
            namelabel19.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel19, 1, 11);

            namelabel20.TextAlign = ContentAlignment.MiddleCenter;
            namelabel20.Text = "塗装";
            namelabel20.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel20, 1, 12);

            namelabel21.TextAlign = ContentAlignment.MiddleCenter;
            namelabel21.Text = "油圧";
            namelabel21.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel21, 1, 13);

            namelabel22.TextAlign = ContentAlignment.MiddleCenter;
            namelabel22.Text = "車体";
            namelabel22.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel22, 1, 14);

            namelabel23.TextAlign = ContentAlignment.MiddleCenter;
            namelabel23.Text = "整備";
            namelabel23.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel23, 1, 15);

            namelabel24.TextAlign = ContentAlignment.MiddleCenter;
            namelabel24.Text = "車体";
            namelabel24.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel24, 1, 16);
        }


        //カレンダーの日付部分を表示させるメソッド
        private void CalenderDateShow(DateTime startDate)
        {
            DateTime currentDate = startDate;
            Label monthLabel = new Label();
            monthLabel.Text = currentDate.Month.ToString() + "月";
            monthLabel.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(monthLabel, 0, 0);
            for (int i = 1; i < 32; i++)
            {

                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Dock = DockStyle.Fill;
                tableLayoutPanel3.Controls.Add(dateLabel, i, 0);
                currentDate = currentDate.AddDays(1);
            }

        }

        private void Datalabel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ステータスを変更しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Panel clickedPanel = (Panel)sender;
                row = tableLayoutPanel2.GetRow(clickedPanel);
                column = tableLayoutPanel2.GetColumn(clickedPanel);
                CustomDialog customDialog = new CustomDialog(this);
                customDialog.ShowDialog();
            }
        }

        //クリックされたPanellだけ表示を更新するメソッド
        private void UpDatePanel(int row, int columun, int status)
        {
            Control control = tableLayoutPanel2.GetControlFromPosition(columun, row);

            //パターンマッチでcontrolがPanelにキャストできるかチェックしている
            if (control is Panel panel)
            {
                if (status == 0)
                {
                    panel.BackColor = Color.Blue;
                }
                else if (status == 1)
                {
                    panel.BackColor = Color.Yellow;
                }
                else if (status == 2)
                {
                    panel.BackColor = Color.Red;
                }
            }
        }

        //色のついたパネルをクリックして色を変えるメソッド
        public void PanelClickUpdate(int returnVal)
        {
            int result2 = returnVal;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DateTime targetDate = DateTime.Now.Date;
                targetDate = targetDate.AddDays(column);
                int UserID = row + 1000;
                int StatusVal = 1;
                string query = "UPDATE dateSchedule SET Status = @Status WHERE Dates = @targetDate AND UserID = @UserID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    if (result2 == 0)
                    {
                        StatusVal = 0;
                    }
                    else if (result2 == 1)
                    {
                        StatusVal = 1;
                    }
                    else if (result2 == 2)
                    {
                        StatusVal = 2;
                    }
                    connection.Open();
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@targetDate", targetDate);
                    command.Parameters.AddWithValue("@Status", StatusVal);
                    command.ExecuteNonQuery();
                    MessageBox.Show("更新されました。", "完了", MessageBoxButtons.OK);

                    UpDatePanel(row, column, StatusVal);
                }
            }
        }

        //当日日付のカレンダーを表示する
        private void SelectShowStatus(DateTime startDate)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectQuery = "SELECT Status FROM dateSchedule WHERE Dates BETWEEN  @startDate AND @endDate AND UserID BETWEEN 1001 AND 1017;";


                DateTime endDate = startDate.AddDays(30);
                int dateStatus;

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int j = 0; j < reader.FieldCount; j++)
                            {
                                dateStatus = reader.GetInt32(j);

                                if (dateStatus != null)
                                {
                                    Panel datePanel = new Panel();

                                    if (dateStatus == 0)
                                    {
                                        datePanel.BackColor = Color.Blue;
                                    }
                                    else if (dateStatus == 1)
                                    {
                                        datePanel.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        datePanel.BackColor = Color.Red;
                                    }

                                    datePanel.BorderStyle = BorderStyle.FixedSingle;
                                    datePanel.Dock = DockStyle.Fill;
                                    datePanel.Click += Datalabel_Click;

                                    tableLayoutPanel2.Controls.Add(datePanel);
                                    //tableLayoutPanel2.Controls.Add(clickedPanel);
                                }
                            }
                        }
                    }
                }
            }
        }

        //選択した３１日間のカレンダーにする
        private void changedDateStatus()
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            tableLayoutPanel3.Controls.Clear();
            tableLayoutPanel2.Controls.Clear();
            CalenderDateShow(startDate);
            SelectShowStatus(startDate);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BatchUpdater batchUpdater = new BatchUpdater(this);
            batchUpdater.ShowDialog();

            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel3.Controls.Clear();
            CalenderDateShow(this.BatchUpdaterStartDate);
            SelectShowStatus(this.BatchUpdaterStartDate);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changedDateStatus();
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}