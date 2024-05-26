using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeleceğeNot
{
    public partial class kayitol : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public kayitol()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=gelecege_not;user=root;Pwd=123456;SslMode=none");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str1 = textBox2.Text;
            String str2 = textBox3.Text;

            if (String.Equals(str1, str2))
            {
                try
                {
                    string sorgu = "Insert into users (USERNAME,USER_PASSWORD) values (@USERNAME,@USER_PASSWORD)";
                    cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@USERNAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@USER_PASSWORD", textBox2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kayıt Eklendi.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("hata" + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Şifreler Aynı Değil.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
