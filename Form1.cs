using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormlarArasiMesajlasma
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public string EncryptToBase64(string text) //Şifrelemek için ToBase64 yöntemini kullandım ve bunun için bir fonksiyon oluşturdum.
        {
            byte[] textByte = Encoding.UTF8.GetBytes(text); //Gelen texti UTF-8 kodlamasına göre byte dizisine dönüştürüyoruz
            string sifreliMesaj = Convert.ToBase64String(textByte); // Burada sifreliMesaj adında string tipinde ifade oluşturup byte dönüştürdüğümüz texti ToBase64 ile convert ederek şifreliyoruz
            return sifreliMesaj; //şifreli mesajımızı sonuç olarak döndürüyoruz
        }

        public Form2 form2 = new Form2(); //form2 ve form3 leri form1deki verileri gönderebilmek için tanımladım.
        public Form3 form3 = new Form3();

        public int mesaj_id;
        public int renk;
        public string mesaj;
        private void Form1_Load(object sender, EventArgs e)
        {
            mesaj = textBox1.Text;
            mesaj_id = 0;
            renk = 0;
            form2.Show();
            form2.Location = new Point(800,200);
            this.Location = new Point(200, 200);
            form3.Show(); //form3 ün de görünmesini sağladım ve location ile ekrandaki konumunu ayarladım
            form3.Location = new Point(500, 120);

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Mesaj ID", 60);
            listView1.Columns.Add("Mesaj", 450);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            renk=listView1.Items.Count;
            mesaj_id = listView1.Items.Count;
            
            string[] satirekle = {mesaj_id.ToString(),textBox1.Text};
            ListViewItem satir = new ListViewItem(satirekle);
            listView1.Items.Add(satir);
            listView1.Items[renk].BackColor = Color.Red;
            listView1.Items[renk].ForeColor = Color.White;

            string[] satirekle2 = { mesaj_id.ToString(), textBox1.Text };
            ListViewItem satir2 = new ListViewItem(satirekle2);
            form2.listView1.Items.Add(satir2);
            form2.listView1.Items[renk].BackColor = Color.Green;
            form2.listView1.Items[renk].ForeColor = Color.White;

            DateTime anlikZaman = DateTime.Now; //burda anlık zamanı alabilmek için datetime.now kullanarak anlikZaman adında nesne oluşturdum
            string[] satirekle3 = { anlikZaman.ToString(), textBox1.Text }; //string tipinde bir dizi oluşturdum ve içine listviewdeki zaman kısmına anlık zamanı,mesaja da textbox1den gelen veriyi koydum
            ListViewItem satir3 = new ListViewItem(satirekle3); //listview a satirekle3deki verilerimi ekleyebilmek için satir3 adında nesne oluşturdum
            string veri = textBox1.Text; //textbox1 den gelen mesajı veri'ye atadım
            string sifreliMesaj = EncryptToBase64(veri); //sifrelimesaj adında string tipinde ifade oluşturup EncryptToBase64 fonksiyonunu çağırdım ve parametre olarak veri'yi gönderdim
            satir3.SubItems.Add(sifreliMesaj); //burda şifreli mesajı ListViewItem nesnesine ekledim
            form3.listView1.Items.Add(satir3); // ve form3 listview ına satir3 ü yazdırdım ancak çalıştıramadım:(

            textBox1.Text = "";
            button1.Enabled = false;
            timer1.Start();

        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            progressBar1.Value=sayac;
            if (sayac==3)
            {
                button1.Enabled = true;
                sayac = 0;
                progressBar1.Value = 0;
                timer1.Stop();
            }
        }
    }
}
