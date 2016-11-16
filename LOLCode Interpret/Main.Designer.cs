namespace LOLCode_Interpret
{
    partial class Main
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
            this.testLexerButton = new System.Windows.Forms.Button();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.codeTextBox = new System.Windows.Forms.RichTextBox();
            this.lexemeClassificationGrid = new System.Windows.Forms.DataGridView();
            this.Lexemes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lexemeClassificationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // testLexerButton
            // 
            this.testLexerButton.Location = new System.Drawing.Point(581, 27);
            this.testLexerButton.Name = "testLexerButton";
            this.testLexerButton.Size = new System.Drawing.Size(163, 55);
            this.testLexerButton.TabIndex = 0;
            this.testLexerButton.Text = "Test Lexer";
            this.testLexerButton.UseVisualStyleBackColor = true;
            this.testLexerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.Font = new System.Drawing.Font("Source Sans Pro", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programNameLabel.Location = new System.Drawing.Point(12, 10);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(261, 30);
            this.programNameLabel.TabIndex = 2;
            this.programNameLabel.Text = "LOL CODE INTERPRETER";
            this.programNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // codeLabel
            // 
            this.codeLabel.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(13, 60);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(54, 22);
            this.codeLabel.TabIndex = 7;
            this.codeLabel.Text = "Code";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFileButton.Location = new System.Drawing.Point(73, 60);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 24);
            this.openFileButton.TabIndex = 9;
            this.openFileButton.Text = "Open File...";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(17, 105);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(238, 148);
            this.codeTextBox.TabIndex = 10;
            this.codeTextBox.Text = "";
            // 
            // lexemeClassificationGrid
            // 
            this.lexemeClassificationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lexemeClassificationGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lexemeClassificationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemeClassificationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexemes,
            this.Classification});
            this.lexemeClassificationGrid.Location = new System.Drawing.Point(261, 83);
            this.lexemeClassificationGrid.Name = "lexemeClassificationGrid";
            this.lexemeClassificationGrid.ReadOnly = true;
            this.lexemeClassificationGrid.RowHeadersVisible = false;
            this.lexemeClassificationGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lexemeClassificationGrid.Size = new System.Drawing.Size(223, 175);
            this.lexemeClassificationGrid.TabIndex = 11;
            // 
            // Lexemes
            // 
            this.Lexemes.HeaderText = "Lexeme";
            this.Lexemes.Name = "Lexemes";
            this.Lexemes.ReadOnly = true;
            this.Lexemes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Lexemes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Classification
            // 
            this.Classification.HeaderText = "Classification";
            this.Classification.Name = "Classification";
            this.Classification.ReadOnly = true;
            this.Classification.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Classification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(756, 402);
            this.Controls.Add(this.lexemeClassificationGrid);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.testLexerButton);
            this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "CMSC 124 \"Chipmunks\"";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lexemeClassificationGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testLexerButton;
        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.RichTextBox codeTextBox;
        private System.Windows.Forms.DataGridView lexemeClassificationGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexemes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
    }
}

