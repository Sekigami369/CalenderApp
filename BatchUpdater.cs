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
            factoryID.Add("会社名1", 1001);
            factoryID.Add("会社名2", 1002);
            factoryID.Add("会社名3", 1003);
            factoryID.Add("会社名4", 1004);
            factoryID.Add("会社名5", 1005);
            factoryID.Add("会社名6", 1006);
            factoryID.Add("会社名7", 1007);

            foreach (string factID in factoryID.Keys)
            {
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
            TimeSpan dateDiff = endDate - startDate;
            int diffDays = dateDiff.Days;      //更新する日数を取得
            int returnVal = 0;
            int factID;


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

                if (factoryID.ContainsKey(selectItemKey))
                {
                    factID = factoryID[selectItemKey];
                }

            }

            using(SqlConnection conn = new SqlConnection(form1.connectionString))
            {
                string query = "UPDATE ";
            }
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