using System.Data;
using System.Data.SqlClient;

namespace calenderApp
{
    public partial class Form1 : Form
    {

        //DateTime currentDate = DateTime.Now.Date;

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

        Panel clickedPanel;
        int row;
        int column;


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tableLayoutPanel1.ColumnCount = 36;
            tableLayoutPanel1.RowCount = 30;


            CalenderDateShow();
            FactoryNameShow();
            SelectShowStatus();

        }

        //会社名・部署名を表示させるメソッド
        private void FactoryNameShow()
        {
            namelabel1.TextAlign = ContentAlignment.MiddleCenter;
            namelabel1.Text = "会社名1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 1);

            namelabel2.TextAlign = ContentAlignment.MiddleCenter;
            namelabel2.Text = "会社名2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 4);

            namelabel3.TextAlign = ContentAlignment.MiddleCenter;
            namelabel3.Text = "会社名3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 7);

            namelabel4.TextAlign = ContentAlignment.MiddleCenter;
            namelabel4.Text = "会社名4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 11);

            namelabel5.TextAlign = ContentAlignment.MiddleCenter;
            namelabel5.Text = "会社名5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 15);

            namelabel6.TextAlign = ContentAlignment.MiddleCenter;
            namelabel6.Text = "会社名6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 16);

            namelabel7.TextAlign = ContentAlignment.MiddleCenter;
            namelabel7.Text = "会社名7";
            namelabel7.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel7, 0, 17);

