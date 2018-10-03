namespace SASAI
{
    partial class EnviarMailMasivo
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
            this.btn_EnviarMail = new System.Windows.Forms.Button();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.txb_Mail = new System.Windows.Forms.TextBox();
            this.txb_pass = new System.Windows.Forms.TextBox();
            this.txb_asunto = new System.Windows.Forms.TextBox();
            this.lbl_asunto = new System.Windows.Forms.Label();
            this.txb_Mensaje = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_EnviarMail
            // 
            this.btn_EnviarMail.Location = new System.Drawing.Point(194, 321);
            this.btn_EnviarMail.Name = "btn_EnviarMail";
            this.btn_EnviarMail.Size = new System.Drawing.Size(136, 33);
            this.btn_EnviarMail.TabIndex = 0;
            this.btn_EnviarMail.Text = "Enviar";
            this.btn_EnviarMail.UseVisualStyleBackColor = true;
            this.btn_EnviarMail.Click += new System.EventHandler(this.btn_EnviarMail_Click);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(28, 5);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(76, 13);
            this.lbl_Email.TabIndex = 1;
            this.lbl_Email.Text = "Ingrese Email: ";
            this.lbl_Email.Click += new System.EventHandler(this.lbl_Email_Click);
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(2, 33);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(102, 13);
            this.lbl_pass.TabIndex = 2;
            this.lbl_pass.Text = "Ingrese Contraseña:";
            // 
            // txb_Mail
            // 
            this.txb_Mail.Location = new System.Drawing.Point(110, 2);
            this.txb_Mail.Name = "txb_Mail";
            this.txb_Mail.Size = new System.Drawing.Size(271, 20);
            this.txb_Mail.TabIndex = 3;
            // 
            // txb_pass
            // 
            this.txb_pass.Location = new System.Drawing.Point(110, 33);
            this.txb_pass.Name = "txb_pass";
            this.txb_pass.Size = new System.Drawing.Size(271, 20);
            this.txb_pass.TabIndex = 4;
            this.txb_pass.UseSystemPasswordChar = true;
            this.txb_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_pass_KeyPress);
            // 
            // txb_asunto
            // 
            this.txb_asunto.Location = new System.Drawing.Point(110, 77);
            this.txb_asunto.Name = "txb_asunto";
            this.txb_asunto.Size = new System.Drawing.Size(271, 20);
            this.txb_asunto.TabIndex = 6;
            // 
            // lbl_asunto
            // 
            this.lbl_asunto.AutoSize = true;
            this.lbl_asunto.Location = new System.Drawing.Point(20, 80);
            this.lbl_asunto.Name = "lbl_asunto";
            this.lbl_asunto.Size = new System.Drawing.Size(84, 13);
            this.lbl_asunto.TabIndex = 5;
            this.lbl_asunto.Text = "Ingresar Asunto:";
            // 
            // txb_Mensaje
            // 
            this.txb_Mensaje.Location = new System.Drawing.Point(18, 16);
            this.txb_Mensaje.Multiline = true;
            this.txb_Mensaje.Name = "txb_Mensaje";
            this.txb_Mensaje.Size = new System.Drawing.Size(477, 186);
            this.txb_Mensaje.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_Mensaje);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 208);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MENSAJE";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(460, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(51, 28);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Emails Enviados:";
            // 
            // EnviarMailMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 378);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txb_asunto);
            this.Controls.Add(this.lbl_asunto);
            this.Controls.Add(this.txb_pass);
            this.Controls.Add(this.txb_Mail);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.btn_EnviarMail);
            this.Name = "EnviarMailMasivo";
            this.Text = "Enviar Mails";
            this.Load += new System.EventHandler(this.EnviarMailMasivo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_EnviarMail;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.TextBox txb_Mail;
        private System.Windows.Forms.TextBox txb_pass;
        private System.Windows.Forms.TextBox txb_asunto;
        private System.Windows.Forms.Label lbl_asunto;
        private System.Windows.Forms.TextBox txb_Mensaje;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}