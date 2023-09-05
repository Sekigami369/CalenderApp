using System;

namespace calenderApp
{
    public partial class CustomDialog : Form
    {
        public CustomDialog customDialog;
        public int returnValue;
        public CustomDialog()
        {
            InitializeComponent();
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
           
            if (radioButton1.Checked == true)
            {
                returnValue = 0;
            }
            else if (radioButton2.Checked == true)
            {
                returnValue = 1;
            }
            else if (radioButton3.Checked == true)
            {
                returnValue = 2;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
