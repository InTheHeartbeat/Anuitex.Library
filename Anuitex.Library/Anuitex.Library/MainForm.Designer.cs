namespace Anuitex.Library
{
    sealed partial class MainForm
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
            this.booksGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonTakeToRead = new System.Windows.Forms.Button();
            this.buttonReturnSelectedBook = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdateSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // booksGridView
            // 
            this.booksGridView.AllowUserToAddRows = false;
            this.booksGridView.AllowUserToDeleteRows = false;
            this.booksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Author,
            this.Genre,
            this.Year,
            this.Pages,
            this.Available});
            this.booksGridView.Location = new System.Drawing.Point(1, 1);
            this.booksGridView.MultiSelect = false;
            this.booksGridView.Name = "booksGridView";
            this.booksGridView.ReadOnly = true;
            this.booksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksGridView.Size = new System.Drawing.Size(609, 560);
            this.booksGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 52;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            this.Author.Width = 63;
            // 
            // Genre
            // 
            this.Genre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Genre.HeaderText = "Genre";
            this.Genre.Name = "Genre";
            this.Genre.ReadOnly = true;
            this.Genre.Width = 61;
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 54;
            // 
            // Pages
            // 
            this.Pages.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Pages.HeaderText = "Pages";
            this.Pages.Name = "Pages";
            this.Pages.ReadOnly = true;
            this.Pages.Width = 62;
            // 
            // Available
            // 
            this.Available.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Available.HeaderText = "Available";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            this.Available.Width = 75;
            // 
            // buttonTakeToRead
            // 
            this.buttonTakeToRead.Location = new System.Drawing.Point(616, 12);
            this.buttonTakeToRead.Name = "buttonTakeToRead";
            this.buttonTakeToRead.Size = new System.Drawing.Size(160, 25);
            this.buttonTakeToRead.TabIndex = 1;
            this.buttonTakeToRead.Text = "Take to read selected ";
            this.buttonTakeToRead.UseVisualStyleBackColor = true;
            this.buttonTakeToRead.Click += new System.EventHandler(this.buttonTakeToRead_Click);
            // 
            // buttonReturnSelectedBook
            // 
            this.buttonReturnSelectedBook.Location = new System.Drawing.Point(616, 43);
            this.buttonReturnSelectedBook.Name = "buttonReturnSelectedBook";
            this.buttonReturnSelectedBook.Size = new System.Drawing.Size(160, 25);
            this.buttonReturnSelectedBook.TabIndex = 2;
            this.buttonReturnSelectedBook.Text = "Mark book as Available";
            this.buttonReturnSelectedBook.UseVisualStyleBackColor = true;
            this.buttonReturnSelectedBook.Click += new System.EventHandler(this.buttonReturnSelectedBook_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Location = new System.Drawing.Point(616, 107);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(160, 25);
            this.buttonDeleteSelected.TabIndex = 4;
            this.buttonDeleteSelected.Text = "Delete selected book";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(616, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 2);
            this.label1.TabIndex = 3;
            // 
            // buttonUpdateSelected
            // 
            this.buttonUpdateSelected.Location = new System.Drawing.Point(616, 76);
            this.buttonUpdateSelected.Name = "buttonUpdateSelected";
            this.buttonUpdateSelected.Size = new System.Drawing.Size(160, 25);
            this.buttonUpdateSelected.TabIndex = 3;
            this.buttonUpdateSelected.Text = "Update selected book";
            this.buttonUpdateSelected.UseVisualStyleBackColor = true;
            this.buttonUpdateSelected.Click += new System.EventHandler(this.buttonUpdateSelected_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(616, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 2);
            this.label2.TabIndex = 5;
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(617, 141);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(160, 25);
            this.buttonAddBook.TabIndex = 5;
            this.buttonAddBook.Text = "Add new book";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUpdateSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.buttonTakeToRead);
            this.Controls.Add(this.buttonReturnSelectedBook);
            this.Controls.Add(this.booksGridView);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView booksGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available;
        private System.Windows.Forms.Button buttonTakeToRead;
        private System.Windows.Forms.Button buttonReturnSelectedBook;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdateSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddBook;
    }
}

