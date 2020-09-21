using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי.halls
{
    public partial class addhall : Form
    {
        public addhall()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hall ah = new Hall();//יצירת אוביקט מסוג אולם
            ah.Codehole = Convert.ToInt32(textBox1.Text);
            ah.Numplace = Convert.ToInt32(numericUpDown1.Value);
            lists.hall.Add(ah);
            this.Close();

        }

        private void addhall_Load(object sender, EventArgs e)
        {
            if (lists.hall.Count == 0)
                textBox1.Text = "1";
            else
                textBox1.Text =Convert.ToString(lists.hall.Count+1);


        }
    }
}
