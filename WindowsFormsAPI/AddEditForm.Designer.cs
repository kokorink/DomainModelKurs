namespace WindowsFormsAPI
{
    partial class AddEditForm
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
            this.buttonОК = new System.Windows.Forms.Button();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonОК
            // 
            this.buttonОК.Location = new System.Drawing.Point(79, 79);
            this.buttonОК.Name = "buttonОК";
            this.buttonОК.Size = new System.Drawing.Size(75, 23);
            this.buttonОК.TabIndex = 0;
            this.buttonОК.Text = "Ok";
            this.buttonОК.UseVisualStyleBackColor = true;
            this.buttonОК.Click += new System.EventHandler(this.buttonОК_Click);
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(12, 12);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(210, 20);
            this.textBoxQuestion.TabIndex = 1;
            this.textBoxQuestion.Text = "Предложение";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Text = "Имя";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(122, 38);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(100, 20);
            this.textBoxMail.TabIndex = 1;
            this.textBoxMail.Text = "Почта";
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 118);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.buttonОК);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditForm";
            this.Text = "AddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonОК;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxMail;
    }
}