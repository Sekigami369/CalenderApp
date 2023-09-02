using System.Data.SqlClient;

namespace calenderApp
{
    public partial class Form1 : Form
    {
        DateTime currentDate = DateTime.Now.Date;
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

            SelectShowStatus();   //データベースからStatusの値を1行分取ってきて表示させる

        }
        private void Datalabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;

            int row = tableLayoutPanel1.GetRow(clickedLabel);
            int column = tableLayoutPanel1.GetColumn(clickedLabel);

            DialogResult result = MessageBox.Show("ステータスを変更しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var customDialog = new CustomDialog();
                customDialog.ShowDialog();
                int result2 = customDialog.returnValue;//ラジオボタンの値を格納している


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DateTime targetDate = DateTime.Now.Date;
                    targetDate = targetDate.AddDays(column -1);
                    int UserID = row + 1000;
                    int StatusVal = 1;
                    string query = "UPDATE dateSchedule SET Status = @Status WHERE Dates = @targetDate AND UserID = @UserID;";//ラジオボタンの値をStatusのあたいとして更新する
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
                        command.ExecuteScalar();
                        MessageBox.Show("更新されました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UpDateLabel(row, column, StatusVal);
                    }
                }// customDialog.ShowDialog();の更新ボタンが押されたらUPDATEを実行するように改良する。
            }
        }

        private void UpDateLabel(int row, int columun, int status)    //クリックされたlabelだけ表示を更新するメソッド
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(columun , row);
            if (control is Label label)    //パターンマッチでcontrolがLabelにキャストできるかチェックしている
            {
                if (status == 2)
                {
                    label.BackColor = Color.Red;
                }
                else if (status == 0)
                {
                    label.BackColor = Color.Blue;
                }
                else if (status == 1)
                {
                    label.BackColor = Color.Yellow;
                }
            }
        }

        
        private void SelectShowStatus()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                
                connection.Open();
                String selectQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate and UserID = @UserID;";
                for (int j = 1; j < 8; j++)
                {
                    DateTime targetDate = DateTime.Now.Date;

                    for (int i = 1; i < 32; i++)
                    {
                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            int UserID = 1000 + j;
                            command.Parameters.AddWithValue("@UserID", UserID);
                            command.Parameters.AddWithValue("@targetDate", targetDate);
                            Object dateStatus = command.ExecuteScalar();

                            if (dateStatus != null)
                            {
                                Label dateLabel = new Label();
                               
                                if ((int)dateStatus == 0)
                                {
                                    dateLabel.BackColor = Color.Blue;
                                }
                                else if ((int)dateStatus == 1)
                                {
                                    dateLabel.BackColor = Color.Yellow;
                                }
                                else if ((int)dateStatus == 2)
                                {
                                    dateLabel.BackColor = Color.Red;
                                }

                                dateLabel.Dock = DockStyle.Fill;
                                dateLabel.Click += Datalabel_Click;
                                tableLayoutPanel1.Controls.Add(dateLabel, i, j);
                                
                            }       
                            targetDate = targetDate.AddDays(1);
                        }
                    }
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}