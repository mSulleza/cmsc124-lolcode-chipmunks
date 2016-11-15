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
            this.lexemeListBox = new System.Windows.Forms.ListBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.lexemeLabel = new System.Windows.Forms.Label();
            this.classificationListBox = new System.Windows.Forms.ListBox();
            this.classificationLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.codeTextBox = new System.Windows.Forms.RichTextBox();
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
            // lexemeListBox
            // 
            this.lexemeListBox.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexemeListBox.FormattingEnabled = true;
            this.lexemeListBox.ItemHeight = 16;
            this.lexemeListBox.Location = new System.Drawing.Point(261, 105);
            this.lexemeListBox.Name = "lexemeListBox";
            this.lexemeListBox.Size = new System.Drawing.Size(106, 148);
            this.lexemeListBox.TabIndex = 1;
            this.lexemeListBox.UseWaitCursor = true;
            this.lexemeListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            // lexemeLabel
            // 
            this.lexemeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lexemeLabel.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexemeLabel.Location = new System.Drawing.Point(261, 83);
            this.lexemeLabel.Name = "lexemeLabel";
            this.lexemeLabel.Size = new System.Drawing.Size(106, 22);
            this.lexemeLabel.TabIndex = 4;
            this.lexemeLabel.Text = "LEXEME";
            this.lexemeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lexemeLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // classificationListBox
            // 
            this.classificationListBox.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classificationListBox.FormattingEnabled = true;
            this.classificationListBox.ItemHeight = 16;
            this.classificationListBox.Location = new System.Drawing.Point(373, 105);
            this.classificationListBox.Name = "classificationListBox";
            this.classificationListBox.Size = new System.Drawing.Size(123, 148);
            this.classificationListBox.TabIndex = 5;
            this.classificationListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // classificationLabel
            // 
            this.classificationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificationLabel.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classificationLabel.Location = new System.Drawing.Point(373, 83);
            this.classificationLabel.Name = "classificationLabel";
            this.classificationLabel.Size = new System.Drawing.Size(123, 22);
            this.classificationLabel.TabIndex = 6;
            this.classificationLabel.Text = "CLASSIFICATION";
            this.classificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(756, 402);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.classificationLabel);
            this.Controls.Add(this.classificationListBox);
            this.Controls.Add(this.lexemeLabel);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.lexemeListBox);
            this.Controls.Add(this.testLexerButton);
            this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "CMSC 124 \"Chipmunks\"";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testLexerButton;
        private System.Windows.Forms.ListBox lexemeListBox;
        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.Label lexemeLabel;
        private System.Windows.Forms.ListBox classificationListBox;
        private System.Windows.Forms.Label classificationLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.RichTextBox codeTextBox;
    }
}

