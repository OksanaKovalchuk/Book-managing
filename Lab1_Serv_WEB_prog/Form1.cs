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
            comboBox3.SelectedIndex = 0;
            initData();
        }

        public void initData() {
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select dbo.Book.name, dbo.Book.IdBook, dbo.Sage.name as SageName, dbo.Sage.IdSage  from dbo.Book full join dbo.SageBook on dbo.Book.IdBook = dbo.SageBook.IdBook  full join dbo.Sage on dbo.Sage.IdSage = dbo.SageBook.IdSage";

            //cmd.CommandText = "select dbo.Book.name, dbo.Book.pages, dbo.Book.IdBook, dbo.Sage.name as SageName, dbo.Sage.IdSage d from dbo.Book full join dbo.SageBook on dbo.Book.IdBook = dbo.SageBook.IdBook  full join dbo.Sage on dbo.Sage.IdSage = dbo.SageBook.IdSage";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = true;
            sc.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Hide();
            listBox1.Hide();
            dataGridView1.Hide();
            if (comboBox3.SelectedIndex == 0)
            {
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select name, IdBook from Book";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                da1.Fill(dt1);
                listBox1.ValueMember = "IdBook";
                listBox1.DisplayMember = "name";
                listBox1.DataSource = dt1;
                sc.Close();
                listBox1.Show();
            }
            else if (comboBox3.SelectedIndex == 1) {
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select name, IdSage from Sage";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                da1.Fill(dt1);
                listBox2.ValueMember = "IdSage";
                listBox2.DisplayMember = "name";
                listBox2.DataSource = dt1;
                sc.Close();
                listBox2.Show();
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                //MessageBox.Show("SagesBooks");
                sc.Open();
                SqlCommand cmd = sc.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.Book.name, dbo.Book.IdBook, dbo.Sage.name as SageName, dbo.Sage.IdSage  from dbo.Book full join dbo.SageBook on dbo.Book.IdBook = dbo.SageBook.IdBook  full join dbo.Sage on dbo.Sage.IdSage = dbo.SageBook.IdSage";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = true;
                sc.Close();
                dataGridView1.Show();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox2.SelectedValue.ToString());
            if (comboBox3.SelectedIndex == 0) {
                UpdateForm uf = new UpdateForm(Convert.ToInt32(listBox1.SelectedValue.ToString()), comboBox3.SelectedIndex);
                uf.Show();
            }
            if (comboBox3.SelectedIndex == 1) {
                UpdateForm uf = new UpdateForm(Convert.ToInt32(listBox2.SelectedValue.ToString()), comboBox3.SelectedIndex);
                uf.Show();
            }
            if (comboBox3.SelectedIndex == 2)
            {
                Update_sages_for_book_or_books_for_sage usb = new Update_sages_for_book_or_books_for_sage(Convert.ToInt32(dataGridView1.CurrentRow.Index));
                usb.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                createForm cf = new createForm(comboBox3.SelectedIndex);
                cf.Show();
            }
            if (comboBox3.SelectedIndex == 1)
            {
                createForm cf = new createForm(comboBox3.SelectedIndex);
                cf.Show();
            }

        }
    }
}
//desktop-4024i6e
//C:\Users\koval\AppData\Local\Microsoft\VisualStudio\SSDT\SBManaging.mdf