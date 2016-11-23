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
            this.codeLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.codeTextBox = new System.Windows.Forms.RichTextBox();
            this.lexemeClassificationGrid = new System.Windows.Forms.DataGridView();
            this.Lexemes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lexemeClassificationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // testLexerButton
            // 
            this.testLexerButton.Location = new System.Drawing.Point(17, 204);
            this.testLexerButton.Name = "testLexerButton";
            this.testLexerButton.Size = new System.Drawing.Size(163, 55);
            this.testLexerButton.TabIndex = 0;
            this.testLexerButton.Text = "Execute";
            this.testLexerButton.UseVisualStyleBackColor = true;
            this.testLexerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // codeLabel
            // 
            this.codeLabel.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(13, 23);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(54, 22);
            this.codeLabel.TabIndex = 7;
            this.codeLabel.Text = "Code:";
            this.codeLabel.Click += new System.EventHandler(this.codeLabel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFileButton.Location = new System.Drawing.Point(172, 11);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(83, 31);
            this.openFileButton.TabIndex = 9;
            this.openFileButton.Text = "Open File...";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(17, 45);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.codeTextBox.Size = new System.Drawing.Size(238, 153);
            this.codeTextBox.TabIndex = 10;
            this.codeTextBox.Text = "";
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // lexemeClassificationGrid
            // 
            this.lexemeClassificationGrid.AllowUserToAddRows = false;
            this.lexemeClassificationGrid.AllowUserToDeleteRows = false;
            this.lexemeClassificationGrid.AllowUserToResizeColumns = false;
            this.lexemeClassificationGrid.AllowUserToResizeRows = false;
            this.lexemeClassificationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lexemeClassificationGrid.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.lexemeClassificationGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lexemeClassificationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemeClassificationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexemes,
            this.Classification});
            this.lexemeClassificationGrid.Location = new System.Drawing.Point(261, 23);
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
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(17, 265);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(696, 261);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(725, 536);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lexemeClassificationGrid);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.testLexerButton);
            this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "ANG GANDA NI MA\'AM KATH LOLTERPRETER";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lexemeClassificationGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testLexerButton;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.RichTextBox codeTextBox;
        private System.Windows.Forms.DataGridView lexemeClassificationGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexemes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

