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
            //var q = select name from sb.Books 
            InitializeComponent();
            SBManagingEntities db = new SBManagingEntities();
            
            //Selected = 1;
            /*штt a = sb.Books.First();*/
            //Console.Write(a);
            int a = 2;
            int[] arr = new int[a];
            for (int i = 0; i < a; i++)
            {
                arr[i] = 1;
            }
            comboBox1.Items.Add(arr);
            comboBox2.SelectedIndex = 1;
            Sage sage = new Sage();
            sage.age = 24;
            sage.name = "asd";
            db.Sages.Add(sage);
            Book book = new Book();
            book.name = "Sobaka Pavlova";
            book.pages = 100;
            db.Books.Add(book);
            //SqlCommand sc = new SqlCommand("Insert into"+ db.Books+" values (1,'Sobaka' , 100)");
            //object o = sc.ExecuteNonQuery();
            //var select = from books in db.Books
            //             select new { id = books.IdBook, name = books.name, pages = books.pages };
            //dataGridView1.DataSource = select.ToList();

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
            // sb.SaveChanges();

            //   radioButton3.Visible = true;

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                rBS("Create ");
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Book (pages, name, photo) values ( '" + textBox2.Text+"','" + textBox3.Text + "','" + textBox4.Text+ "')";
                cmd.ExecuteNonQuery();
                //textBox2
                sc.Close();
                MessageBox.Show("soth happened");
            }
            if (comboBox2.SelectedIndex == 1)
            {
                rBS("Show ");
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.Book ";
                    cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                //dataGridView1.DataSource = KC
                //textBox2
                sc.Close();
                MessageBox.Show("soth happened"); sc.Open();
                SqlCommand cmd1 = sc.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select name from Book";
                cmd1.ExecuteNonQuery();
                comboBoxBooks.
                //textBox2
                sc.Close();
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
            if (radioButtonBook.Checked == true)
            {
                comboBox1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
                label1.Visible = false;
            }
        }

        private void radioButtonAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAuthor.Checked == true)
            {
                comboBoxBooks.Visible = true;
                label2.Visible = true;
            }
            else
            {
                comboBoxBooks.Visible = false;
                label2.Visible = false;
            }
        }
    }
}
//desktop-4024i6e
//C:\Users\koval\AppData\Local\Microsoft\VisualStudio\SSDT\SBManaging.mdf