using System.Data.SqlClient;

namespace calenderApp
{
    public partial class BatchUpdater : Form
    {
        Form1 form1;
        Dictionary<string, int> factoryID = new Dictionary<string, int>();

        public BatchUpdater()
        {

        }
        public BatchUpdater(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

        }

        private void BatchUpdater_Load(object sender, EventArgs e)
        {
            factoryID.Add("会社名1 - 車体", 1001);
            factoryID.Add("会社名1 - 整備", 1002);
            factoryID.Add("会社名1 - 塗装", 1003);
            factoryID.Add("会社名2 - 車体", 1004);
            factoryID.Add("会社名2 - 油圧", 1005);
            factoryID.Add("会社名2 - 塗装", 1006);
            factoryID.Add("会社名3 - 車体", 1007);
            factoryID.Add("会社名3 - 整備", 1008);
            factoryID.Add("会社名3 - 塗装", 1009);
            factoryID.Add("会社名3 - 油圧", 1010);
            factoryID.Add("会社名4 - 車体", 1011);
            factoryID.Add("会社名4 - 整備", 1012);
            factoryID.Add("会社名4 - 塗装", 1013);
            factoryID.Add("会社名4 - 油圧", 1014);
            factoryID.Add("会社名5 - 車体", 1015);
            factoryID.Add("会社名6 - 整備", 1016);
            factoryID.Add("会社名7 - 車体", 1017);

            foreach (string factID in factoryID.Keys)
            {

                //コンボボックスにkeyのみ表示させている
                comboBox1.Items.Add(factID);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            startDate = startDate.AddDays(-1);

            int returnStatus = 0;

            int factID = 0;


            if (radioButton1.Checked == true)
            {
                returnStatus = 0;
            }
            else if (radioButton2.Checked == true)
            {
                returnStatus = 1;
            }
            else if (radioButton3.Checked == true)
            {
                returnStatus = 2;
            }


            if (comboBox1.SelectedItem != null)
            {
                //comboBoxからkeyを受け取ってvalueを取得する
                string selectItemKey = comboBox1.SelectedItem.ToString();

                //dictionaryに狙ったkeyがあるかチェックする
                if (factoryID.ContainsKey(selectItemKey))
                {

                    //keykaravalueを取り出す
                    factID = factoryID[selectItemKey];
                }

            }
            else
            {
                MessageBox.Show("会社名を選択してください");
                return;
            }

            DialogResult result = MessageBox.Show("まとめてステータスを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(form1.connectionString))
                    {
                        string query = "UPDATE dateSchedule SET Status = @Status WHERE UserID = @UserID AND Dates BETWEEN @startDate AND @endDate;";

                        conn.Open();

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {

                            command.Parameters.AddWithValue("@Status", returnStatus);
                            command.Parameters.AddWithValue("@startDate", startDate);
                            command.Parameters.AddWithValue("@endDate", endDate);
                            command.Parameters.AddWithValue("@UserID", factID);

                            command.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("データベースに接続失敗" + ex.Message);
                }
                MessageBox.Show("更新終了");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}