using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace vt_ekle_sil_güncelle_resimli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox6.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Text = pictureBox1.ImageLocation;
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "insert into Table_2(ad,soyad,sinif,numara,sinav,resim)values ('" + textBox2.Text + "','" + textBox3.Text + "','" +textBox8.Text+ "','" +textBox4.Text+ "','" +textBox5.Text + "','" + textBox6.Text + "')";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("KAYIT YAPILDI");
            dataGridView1.DataSource = dataSet1.Tables[0];
            this.table_2TableAdapter.Fill(this.dataSet1.Table_2);
            sqlConnection1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            // TODO: This line of code loads data into the 'dataSet1.Table_2' table. You can move, or remove it, as needed.
            this.table_2TableAdapter.Fill(this.dataSet1.Table_2);
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           textBox6.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pictureBox1.ImageLocation=dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
            sqlCommand1.CommandText = "select * from Table_2 where ad like '"+textBox7.Text+"%'";
            sqlCommand1.ExecuteNonQuery();
            dataGridView1.Refresh();
            MessageBox.Show("KAYIT YAPILDI");
            dataGridView1.DataSource = dataSet1.Tables[0];
            this.table_2TableAdapter.Fill(this.dataSet1.Table_2);
            sqlConnection1.Close();
        }
    }
}
