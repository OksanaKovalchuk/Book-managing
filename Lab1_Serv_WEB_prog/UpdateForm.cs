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
    public partial class UpdateForm : Form
    {
        SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-4024I6E\BEGINNING;Initial Catalog=BookSage;Integrated Security=True");

        public UpdateForm(int id, int index)
        {
            //int ident = id;
            InitializeComponent();
            //MessageBox.Show(id.ToString());
            label4.Text = id.ToString();
            if(index ==1)
            {
                label5.Text = "Sage";
                label2.Text = "age";
                initUpdateSage(Convert.ToInt32(id));
                AddSageBook.Text = "Add Book(s) by this author";
            }
            if (index == 0) {
                label5.Text = "Book";
                label2.Text = "pages";
                initUpdateBook(id);
                AddSageBook.Text = "Add Sage(s) for this book";
            }
        }

        public void initUpdateBook(int id)
        {
            sc.Open();
            SqlCommand cmd1 = sc.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select name, IdBook, pages, photo from Book where IdBook =" + id;
            cmd1.ExecuteNonQuery();
            //DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //da1.Fill(dt1);
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataSet MyDataSet = new DataSet();
            da1.Fill(MyDataSet, "Sage");
            //textBox1.Text = MyDataSet.Tables.ToString();
            textBox1.Text = MyDataSet.Tables[0].Rows[0]["name"].ToString();
            label4.Text = MyDataSet.Tables[0].Rows[0]["idBook"].ToString();
            textBox2.Text = MyDataSet.Tables[0].Rows[0]["pages"].ToString();
            textBox3.Text = MyDataSet.Tables[0].Rows[0]["photo"].ToString();
            sc.Close();
        }

        public void initUpdateSage(int id) {
            sc.Open();
            SqlCommand cmd1 = sc.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select name, IdSage, age, photo from Sage where IdSage =" + id;
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            //textBox2.Text = da1["name"].ToString();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataSet MyDataSet = new DataSet();
            da1.Fill(MyDataSet, "Sage");
            textBox1.Text = MyDataSet.Tables.ToString();
            textBox1.Text = MyDataSet.Tables[0].Rows[0]["name"].ToString();
            textBox2.Text = MyDataSet.Tables[0].Rows[0]["age"].ToString();
            textBox3.Text = MyDataSet.Tables[0].Rows[0]["photo"].ToString();
            sc.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from" + label5.Text.ToString() + " where Id" + label5.Text.ToString() + " = " + Convert.ToInt32(label4.Text);
            cmd.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("value deleted successfully!");
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update "+label5.Text.ToString()+" set ";
            cmd.CommandText += label2.Text.ToString()+"= '" + textBox2.Text.ToString();
            cmd.CommandText += "' , name = '" + textBox1.Text.ToString() + "' ";
            cmd.CommandText += ", photo = '" + textBox3.Text.ToString() + "' ";
            cmd.CommandText += " where Id"+label5.Text.ToString()+" = " + label4.Text;
            //MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            
            sc.Close();
            
            MessageBox.Show("value updated");
            initUpdateBook(Convert.ToInt32(label4.Text));
            if (label5.Text == "Book")
            {
                if (checkedListBox1.SelectedItems != null)
                {
                    foreach (int elem in checkedListBox1.CheckedIndices) {
                        sc.Open();
                        int id = elem + 1;
                        SqlCommand cmd2 = sc.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "insert into SageBook (IdSage, IdBook) ";
                        cmd2.CommandText += "values ( "+id + ", " + label4.Text.ToString()+" )";
                        //MessageBox.Show(cmd2.CommandText.ToString());
                        cmd2.ExecuteNonQuery();
                        sc.Close();
                    }
                }
                initUpdateBook(Convert.ToInt32(label4.Text));
            }
            else {
                    if (checkedListBox1.SelectedItems != null)
                    {
                        foreach (int elem in checkedListBox1.SelectedItems)
                        {
                            sc.Open();
                        //MessageBox.Show(checkedListBox1.Items[elem].ToString());
                        //int id = ;
                            SqlCommand cmd2 = sc.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "insert into SageBook (IdSage, IdBook) ";
                            cmd2.CommandText += "values ( " + label4.Text.ToString() + ", " + 1 + " )";
                            //MessageBox.Show(cmd2.CommandText.ToString());
                            cmd2.ExecuteNonQuery();
                            sc.Close();
                        }
                    }
                    initUpdateSage(Convert.ToInt32(label4.Text));
            }
        }

        private void AddSageBook_Click(object sender, EventArgs e)
        {
            this.Width +=this.Width;
            string strin;
            if (label5.Text == "Book") {
                strin = "Sage";
            }
            else {
                strin = "Book";
            }
            checkedListBox1.Visible = true;
            sc.Open();
            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select name, Id"+strin+" from "+strin;
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            ((ListBox)checkedListBox1).DataSource = dt1;
            ((ListBox)checkedListBox1).DisplayMember = "name";
            ((ListBox)checkedListBox1).ValueMember = Convert.ToString("Id"+strin);
            sc.Close();
            checkedListBox1.Show();
        }
    }
}
