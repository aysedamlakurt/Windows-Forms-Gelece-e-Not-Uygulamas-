using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GeleceğeNot
{
    public partial class notgir : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        private int userId;
        
        public notgir( )
        { 
           InitializeComponent();
           con = new MySqlConnection("Server=localhost;Database=gelecege_not;user=root;Pwd=123456;SslMode=none");
            
        }
        void Listele()
        {
            con.Open();
            string kayit = "SELECT * from future_notes where display_date < created_at";
            MySqlCommand komut = new MySqlCommand(kayit, con);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "gönderilme tarihi";
            dataGridView1.Columns[2].HeaderText = "oluşturma tarihi";
            dataGridView1.Columns[3].HeaderText = "not";
          
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void notgir_Load(object sender, EventArgs e)
        {
            MySqlConnection conn;
            conn= new MySqlConnection("Server=localhost;Database=gelecege_not;user=root;Pwd=123456;SslMode=none");
            conn.Open();
            string sorgu = "SELECT * from users";
            cmd = new MySqlCommand(sorgu, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["USERNAME"]);
            }
            conn.Close();
            
         
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                con.Open();
                string sorgu = "Insert into future_notes (id,message,display_date) values (@id,@message,@display_date)";
                cmd = new MySqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@id", (comboBox1.SelectedIndex+1));
                cmd.Parameters.AddWithValue("@message", textBox1.Text);
                var data1 = dateTimePicker1.Value;
                cmd.Parameters.Add("@display_date", MySqlDbType.Date).Value = data1;
                button1.Text = "Gönderildi!";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show("hata" + hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Listele();

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string kayit = "SELECT * from future_notes WHERE created_at < display_date ";
            MySqlCommand komut = new MySqlCommand(kayit, con);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText = "gönderilme tarihi";
            dataGridView2.Columns[2].HeaderText = "oluşturma tarihi";
            dataGridView2.Columns[3].HeaderText = "not";
        }
    }
}
