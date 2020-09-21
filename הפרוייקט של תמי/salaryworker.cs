using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי
{
    public partial class salaryworker : Form
    {
        List<workers.manager> workers = new List<workers.manager>();//רשימה של כל העובדים כולל המנהלים
        public salaryworker()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void salaryworker_Load(object sender, EventArgs e)
        {
            workers.AddRange(lists.manager);
            workers.AddRange(lists.worker);
            comboBox1.DataSource = workers;
            comboBox1.DisplayMember = "code";
            comboBox1.Text= "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (comboBox1.Text != "")
            {
                for (int i = 0; i < workers.Count; i++)
                {
                    if (Convert.ToInt32(comboBox1.Text) == workers[i].Code)
                    {
                        sum = workers[i].Salary(Convert.ToInt32(numericUpDown1.Value));
                        break;
                    }
                }
                label4.Visible = true;
                label4.Text = sum.ToString();
            }
            else
                MessageBox.Show("חסרים פרטים");
            
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (comboBox1.Text!="" && numericUpDown1.Value > 0)
                this.Close();
            else
                errorProvider1.SetError(button2, "נתונים חסרים");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
