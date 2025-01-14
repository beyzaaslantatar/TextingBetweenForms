using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormlarArasiMesajlasma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public int mesaj_id;
        public int renk;
       
        public Form3 form3 = new Form3(); //Burada da form2deki mesajların form3 e gidebilmesi için form3 ü tanımladım
        private void Form2_Load(object sender, EventArgs e)
        {
            mesaj_id = 0;
            renk = 0;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Mesaj ID", 60);
            listView1.Columns.Add("Mesaj", 450);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            renk = listView1.Items.Count;
            mesaj_id = listView1.Items.Count;

            string[] satirekle = { mesaj_id.ToString(), textBox1.Text };
            ListViewItem satir = new ListViewItem(satirekle);
            listView1.Items.Add(satir);
            listView1.Items[renk].BackColor = Color.Red;
            listView1.Items[renk].ForeColor = Color.White;

            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            string[] satirekle2 = { mesaj_id.ToString(), textBox1.Text };
            ListViewItem satir2 = new ListViewItem(satirekle2);
            form1.listView1.Items.Add(satir2);

            DateTime anlikZaman = DateTime.Now;
            string[] satirekle3 = {anlikZaman.ToString() , textBox1.Text}; //string tipinde bir dizi oluşturdum ve içine listviewdeki zaman kısmına anlık zamanı,mesaja da textbox1den gelen veriyi koydum
            ListViewItem satir3 = new ListViewItem(satirekle3); //listview a satirekle3deki verilerimi ekleyebilmek için satir3 adında nesne oluşturdum
            form3.listView1.Items.Add(satir3); //ve satir3 u yani mesajımı form3ün listviewina ekledim ancak çalıştıramadım. normal mesajı aktaramadığım için şifrelemesini de yapmadım

            form1.listView1.Items[renk].BackColor = Color.Green;
            form1.listView1.Items[renk].ForeColor = Color.White;

            textBox1.Text = "";
            button1.Enabled = false;
            timer1.Start();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            progressBar1.Value = sayac;
            if (sayac == 3)
            {
                button1.Enabled = true;
                sayac = 0;
                progressBar1.Value = 0;
                timer1.Stop();
            }
        }
    }
} 
