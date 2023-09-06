using System.Data.SqlClient;
using System.Windows.Forms;

namespace calenderApp
{
    public partial class CustomDialog : Form
    {
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        public CustomDialog customDialog;
        
        
        public CustomDialog()
        {
            InitializeComponent();
        }
        public CustomDialog(Form1 form1)
        {
            InitializeComponent();
            object form1Instance = form1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Panel clickedPanel = (Panel)sender;
            
            int row = tableLayoutPanel1.GetRow(clickedPanel);   //tableLayoutPanelを使えるようにする
            int column = tableLayoutPanel1.GetColumn(clickedPanel);
            DialogResult result = MessageBox.Show("ステータスを変更しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {           

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DateTime targetDate = DateTime.Now.Date;
                    targetDate = targetDate.AddDays(column - 1);
                    int UserID = row + 1000;
                    int StatusVal = 1;
                    string query = "UPDATE dateSchedule SET Status = @Status WHERE Dates = @targetDate AND UserID = @UserID;";//ラジオボタンの値をStatusのあたいとして更新する
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        if (radioButton1.Checked == true)
                        {
                            StatusVal = 0;
                        }
                        else if (radioButton2.Checked == true)
                        {
                            StatusVal = 1;
                        }
                        else if (radioButton3.Checked == true)
                        {
                            StatusVal = 2;
                        }

                        connection.Open();
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@targetDate", targetDate);
                        command.Parameters.AddWithValue("@Status", StatusVal);
                        command.ExecuteScalar();
                        MessageBox.Show("更新されました。", "確認", MessageBoxButtons.OK);

                        UpDatePanel(row, column, StatusVal);
                    }
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpDatePanel(int row, int columun, int status)    //クリックされたlabelだけ表示を更新するメソッド
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(columun, row);
            if (control is Panel panel)    //パターンマッチでcontrolがLabelにキャストできるかチェックしている
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
    }
}
