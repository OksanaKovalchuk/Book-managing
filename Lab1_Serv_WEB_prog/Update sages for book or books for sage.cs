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
    public partial class Update_sages_for_book_or_books_for_sage : Form
    {
        public Update_sages_for_book_or_books_for_sage(int id)
        {
            InitializeComponent();
            MessageBox.Show(id.ToString());
        }

        private void Update_sages_for_book_or_books_for_sage_Load(object sender, EventArgs e)
        {

        }
    }
}
