using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList kdizi = new ArrayList();
        ArrayList sifredizi = new ArrayList();
        OleDbConnection baglanti=new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Yeni Microsoft Access Veritabanı3.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from giris",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kdizi.Add(oku["k_adi"].ToString());
                sifredizi.Add(oku["sifre"].ToString());
            }
            var kullaniciadi = textBox1.Text;
            var sifre = textBox2.Text;
            if (kdizi.IndexOf(kullaniciadi)!=-1)
            {
                int sira = kdizi.IndexOf(kullaniciadi);
                label1.Text = kdizi[sira].ToString();
                label2.Text = sifredizi[sira].ToString();
                if (kullaniciadi==label1.Text&&sifre==label2.Text)
                {
                    MessageBox.Show("başarılı");
                }
                else
                {
                    MessageBox.Show("başarısız");
                }
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutt = new OleDbCommand("insert into giris(k_adi,sifre) values('"+textBox3.Text+"','"+textBox4.Text+"')",baglanti);
            komutt.ExecuteNonQuery();
            MessageBox.Show("kayıt yapıldı");
            baglanti.Close();
        }
    }
}
