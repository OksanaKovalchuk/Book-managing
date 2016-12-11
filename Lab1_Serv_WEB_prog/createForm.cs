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

namespace Lab1_Serv_WEB_prog
{
    public partial class createForm : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-4024I6E\BEGINNING;Initial Catalog=BookSage;Integrated Security=True");

        public createForm(int index)
        {
            InitializeComponent();
            label5.Text = index.ToString();
            if (index == 1)
            {
                label5.Text = "Sage";
                label2.Text = "age";
            }
            if (index == 0)
            {
                label5.Text = "Book";
                label2.Text = "pages";
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into "+label5.Text.ToString()+ "("+ label2.Text.ToString()+" , name, photo) values ( '" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            //cmd.CommandText = "insert into SageBook IdSage =1 , IdBook = 10";
            sc.Close();
            MessageBox.Show("value added");
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            //this.Hide();
        }
    }
}
