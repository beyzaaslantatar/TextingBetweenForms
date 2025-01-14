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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            //Burada listviewımın satır ve sütunlarını belirledim ve zaman ve şifreli mesaj diye sütun açtım.
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Zaman", 110);
            listView1.Columns.Add("Şifreli mesaj", 450);
        }
    }
}
