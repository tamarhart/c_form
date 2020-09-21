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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            workers.addwarker addw = new workers.addwarker();
            this.Hide();
            addw.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            clients.addclient addc = new clients.addclient();
            this.Hide();
            addc.ShowDialog();
            this.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            shows.addshow adds = new shows.addshow();
            this.Hide();
            adds.ShowDialog();
            this.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            halls.addhall addh = new halls.addhall();
            this.Hide();
            addh.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            halls.addplay addp = new halls.addplay();
            this.Hide();
            addp.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addorder oddr = new addorder();
            this.Hide();
            oddr.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            salaryworker sa = new salaryworker();
            this.Hide();
            sa.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //קריאה לפונקציה שיוצרת רשימה ומעתיקה אליה מהקובץ  
            lists.OpenData();

        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            //קריאה לפונקציה שמעתיקה מהרשימה לקובץ אם הקובץ לא קיים יוצרת אותו
           lists.SaveData();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    button1.BackColor = Color.Aqua;
        //    button2.BackColor = Color.Aqua;
        //    button3.BackColor = Color.Aqua;
        //    button4.BackColor = Color.Aqua;
        //    button5.BackColor = Color.Aqua;
        //    button6.BackColor = Color.Aqua;
        //    button7.BackColor = Color.Aqua;
        //}
        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    button1.BackColor =Color.Red;
        //    button2.BackColor = Color.Red;
        //    button3.BackColor = Color.Red;
        //    button4.BackColor = Color.Red;
        //    button5.BackColor = Color.Red;
        //    button6.BackColor = Color.Red;
        //    button7.BackColor = Color.Red;
        //}
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    button1.BackColor = Color.Black;
        //    button2.BackColor = Color.Black;
        //    button3.BackColor = Color.Black;
        //    button4.BackColor = Color.Black;
        //    button5.BackColor = Color.Black;
        //    button6.BackColor = Color.Black;
        //    button7.BackColor = Color.Black;
        //}

    }
}
