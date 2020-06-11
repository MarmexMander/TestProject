namespace TestProject
{
    partial class ShowReprimentsForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectedText = new System.Windows.Forms.TextBox();
            this.userName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShortText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedName = new System.Windows.Forms.TextBox();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.userName,
            this.ShortText});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 34);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(387, 404);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectedText
            // 
            this.SelectedText.Location = new System.Drawing.Point(412, 34);
            this.SelectedText.Multiline = true;
            this.SelectedText.Name = "SelectedText";
            this.SelectedText.ReadOnly = true;
            this.SelectedText.Size = new System.Drawing.Size(376, 404);
            this.SelectedText.TabIndex = 3;
            // 
            // userName
            // 
            this.userName.DisplayIndex = 0;
            this.userName.Text = "Ім\'я користувача";
            // 
            // ShortText
            // 
            this.ShortText.DisplayIndex = 1;
            this.ShortText.Text = "Текст";
            // 
            // SelectedName
            // 
            this.SelectedName.Location = new System.Drawing.Point(412, 8);
            this.SelectedName.Name = "SelectedName";
            this.SelectedName.ReadOnly = true;
            this.SelectedName.Size = new System.Drawing.Size(376, 20);
            this.SelectedName.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DisplayIndex = 2;
            this.Id.Text = "Id";
            // 
            // ShowReprimentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectedName);
            this.Controls.Add(this.SelectedText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Name = "ShowReprimentsForm";
            this.Text = "Repriments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SelectedText;
        private System.Windows.Forms.ColumnHeader userName;
        private System.Windows.Forms.ColumnHeader ShortText;
        private System.Windows.Forms.TextBox SelectedName;
        private System.Windows.Forms.ColumnHeader Id;
    }
}