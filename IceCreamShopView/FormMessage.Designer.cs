namespace IceCreamShopView
{
    partial class FormMessage
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
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelReply = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(102, 32);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(84, 15);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "Отправитель: ";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(102, 60);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(38, 15);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Дата: ";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(102, 90);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(71, 15);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Заголовок: ";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(102, 120);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(42, 15);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Текст: ";
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(96, 154);
            this.textBoxReply.Multiline = true;
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(418, 23);
            this.textBoxReply.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(97, 228);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 36);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(268, 228);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(246, 36);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelReply
            // 
            this.labelReply.AutoSize = true;
            this.labelReply.Location = new System.Drawing.Point(22, 157);
            this.labelReply.Name = "labelReply";
            this.labelReply.Size = new System.Drawing.Size(38, 15);
            this.labelReply.TabIndex = 7;
            this.labelReply.Text = "Ответ";
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 335);
            this.Controls.Add(this.labelReply);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxReply);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelSenderName);
            this.Name = "FormMessage";
            this.Text = "FormMessage";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.TextBox textBoxReply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelReply;
    }
}