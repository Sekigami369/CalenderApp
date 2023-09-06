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
        CustomDialog customDialog;


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tableLayoutPanel1.ColumnCount = 36;
            tableLayoutPanel1.RowCount = 30;

            namelabel1.TextAlign = ContentAlignment.MiddleCenter;
            namelabel1.Text = "��Ж�1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 1);

            namelabel2.TextAlign = ContentAlignment.MiddleCenter;
            namelabel2.Text = "��Ж�2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 2);

            namelabel3.TextAlign = ContentAlignment.MiddleCenter;
            namelabel3.Text = "��Ж�3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 3);

            namelabel4.TextAlign = ContentAlignment.MiddleCenter;
            namelabel4.Text = "��Ж�4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 4);

            namelabel5.TextAlign = ContentAlignment.MiddleCenter;
            namelabel5.Text = "��Ж�5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 5);

            namelabel6.TextAlign = ContentAlignment.MiddleCenter;
            namelabel6.Text = "��Ж�6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 6);

            namelabel7.TextAlign = ContentAlignment.MiddleCenter;
            namelabel7.Text = "��Ж�7";
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

            SelectShowStatus();   //�f�[�^�x�[�X����Status�̒l��1�s������Ă��ĕ\��������

        }
        private void Datalabel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�X�e�[�^�X��ύX���܂����H", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                customDialog = new CustomDialog();
                customDialog.ShowDialog();
            }
        }

        private void UpDatePanel(int row, int columun, int status)    //�N���b�N���ꂽlabel�����\�����X�V���郁�\�b�h
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(columun, row);
            if (control is Panel panel)    //�p�^�[���}�b�`��control��Label�ɃL���X�g�ł��邩�`�F�b�N���Ă���
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

        public void PanelClick(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;

            int row = tableLayoutPanel1.GetRow(clickedPanel);
            int column = tableLayoutPanel1.GetColumn(clickedPanel);

            {

                int result2 = customDialog.returnVal;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DateTime targetDate = DateTime.Now.Date;
                    targetDate = targetDate.AddDays(column - 1);
                    int UserID = row + 1000;
                    int StatusVal = 1;
                    string query = "UPDATE dateSchedule SET Status = @Status WHERE Dates = @targetDate AND UserID = @UserID;";//���W�I�{�^���̒l��Status�̂������Ƃ��čX�V����
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
                        MessageBox.Show("�X�V����܂����B", "�m�F", MessageBoxButtons.OK);

                        UpDatePanel(row, column, StatusVal);
                    }
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
                                tableLayoutPanel1.Controls.Add(datePanel, i, j);

                            }
                            targetDate = targetDate.AddDays(1);
                        }
                    }
                }
            }
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
        // �e�[�u���̕\������������N���A�ɂ��Ȃ��Ƃ��܂����Ȃ�


        private void changedDateStatus()
        {
            DateTime dateTime = dateTimePicker1.Value;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    int rowIndexRemove = i;
                    int columnIndexRemove = j;
                    Control controlToRemove = tableLayoutPanel1.GetControlFromPosition(columnIndexRemove, rowIndexRemove);
                    if (controlToRemove != null)
                    {
                        tableLayoutPanel1.Controls.Remove(controlToRemove);
                    }

                }
            }
            for (int k = 1; k < 32; k++)
            {

                Label label = new Label();
                label.Text = dateTime.Day.ToString();
                label.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(label, k, 0);
                dateTime = dateTime.AddDays(1);
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                String selectQuery = "SELECT Status FROM dateSchedule Where Dates = @targetDate and UserID = @UserID;";
                for (int j = 1; j < 8; j++)
                {
                    DateTime targetDate = dateTimePicker1.Value.Date;
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
                                tableLayoutPanel1.Controls.Add(datePanel, i, j);

                            }
                            targetDate = targetDate.AddDays(1);
                        }
                    }
                }
            }
        }

    }
}