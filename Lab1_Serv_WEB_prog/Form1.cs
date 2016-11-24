using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Lab1_Serv_WEB_prog
{
    public partial class Form1 : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-4024I6E\BEGINNING;Initial Catalog=BookSage;Integrated Security=True");
        SBManagingEntities sb = new SBManagingEntities();

        public Form1()
        {
            InitializeComponent();
            SBManagingEntities db = new SBManagingEntities();
            initData();
        }
        public void initData() {
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select dbo.Book.name, dbo.Book.pages, dbo.Book.IdBook, dbo.Sage.name as SageName, dbo.Sage.IdSage d from dbo.Book full join dbo.SageBook on dbo.Book.IdBook = dbo.SageBook.IdBook  full join dbo.Sage on dbo.Sage.IdSage = dbo.SageBook.IdSage";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sc.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void rBS(string str)
        {
            radioButtonBook.Text = str + "book by Author";
            radioButtonBook.Visible = true;
            radioButtonAuthor.Text = str + "author for exact book";
            radioButtonAuthor.Visible = true;
            radioButton3.Text = str + "both author and book";
            Sage sage = new Sage();
            sage.age = 24;
            sage.name = "asd";
            sb.Sages.Add(sage);
        }
        public void ShowAuthors() {
            label3.Visible = false; textBox3.Visible = false;
            label4.Visible = false; textBox4.Visible = false;
            label5.Visible = false; textBox2.Visible = false;
            sc.Open();
            SqlCommand cmd1 = sc.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select name, IdSage from Sage";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            comboBox1.ValueMember = "IdSage";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = dt1;
            comboBox1.Visible = true;
            comboBoxBooks.Visible = false;
            sc.Close();
        }
        public void ShowBook() {
            label3.Visible = false; textBox3.Visible = false;
            label4.Visible = false; textBox4.Visible = false;
            label5.Visible = false; textBox2.Visible = false;
            sc.Open();
            SqlCommand cmd1 = sc.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select name, IdBook from Book";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            comboBoxBooks.ValueMember = "IdBook";
            comboBoxBooks.DisplayMember = "name";
            comboBoxBooks.DataSource = dt1;
            sc.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                rBS("Create ");
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                rBS("Show ");
                if (radioButtonBook.Checked)
                {
                    ShowAuthors();
                }
                else if (radioButtonAuthor.Checked) {
                    ShowBook();
                }
            }
            if (comboBox2.SelectedIndex == 2)
            {
                rBS("Update ");
            }
            if (comboBox2.SelectedIndex == 3)
            {
                rBS("Delete ");
            }
        }

        private void radioButtonBook_CheckedChanged(object sender, EventArgs e)
        {
            ShowAuthors();
            if (radioButtonBook.Checked == true)
            {
                comboBox1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                //comboBox1.Visible = false;
                //label1.Visible = false;
            }
        }

        private void radioButtonAuthor_CheckedChanged(object sender, EventArgs e)
        {
            ShowBook();
            if (radioButtonAuthor.Checked == true)
            {
                comboBoxBooks.Visible = true;
                label2.Visible = true;
            }
            else
            {
                //comboBoxBooks.Visible = false;
                //label2.Visible = false;
            }
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView view = comboBoxBooks.SelectedItem as DataRowView;
            int id = Convert.ToInt32(view["IdBook"]);
            MessageBox.Show(id.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Book (pages, name, photo) values ( '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into SageBook IdSage =1 , IdBook = 10";
                sc.Close();
                MessageBox.Show("value added");
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                textBox2.Visible = true;label5.Visible = true;
                textBox3.Visible = true;label4.Visible = true;
                textBox4.Visible = true;label3.Visible = true;
                DataRowView view = comboBoxBooks.SelectedItem as DataRowView;
                int id = Convert.ToInt32(view["IdBook"]);
                MessageBox.Show(id.ToString());
                sc.Open();
                SqlCommand cmdp = sc.CreateCommand();
                cmdp.CommandType = CommandType.Text;
                cmdp.CommandText = "select pages from  Book where IdBook = "+ id.ToString();
                cmdp.ExecuteNonQuery();
                SqlDataAdapter da1 = new SqlDataAdapter(cmdp);
                textBox2.Text = da1.ToString();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Book set ";
                if (textBox2.Text != null) {
                    cmd.CommandText += " pages= '" + textBox2.Text.ToString();
                }
                if (textBox3.Text != null) {
                    cmd.CommandText += "' , name = '" + textBox3.Text.ToString() + "' ";
                }
                if (textBox4.Text != null) {
                    cmd.CommandText += ", photo = '" + textBox4.Text.ToString() + "' ";
                }
                cmd.CommandText += " where IdBook = " + id;
                MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show("value updated");
                initData();
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                DataRowView view = comboBoxBooks.SelectedItem as DataRowView;
                int id = Convert.ToInt32(view["IdBook"]);
                MessageBox.Show(id.ToString());
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Book where IdBook = " + id;
                cmd.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show("value deleted");
                initData();
            }
        }
    }
}
//desktop-4024i6e
//C:\Users\koval\AppData\Local\Microsoft\VisualStudio\SSDT\SBManaging.mdf