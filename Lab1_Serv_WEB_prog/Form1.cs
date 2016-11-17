using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Serv_WEB_prog
{
    public partial class Form1 : Form
    {
        SBManagingEntities sb = new SBManagingEntities();
        
        public Form1()
        {
            //var q = select name from sb.Books 
            InitializeComponent();
            //int a = sb.Books.Count();
            int a = 2;
            int[] arr = new int[a];
            for (int i = 0; i < a; i++) {
                arr[i] = 1;
            }
            comboBox1.Items.Add( arr);
                comboBox2.SelectedIndex = 1;

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

        public void rBS(string str) { 
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
            }
            if (comboBox2.SelectedIndex == 1)
            {
                rBS("Show ");
            }
            if (comboBox2.SelectedIndex == 2)
            {
                rBS("Update ");
            }
            if (comboBox2.SelectedIndex == 3) {
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
                else {
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