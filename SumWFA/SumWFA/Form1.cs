namespace SumWFA
{
    public partial class Form1 : Form //inh ,repr wfa 
    {
        public Form1()
        {
            InitializeComponent();  //cns , initialize 
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            // parse first number
            if (!double.TryParse(textNumber1.Text.Trim(), out double num1))
            {
                MessageBox.Show("Please enter a valid number in Number 1", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNumber1.Focus(); //cursor
                return;
            }

            // parse second number
            if (!double.TryParse(textNumber2.Text.Trim(), out double num2))
            {
                MessageBox.Show("Please enter a valid number in Number 2", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNumber2.Focus();
                return;
            }

          
            double sum = num1 + num2;

          
            lblResult.Text = $"Sum: {sum}";
        }

       
    }
}