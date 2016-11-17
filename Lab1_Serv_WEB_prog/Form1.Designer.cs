namespace Lab1_Serv_WEB_prog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButtonBook = new System.Windows.Forms.RadioButton();
            this.radioButtonAuthor = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label_crud = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBooks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose author :";
            this.label1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "vbnm,",
            "cvhjkl",
            "vbnjm"});
            this.comboBox1.Location = new System.Drawing.Point(7, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButtonBook
            // 
            this.radioButtonBook.AutoSize = true;
            this.radioButtonBook.Location = new System.Drawing.Point(21, 83);
            this.radioButtonBook.Name = "radioButtonBook";
            this.radioButtonBook.Size = new System.Drawing.Size(99, 17);
            this.radioButtonBook.TabIndex = 2;
            this.radioButtonBook.TabStop = true;
            this.radioButtonBook.Text = " book by author";
            this.radioButtonBook.UseVisualStyleBackColor = true;
            this.radioButtonBook.Visible = false;
            this.radioButtonBook.CheckedChanged += new System.EventHandler(this.radioButtonBook_CheckedChanged);
            // 
            // radioButtonAuthor
            // 
            this.radioButtonAuthor.AutoSize = true;
            this.radioButtonAuthor.Location = new System.Drawing.Point(21, 106);
            this.radioButtonAuthor.Name = "radioButtonAuthor";
            this.radioButtonAuthor.Size = new System.Drawing.Size(128, 17);
            this.radioButtonAuthor.TabIndex = 3;
            this.radioButtonAuthor.TabStop = true;
            this.radioButtonAuthor.Text = " author for some book";
            this.radioButtonAuthor.UseVisualStyleBackColor = true;
            this.radioButtonAuthor.Visible = false;
            this.radioButtonAuthor.CheckedChanged += new System.EventHandler(this.radioButtonAuthor_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(21, 129);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(130, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = " both book and author";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Create",
            "Read",
            "Update",
            "Delete"});
            this.comboBox2.Location = new System.Drawing.Point(25, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label_crud
            // 
            this.label_crud.AutoSize = true;
            this.label_crud.Location = new System.Drawing.Point(4, 9);
            this.label_crud.Name = "label_crud";
            this.label_crud.Size = new System.Drawing.Size(186, 13);
            this.label_crud.TabIndex = 6;
            this.label_crud.Text = "Choose what action you need to start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose Book:";
            this.label2.Visible = false;
            // 
            // comboBoxBooks
            // 
            this.comboBoxBooks.FormattingEnabled = true;
            this.comboBoxBooks.Location = new System.Drawing.Point(9, 184);
            this.comboBoxBooks.Name = "comboBoxBooks";
            this.comboBoxBooks.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBooks.TabIndex = 8;
            this.comboBoxBooks.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lab1_Serv_WEB_prog.Properties.Resources.PAULA_STUDIO_FONDAZIONEROMA_BOOKSHOP_PALAZZOSCIARRA_04;
            this.ClientSize = new System.Drawing.Size(594, 376);
            this.Controls.Add(this.comboBoxBooks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_crud);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButtonAuthor);
            this.Controls.Add(this.radioButtonBook);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButtonBook;
        private System.Windows.Forms.RadioButton radioButtonAuthor;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label_crud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBooks;

    }
}

