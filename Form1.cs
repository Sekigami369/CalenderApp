using System.Data.SqlClient;
using System.Drawing.Text;

namespace calenderApp
{
    public partial class Form1 : Form
    {
        int[,] dataGrid;
        Label namelabel1 = new Label();
        Label namelabel2 = new Label();
        Label namelabel3 = new Label();
        Label namelabel4 = new Label();
        Label namelabel5 = new Label();
        Label namelabel6 = new Label();
        Label namelabel7 = new Label();
        //DbHelper dbHelper = new DbHelper();

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
            //dbHelper.ExecuteNonQuery(selectQuery);

            tableLayoutPanel1.ColumnCount = 36;
            tableLayoutPanel1.RowCount = 30;


            namelabel1.Text = "��Ж�1";
            namelabel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel1, 0, 1);

            namelabel2.Text = "��Ж�2";
            namelabel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel2, 0, 2);

            namelabel3.Text = "��Ж�3";
            namelabel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel3, 0, 3);

            namelabel4.Text = "��Ж�4";
            namelabel4.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel4, 0, 4);

            namelabel5.Text = "��Ж�5";
            namelabel5.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel5, 0, 5);

            namelabel6.Text = "��Ж�6";
            namelabel6.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(namelabel6, 0, 6);

            namelabel7.Text = "��Ж�7";
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
            /*
            for (int i = 1; i < 32; i++)
            {
                Button button = new Button();
                button.Text = "s" + i;
                button.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button, i, 1);
            }
            */

            dataGrid = new int[31, 7];
            for(int i = 0; i < 31; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    Label label = new Label();
                    label.Text = dataGrid[i, j].ToString();
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                        //���x���̃e�L�X�g�z�u�𒆉��Z���^�[�Ɏw��
                    label.Click += Datalabel_Click;
                        //�Z�����̃N���b�N�C�x���g�Ƀ��\�b�h��ǉ�

                    tableLayoutPanel1.Controls.Add(label, i + 1, j + 1);

                }
            }
            
        }
        private void Datalabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;

            int row = tableLayoutPanel1.GetRow(clickedLabel);
            int column = tableLayoutPanel1.GetColumn(clickedLabel);
            dataGrid[column - 1, row - 1] = 1 - dataGrid[column - 1, row - 1];
                //tableLayout�̃Z���ԍ��Ɣz���index�ԍ��͍���Ȃ��̂�-1���Ďg���Ă���

            clickedLabel.Text = dataGrid[column - 1, row - 1].ToString();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}