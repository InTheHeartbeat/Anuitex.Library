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
            this.buttonSell = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.buttonUpdateSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBooks = new System.Windows.Forms.TabPage();
            this.tabPageJournals = new System.Windows.Forms.TabPage();
            this.journalsGridView = new System.Windows.Forms.DataGridView();
            this.tabPageNewspapers = new System.Windows.Forms.TabPage();
            this.newspapersGridView = new System.Windows.Forms.DataGridView();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalPeriodiciti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalSubjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperPeriodicity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewspaperAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageBooks.SuspendLayout();
            this.tabPageJournals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalsGridView)).BeginInit();
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
            this.BookPrice,
            this.BookAmount});
            this.booksGridView.Location = new System.Drawing.Point(7, 6);
            this.booksGridView.MultiSelect = false;
            this.booksGridView.Name = "booksGridView";
            this.booksGridView.ReadOnly = true;
            this.booksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksGridView.Size = new System.Drawing.Size(589, 426);
            this.booksGridView.TabIndex = 0;
            this.booksGridView.SelectionChanged += new System.EventHandler(this.BooksGridView_SelectionChanged);
            // 
            // buttonSell
            // 
            this.buttonSell.Location = new System.Drawing.Point(617, 23);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(160, 25);
            this.buttonSell.TabIndex = 1;
            this.buttonSell.Text = "Sell selected";
            this.buttonSell.UseVisualStyleBackColor = true;
            this.buttonSell.Click += new System.EventHandler(this.buttonTakeToRead_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Location = new System.Drawing.Point(617, 117);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(160, 25);
            this.buttonDeleteSelected.TabIndex = 4;
            this.buttonDeleteSelected.Text = "Delete selected";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
            // 
            // buttonUpdateSelected
            // 
            this.buttonUpdateSelected.Location = new System.Drawing.Point(617, 86);
            this.buttonUpdateSelected.Name = "buttonUpdateSelected";
            this.buttonUpdateSelected.Size = new System.Drawing.Size(160, 25);
            this.buttonUpdateSelected.TabIndex = 3;
            this.buttonUpdateSelected.Text = "Update selected";
            this.buttonUpdateSelected.UseVisualStyleBackColor = true;
            this.buttonUpdateSelected.Click += new System.EventHandler(this.buttonUpdateSelected_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(617, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 2);
            this.label2.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(618, 151);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(160, 25);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add new";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBooks);
            this.tabControl.Controls.Add(this.tabPageJournals);
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
            // tabPageJournals
            // 
            this.tabPageJournals.Controls.Add(this.journalsGridView);
            this.tabPageJournals.Location = new System.Drawing.Point(4, 22);
            this.tabPageJournals.Name = "tabPageJournals";
            this.tabPageJournals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJournals.Size = new System.Drawing.Size(602, 439);
            this.tabPageJournals.TabIndex = 1;
            this.tabPageJournals.Text = "Journals";
            this.tabPageJournals.UseVisualStyleBackColor = true;
            // 
            // journalsGridView
            // 
            this.journalsGridView.AllowUserToAddRows = false;
            this.journalsGridView.AllowUserToDeleteRows = false;
            this.journalsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journalsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JournalId,
            this.JournalTitle,
            this.JournalPeriodiciti,
            this.JournalSubjects,
            this.JournalDate,
            this.JournalPrice,
            this.JournalAmount});
            this.journalsGridView.Location = new System.Drawing.Point(7, 6);
            this.journalsGridView.MultiSelect = false;
            this.journalsGridView.Name = "journalsGridView";
            this.journalsGridView.ReadOnly = true;
            this.journalsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.journalsGridView.Size = new System.Drawing.Size(589, 426);
            this.journalsGridView.TabIndex = 1;
            this.journalsGridView.SelectionChanged += new System.EventHandler(this.journalsGridView_SelectionChanged);
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
            this.NewspaperPrice,
            this.NewspaperAmount});
            this.newspapersGridView.Location = new System.Drawing.Point(7, 6);
            this.newspapersGridView.MultiSelect = false;
            this.newspapersGridView.Name = "newspapersGridView";
            this.newspapersGridView.ReadOnly = true;
            this.newspapersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.newspapersGridView.Size = new System.Drawing.Size(589, 426);
            this.newspapersGridView.TabIndex = 1;
            this.newspapersGridView.SelectionChanged += new System.EventHandler(this.newspapersGridView_SelectionChanged);
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
            // BookPrice
            // 
            this.BookPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BookPrice.HeaderText = "Price";
            this.BookPrice.Name = "BookPrice";
            this.BookPrice.ReadOnly = true;
            this.BookPrice.Width = 56;
            // 
            // BookAmount
            // 
            this.BookAmount.HeaderText = "Amount";
            this.BookAmount.Name = "BookAmount";
            this.BookAmount.ReadOnly = true;
            // 
            // JournalId
            // 
            this.JournalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalId.HeaderText = "Id";
            this.JournalId.Name = "JournalId";
            this.JournalId.ReadOnly = true;
            this.JournalId.Width = 41;
            // 
            // JournalTitle
            // 
            this.JournalTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalTitle.HeaderText = "Title";
            this.JournalTitle.Name = "JournalTitle";
            this.JournalTitle.ReadOnly = true;
            this.JournalTitle.Width = 52;
            // 
            // JournalPeriodiciti
            // 
            this.JournalPeriodiciti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalPeriodiciti.HeaderText = "Periodicity";
            this.JournalPeriodiciti.Name = "JournalPeriodiciti";
            this.JournalPeriodiciti.ReadOnly = true;
            this.JournalPeriodiciti.Width = 80;
            // 
            // JournalSubjects
            // 
            this.JournalSubjects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalSubjects.HeaderText = "Subjects";
            this.JournalSubjects.Name = "JournalSubjects";
            this.JournalSubjects.ReadOnly = true;
            this.JournalSubjects.Width = 73;
            // 
            // JournalDate
            // 
            this.JournalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalDate.HeaderText = "Date";
            this.JournalDate.Name = "JournalDate";
            this.JournalDate.ReadOnly = true;
            this.JournalDate.Width = 55;
            // 
            // JournalPrice
            // 
            this.JournalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JournalPrice.HeaderText = "Price";
            this.JournalPrice.Name = "JournalPrice";
            this.JournalPrice.ReadOnly = true;
            this.JournalPrice.Width = 56;
            // 
            // JournalAmount
            // 
            this.JournalAmount.HeaderText = "Amount";
            this.JournalAmount.Name = "JournalAmount";
            this.JournalAmount.ReadOnly = true;
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
            // NewspaperPrice
            // 
            this.NewspaperPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NewspaperPrice.HeaderText = "Price";
            this.NewspaperPrice.Name = "NewspaperPrice";
            this.NewspaperPrice.ReadOnly = true;
            this.NewspaperPrice.Width = 56;
            // 
            // NewspaperAmount
            // 
            this.NewspaperAmount.HeaderText = "Amount";
            this.NewspaperAmount.Name = "NewspaperAmount";
            this.NewspaperAmount.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(617, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 2);
            this.label3.TabIndex = 7;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUpdateSelected);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.buttonSell);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageBooks.ResumeLayout(false);
            this.tabPageJournals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.journalsGridView)).EndInit();
            this.tabPageNewspapers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newspapersGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView booksGridView;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.Button buttonUpdateSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBooks;
        private System.Windows.Forms.TabPage tabPageJournals;
        private System.Windows.Forms.TabPage tabPageNewspapers;
        private System.Windows.Forms.DataGridView journalsGridView;
        private System.Windows.Forms.DataGridView newspapersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPages;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalPeriodiciti;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperPeriodicity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewspaperAmount;
        private System.Windows.Forms.Label label3;
    }
}

