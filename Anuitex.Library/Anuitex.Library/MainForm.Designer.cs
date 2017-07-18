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
            this.buttonTakeToRead = new System.Windows.Forms.Button();
            this.buttonReturnSelectedBook = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdateSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBooks = new System.Windows.Forms.TabPage();
            this.tabPageMagazines = new System.Windows.Forms.TabPage();
            this.magazinesGridView = new System.Windows.Forms.DataGridView();
            this.tabPageNewspapers = new System.Windows.Forms.TabPage();
            this.newspapersGridView = new System.Windows.Forms.DataGridView();
            this.MagazineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagazineTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagazinePeriodiciti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagazineSubjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagazineDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagazineAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperPeriodicity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageBooks.SuspendLayout();
            this.tabPageMagazines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magazinesGridView)).BeginInit();
            this.tabPageNewspapers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newspapersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // booksGridView
            // 
            this.booksGridView.AllowUserToAddRows = false;
            this.booksGridView.AllowUserToDeleteRows = false;
            this.booksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BookTitle,
            this.BookAuthor,
            this.BookGenre,
            this.BookYear,
            this.BookPages,
            this.BookAvailable});
            this.booksGridView.Location = new System.Drawing.Point(7, 6);
            this.booksGridView.MultiSelect = false;
            this.booksGridView.Name = "booksGridView";
            this.booksGridView.ReadOnly = true;
            this.booksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksGridView.Size = new System.Drawing.Size(589, 426);
            this.booksGridView.TabIndex = 0;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBooks);
            this.tabControl.Controls.Add(this.tabPageMagazines);
            this.tabControl.Controls.Add(this.tabPageNewspapers);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(610, 465);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageBooks
            // 
            this.tabPageBooks.Controls.Add(this.booksGridView);
            this.tabPageBooks.Location = new System.Drawing.Point(4, 22);
            this.tabPageBooks.Name = "tabPageBooks";
            this.tabPageBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBooks.Size = new System.Drawing.Size(602, 439);
            this.tabPageBooks.TabIndex = 0;
            this.tabPageBooks.Text = "Books";
            this.tabPageBooks.UseVisualStyleBackColor = true;
            // 
            // tabPageMagazines
            // 
            this.tabPageMagazines.Controls.Add(this.magazinesGridView);
            this.tabPageMagazines.Location = new System.Drawing.Point(4, 22);
            this.tabPageMagazines.Name = "tabPageMagazines";
            this.tabPageMagazines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMagazines.Size = new System.Drawing.Size(602, 439);
            this.tabPageMagazines.TabIndex = 1;
            this.tabPageMagazines.Text = "Magazines";
            this.tabPageMagazines.UseVisualStyleBackColor = true;
            // 
            // magazinesGridView
            // 
            this.magazinesGridView.AllowUserToAddRows = false;
            this.magazinesGridView.AllowUserToDeleteRows = false;
            this.magazinesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.magazinesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MagazineId,
            this.MagazineTitle,
            this.MagazinePeriodiciti,
            this.MagazineSubjects,
            this.MagazineDate,
            this.MagazineAvailable});
            this.magazinesGridView.Location = new System.Drawing.Point(7, 6);
            this.magazinesGridView.MultiSelect = false;
            this.magazinesGridView.Name = "magazinesGridView";
            this.magazinesGridView.ReadOnly = true;
            this.magazinesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.magazinesGridView.Size = new System.Drawing.Size(589, 426);
            this.magazinesGridView.TabIndex = 1;
            this.magazinesGridView.SelectionChanged += new System.EventHandler(this.magazinesGridView_SelectionChanged);
            // 
            // tabPageNewspapers
            // 
            this.tabPageNewspapers.Controls.Add(this.newspapersGridView);
            this.tabPageNewspapers.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewspapers.Name = "tabPageNewspapers";
            this.tabPageNewspapers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewspapers.Size = new System.Drawing.Size(602, 439);
            this.tabPageNewspapers.TabIndex = 2;
            this.tabPageNewspapers.Text = "Newspapers";
            this.tabPageNewspapers.UseVisualStyleBackColor = true;
            // 
            // newspapersGridView
            // 
            this.newspapersGridView.AllowUserToAddRows = false;
            this.newspapersGridView.AllowUserToDeleteRows = false;
            this.newspapersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newspapersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewspaperId,
            this.NewspaperTitle,
            this.NewspaperPeriodicity,
            this.NewspaperDate,
            this.NewspaperAvailable});
            this.newspapersGridView.Location = new System.Drawing.Point(7, 6);
            this.newspapersGridView.MultiSelect = false;
            this.newspapersGridView.Name = "newspapersGridView";
            this.newspapersGridView.ReadOnly = true;
            this.newspapersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.newspapersGridView.Size = new System.Drawing.Size(589, 426);
            this.newspapersGridView.TabIndex = 1;
            this.newspapersGridView.SelectionChanged += new System.EventHandler(this.newspapersGridView_SelectionChanged);
            // 
            // MagazineId
            // 
            this.MagazineId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazineId.HeaderText = "Id";
            this.MagazineId.Name = "MagazineId";
            this.MagazineId.ReadOnly = true;
            this.MagazineId.Width = 41;
            // 
            // MagazineTitle
            // 
            this.MagazineTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazineTitle.HeaderText = "Title";
            this.MagazineTitle.Name = "MagazineTitle";
            this.MagazineTitle.ReadOnly = true;
            this.MagazineTitle.Width = 52;
            // 
            // MagazinePeriodiciti
            // 
            this.MagazinePeriodiciti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazinePeriodiciti.HeaderText = "Periodicity";
            this.MagazinePeriodiciti.Name = "MagazinePeriodiciti";
            this.MagazinePeriodiciti.ReadOnly = true;
            this.MagazinePeriodiciti.Width = 80;
            // 
            // MagazineSubjects
            // 
            this.MagazineSubjects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazineSubjects.HeaderText = "Subjects";
            this.MagazineSubjects.Name = "MagazineSubjects";
            this.MagazineSubjects.ReadOnly = true;
            this.MagazineSubjects.Width = 73;
            // 
            // MagazineDate
            // 
            this.MagazineDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazineDate.HeaderText = "Date";
            this.MagazineDate.Name = "MagazineDate";
            this.MagazineDate.ReadOnly = true;
            this.MagazineDate.Width = 55;
            // 
            // MagazineAvailable
            // 
            this.MagazineAvailable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MagazineAvailable.HeaderText = "Available";
            this.MagazineAvailable.Name = "MagazineAvailable";
            this.MagazineAvailable.ReadOnly = true;
            this.MagazineAvailable.Width = 75;
            // 
            // BookId
            // 
            this.BookId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookId.HeaderText = "Id";
            this.BookId.Name = "BookId";
            this.BookId.ReadOnly = true;
            this.BookId.Width = 41;
            // 
            // BookTitle
            // 
            this.BookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookTitle.HeaderText = "Title";
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            this.BookTitle.Width = 52;
            // 
            // BookAuthor
            // 
            this.BookAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookAuthor.HeaderText = "Author";
            this.BookAuthor.Name = "BookAuthor";
            this.BookAuthor.ReadOnly = true;
            this.BookAuthor.Width = 63;
            // 
            // BookGenre
            // 
            this.BookGenre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookGenre.HeaderText = "Genre";
            this.BookGenre.Name = "BookGenre";
            this.BookGenre.ReadOnly = true;
            this.BookGenre.Width = 61;
            // 
            // BookYear
            // 
            this.BookYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookYear.HeaderText = "Year";
            this.BookYear.Name = "BookYear";
            this.BookYear.ReadOnly = true;
            this.BookYear.Width = 54;
            // 
            // BookPages
            // 
            this.BookPages.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookPages.HeaderText = "Pages";
            this.BookPages.Name = "BookPages";
            this.BookPages.ReadOnly = true;
            this.BookPages.Width = 62;
            // 
            // BookAvailable
            // 
            this.BookAvailable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookAvailable.HeaderText = "Available";
            this.BookAvailable.Name = "BookAvailable";
            this.BookAvailable.ReadOnly = true;
            this.BookAvailable.Width = 75;
            // 
            // NewspaperId
            // 
            this.NewspaperId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperId.HeaderText = "Id";
            this.NewspaperId.Name = "NewspaperId";
            this.NewspaperId.ReadOnly = true;
            this.NewspaperId.Width = 41;
            // 
            // NewspaperTitle
            // 
            this.NewspaperTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperTitle.HeaderText = "Title";
            this.NewspaperTitle.Name = "NewspaperTitle";
            this.NewspaperTitle.ReadOnly = true;
            this.NewspaperTitle.Width = 52;
            // 
            // NewspaperPeriodicity
            // 
            this.NewspaperPeriodicity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperPeriodicity.HeaderText = "Periodicity";
            this.NewspaperPeriodicity.Name = "NewspaperPeriodicity";
            this.NewspaperPeriodicity.ReadOnly = true;
            this.NewspaperPeriodicity.Width = 80;
            // 
            // NewspaperDate
            // 
            this.NewspaperDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperDate.HeaderText = "Date";
            this.NewspaperDate.Name = "NewspaperDate";
            this.NewspaperDate.ReadOnly = true;
            this.NewspaperDate.Width = 55;
            // 
            // NewspaperAvailable
            // 
            this.NewspaperAvailable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperAvailable.HeaderText = "Available";
            this.NewspaperAvailable.Name = "NewspaperAvailable";
            this.NewspaperAvailable.ReadOnly = true;
            this.NewspaperAvailable.Width = 75;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUpdateSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.buttonTakeToRead);
            this.Controls.Add(this.buttonReturnSelectedBook);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageBooks.ResumeLayout(false);
            this.tabPageMagazines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.magazinesGridView)).EndInit();
            this.tabPageNewspapers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newspapersGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView booksGridView;
        private System.Windows.Forms.Button buttonTakeToRead;
        private System.Windows.Forms.Button buttonReturnSelectedBook;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdateSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBooks;
        private System.Windows.Forms.TabPage tabPageMagazines;
        private System.Windows.Forms.TabPage tabPageNewspapers;
        private System.Windows.Forms.DataGridView magazinesGridView;
        private System.Windows.Forms.DataGridView newspapersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPages;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazineTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazinePeriodiciti;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazineSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazineDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagazineAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperPeriodicity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperAvailable;
    }
}

