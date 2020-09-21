using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי.clients
{
    public partial class addclient : Form
    {
       List<string> kind= new List<string>();//רשימה הכוללת את כל הלקוחות
        
        privateclient pv;
        businessclient bs;
        public addclient()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Addclient_Load(object sender, EventArgs e)
        {
            //הוספה של הלקוחות לרשימה
            kind.Add("לקוח עסקי");
            kind.Add("לקוח פרטי");
            comboBox1.DataSource = kind;

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text=="לקוח פרטי")
            {
                // יצירת לקוח פרטי
                pv = new privateclient();
                if (chekinput1())
                {
                    //הוספה לרשימה
                    lists.privateclient.Add(pv);
                    this.Close();
                }
            }
            else
            {
                //יצירת לקוח עסקי
                bs = new businessclient();
                if (chekinput2())
                {
                    //הוספה לרשימה
                    lists.businessclient.Add(bs);
                    this.Close();
                }
            }

        }
        //בדיקת תקינות נתונים של לקוח פרטי
        public bool chekinput1()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            //בדיקת ת"ז
            try
            { 
            for (int i = 0; i < lists.privateclient.Count; i++)
                if (Convert.ToInt32(textBox2.Text) == lists.privateclient[i].Code)
                    throw new Exception("תז זו קיימת כבר במאגר הלקוחות");

            for (int i = 0; i < lists.businessclient.Count; i++)
                if (Convert.ToInt32(textBox2.Text) == lists.businessclient[i].Code)
                    throw new Exception("תז זו קיימת כבר במאגר הלקוחות");
                if (legal.IsNumber(textBox2.Text))
                {
                    pv.Code = Convert.ToInt32(textBox2.Text);
                }
                else
                    throw new Exception("תז לא תקינה");

            }
              catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                flag = false;
            }
            //תקינות שם
            try
            {
                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text) || legal.IsEnglishBig(textBox1.Text))
                    pv.Name = textBox1.Text;
                else
                    throw new Exception("שם אינו חוקי");


            }
            catch(Exception ex)
            {
                errorProvider2.SetError(textBox1, ex.Message);
                flag = false;
            }


            return flag;
        }
        //בדיקת תקינות נתונים של לקוח עסקי
        public bool chekinput2()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            //בדיקת ת"ז
            try
            {
                for (int i = 0; i < lists.privateclient.Count; i++)
                    if (Convert.ToInt32(textBox2.Text) == lists.privateclient[i].Code)
                        throw new Exception("תז זו קיימת כבר במאגר הלקוחות");

                for (int i = 0; i < lists.businessclient.Count; i++)
                    if (Convert.ToInt32(textBox2.Text) == lists.businessclient[i].Code)
                        throw new Exception("תז זו קיימת כבר במאגר הלקוחות");
                if (legal.IsNumber(textBox2.Text))
                    bs.Code = Convert.ToInt32(textBox2.Text);
                else
                    throw new Exception("תז לא תקינה");

            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                flag = false;
            }
            //תקינות שם
            try
            {
                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text) || legal.IsEnglishBig(textBox1.Text))
                    bs.Name = textBox1.Text;
                else
                    throw new Exception("שם אינו חוקי");


            }
            catch (Exception ex)
            {
                errorProvider2.SetError(textBox1, ex.Message);
                flag = false;
            }


            return flag;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
