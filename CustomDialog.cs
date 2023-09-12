namespace calenderApp
{
    public partial class CustomDialog : Form
    {
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        public CustomDialog customDialog;
        Form1 form1;

        public CustomDialog()
        {
            InitializeComponent();

        }

        public CustomDialog(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

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
            int returnVal = 0;
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
            form1.PanelClickUpdate(returnVal);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
