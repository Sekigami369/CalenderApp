using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace calenderApp
{
    public partial class BatchUpdater : Form
    {
        Form1 form1;
        Dictionary<string, int> factoryID = new Dictionary<string, int>();
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";

        public BatchUpdater()
        {

        }
        public BatchUpdater(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            factoryID.Add("会社名1", 1001);
            factoryID.Add("会社名2", 1002);
            factoryID.Add("会社名3", 1003);
            factoryID.Add("会社名4", 1004);
            factoryID.Add("会社名5", 1005);
            factoryID.Add("会社名6", 1006);
            factoryID.Add("会社名7", 1007);

            foreach (string factID in factoryID.Keys)
            {
                comboBox1.Items.Add(factID);  //コンボボックスにkeyのみ表示させている
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
            TimeSpan dateDiff = endDate - startDate;
            int diffDays = dateDiff.Days;      //更新する日数を取得
            int returnVal = 0;
            int factID = 0;  //IDが取得できなかったとき何も影響しない整数で初期化


            if (radioButton1.Checked == true)
            {
                returnVal = 0;
            }
            else if (radioButton2.Checked == true)
            {
                returnVal = 1;
            }
            else if (radioButton3.Checked == true)
            {
                returnVal = 2;
            }


            if (comboBox1.SelectedItem != null)  //comboBoxからkeyを受け取ってvalueを取得する
            {
                string selectItemKey = comboBox1.SelectedItem.ToString();

                if (factoryID.ContainsKey(selectItemKey))  //dictionaryに狙ったkeyがあるかチェックする
                {
                    factID = factoryID[selectItemKey];　　//keykaravalueを取り出す
                }

            }
            else
            {
                MessageBox.Show("会社名を選択してください");
            }

            DialogResult result = MessageBox.Show("まとめてステータスを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dateSchedule SET Status = @Status WHERE Dates = @targetDate AND UserID = @UserID;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Status", returnVal);
                        cmd.Parameters.AddWithValue("@targetDate", startDate);
                        cmd.Parameters.AddWithValue("@UserID", factID);

                        for (int i = 0; i < diffDays + 1; i++)
                        { 
                            int count = cmd.ExecuteNonQuery();
                            
                            startDate = startDate.AddDays(1);
                        }
                    }
                }
                MessageBox.Show("更新終了");
            }
            Console.WriteLine("count件データベースに影響を与えた");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BatchUpdater_Load(object sender, EventArgs e)
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