            namelabel8.TextAlign = ContentAlignment.MiddleCenter;
            namelabel8.Text = "車体";
            namelabel8.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel8, 1, 1);

            namelabel9.TextAlign = ContentAlignment.MiddleCenter;
            namelabel9.Text = "整備";
            namelabel9.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel9, 1, 2);

            namelabel10.TextAlign = ContentAlignment.MiddleCenter;
            namelabel10.Text = "塗装";
            namelabel10.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel10, 1, 3);

            namelabel11.TextAlign = ContentAlignment.MiddleCenter;
            namelabel11.Text = "車体";
            namelabel11.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel11, 1, 4);

            namelabel12.TextAlign = ContentAlignment.MiddleCenter;
            namelabel12.Text = "油圧";
            namelabel12.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel12, 1, 5);

            namelabel13.TextAlign = ContentAlignment.MiddleCenter;
            namelabel13.Text = "塗装";
            namelabel13.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel13, 1, 6);

            namelabel14.TextAlign = ContentAlignment.MiddleCenter;
            namelabel14.Text = "車体";
            namelabel14.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel14, 1, 7);

            namelabel15.TextAlign = ContentAlignment.MiddleCenter;
            namelabel15.Text = "整備";
            namelabel15.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel15, 1, 8);

            namelabel16.TextAlign = ContentAlignment.MiddleCenter;
            namelabel16.Text = "塗装";
            namelabel16.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel16, 1, 9);

            namelabel17.TextAlign = ContentAlignment.MiddleCenter;
            namelabel17.Text = "油圧";
            namelabel17.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel17, 1, 10);

            namelabel18.TextAlign = ContentAlignment.MiddleCenter;
            namelabel18.Text = "車体";
            namelabel18.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel18, 1, 11);

            namelabel19.TextAlign = ContentAlignment.MiddleCenter;
            namelabel19.Text = "整備";
            namelabel19.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel19, 1, 12);

            namelabel20.TextAlign = ContentAlignment.MiddleCenter;
            namelabel20.Text = "塗装";
            namelabel20.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel20, 1, 13);

            namelabel21.TextAlign = ContentAlignment.MiddleCenter;
            namelabel21.Text = "油圧";
            namelabel21.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel21, 1, 14);

            namelabel22.TextAlign = ContentAlignment.MiddleCenter;
            namelabel22.Text = "車体";
            namelabel22.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel22, 1, 15);

            namelabel23.TextAlign = ContentAlignment.MiddleCenter;
            namelabel23.Text = "整備";
            namelabel23.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel23, 1, 16);

            namelabel24.TextAlign = ContentAlignment.MiddleCenter;
            namelabel24.Text = "車体";
            namelabel24.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel24, 1, 17);
        }


        //カレンダーの日付部分を表示させるメソッド
        private void CalenderDateShow()
        {
            DateTime currentDate = dateTimePicker1.Value.Date;
            for (int i = 0; i < 31; i++)
            {
                Label dateLabel = new Label();
                dateLabel.Text = currentDate.Day.ToString();
                dateLabel.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(dateLabel, i + 2, 0);
                currentDate = currentDate.AddDays(1);
            }

        }

        private void Datalabel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ステータスを変更しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                clickedPanel = (Panel)sender;
                row = tableLayoutPanel1.GetRow(clickedPanel);
                column = tableLayoutPanel1.GetColumn(clickedPanel);
                CustomDialog customDialog = new CustomDialog(this);
                customDialog.ShowDialog();
            }
        }

        //クリックされたPanellだけ表示を更新するメソッド
        private void UpDatePanel(int row, int columun, int status)
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(columun, row);

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
                targetDate = targetDate.AddDays(column - 1);
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
        private void SelectShowStatus()
        {
            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                String selectQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate and UserID = @UserID;";

                for (int i = 1; i < 18; i++)
                {
                    DateTime targetDate = DateTime.Now.Date;

                    for (int j = 1; j < 32; j++)
                    {
                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            int UserID = 1000 + i;
                            command.Parameters.AddWithValue("@UserID", UserID);
                            command.Parameters.AddWithValue("@targetDate", targetDate);
                            Object dateStatus = command.ExecuteScalar();

                            if (dateStatus != null)
                            {
                                Panel datePanel = new Panel();

                                if ((int)dateStatus == 0)
                                {
                                    datePanel.BackColor = Color.Blue;
                                }
                                else if ((int)dateStatus == 1)
                                {
                                    datePanel.BackColor = Color.Yellow;
                                }
                                else if ((int)dateStatus == 2)
                                {
                                    datePanel.BackColor = Color.Red;
                                }
                                datePanel.BorderStyle = BorderStyle.FixedSingle;
                                datePanel.Dock = DockStyle.Fill;
                                datePanel.Click += Datalabel_Click;
                                tableLayoutPanel1.Controls.Add(datePanel, j + 1, i);

                            }
                            targetDate = targetDate.AddDays(1);
                        }
                    }
                }
            }
            */
            int[,] statsu = new int[16, 30]; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "";
                connection.Open();
                {
                    for (int i = 0; i < 17; i++)
                    {
                        DateTime targetDate = dateTimePicker1.Value.Date;
                        int UserID = 1000 + i;
                        String baseQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate and UserID = @UserID;";
                        for (int j = 0; j < 31; j++)
                        {
                            using (SqlCommand command = new SqlCommand(baseQuery, connection))
                            {
                                command.Parameters.Add("@targetDate", SqlDbType.Date).Value = targetDate;
                                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                                selectQuery += command.CommandText;

                                if (i < 17 || j < 31)
                                {
                                    selectQuery += " UNION ";
                                }
                                else if (i == 17 && j == 31)
                                {
                                    selectQuery += " ;";
                                }
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {

                        //配列に実行した結果を格納して
                        //表示させる

                    }
                }
            }

        }


        //選択した３１日間のカレンダーにする
        private void changedDateStatus()
        {

            tableLayoutPanel1.Controls.Clear();
            CalenderDateShow();
            FactoryNameShow();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                String selectQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate and UserID = @UserID";

                for (int i = 1; i < 18; i++)
                {
                    DateTime targetDate = dateTimePicker1.Value.Date;

                    for (int j = 1; j < 32; j++)
                    {

                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            int UserID = 1000 + i;
                            command.Parameters.AddWithValue("@UserID", UserID);
                            command.Parameters.AddWithValue("@targetDate", targetDate);
                            Object dateStatus = command.ExecuteScalar();

                            if (dateStatus != null)
                            {
                                Panel datePanel = new Panel();

                                if ((int)dateStatus == 0)
                                {
                                    datePanel.BackColor = Color.Blue;
                                }
                                else if ((int)dateStatus == 1)
                                {
                                    datePanel.BackColor = Color.Yellow;
                                }
                                else if ((int)dateStatus == 2)
                                {
                                    datePanel.BackColor = Color.Red;
                                }
                                datePanel.BorderStyle = BorderStyle.FixedSingle;
                                datePanel.Dock = DockStyle.Fill;
                                datePanel.Click += Datalabel_Click;
                                tableLayoutPanel1.Controls.Add(datePanel, j + 1, i);

                            }
                            targetDate = targetDate.AddDays(1);
                        }

                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BatchUpdater batchUpdater = new BatchUpdater(this);
            batchUpdater.ShowDialog();

            tableLayoutPanel1.Controls.Clear();
            CalenderDateShow();
            FactoryNameShow();
            SelectShowStatus();
        }

        public void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changedDateStatus();
        }
    }
}