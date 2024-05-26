using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GeleceğeNot
{
    public partial class login : Form
    {
      
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
      

        public login()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=gelecege_not;user=root;Pwd=123456;SslMode=none");

        }
        
    
        


        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitol kayit = new kayitol();
            kayit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                con.Open();
                string sorgu = "select * from users where USERNAME = @username and USER_PASSWORD = @password";
                cmd = new MySqlCommand(sorgu, con);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();
              

                if (reader.Read())
                {
                    reader.Close();
                    
                    notgir giris = new notgir();
                    giris.Show();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Bu kullanıcı adı ve şifreyle bir kullanıcı yoktur ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(" Lütfen geçerli bir değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
           
            



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
       

    }
}
