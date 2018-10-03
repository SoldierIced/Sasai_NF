namespace SASAI
{
    partial class InteresadoEspecifico
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
            this.lb_Apellido = new System.Windows.Forms.Label();
            this.tb_Apellido = new System.Windows.Forms.TextBox();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            this.lb_nombre = new System.Windows.Forms.Label();
            this.lb_top = new System.Windows.Forms.Label();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.lb_email = new System.Windows.Forms.Label();
            this.bt_Aceptar = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Apellido
            // 
            this.lb_Apellido.AutoSize = true;
            this.lb_Apellido.Location = new System.Drawing.Point(49, 118);
            this.lb_Apellido.Name = "lb_Apellido";
            this.lb_Apellido.Size = new System.Drawing.Size(44, 13);
            this.lb_Apellido.TabIndex = 75;
            this.lb_Apellido.Text = "Apellido";
            // 
            // tb_Apellido
            // 
            this.tb_Apellido.Location = new System.Drawing.Point(96, 115);
            this.tb_Apellido.Name = "tb_Apellido";
            this.tb_Apellido.Size = new System.Drawing.Size(220, 20);
            this.tb_Apellido.TabIndex = 74;
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.Location = new System.Drawing.Point(96, 92);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(220, 20);
            this.tb_Nombre.TabIndex = 73;
            // 
            // lb_nombre
            // 
            this.lb_nombre.AutoSize = true;
            this.lb_nombre.Location = new System.Drawing.Point(49, 95);
            this.lb_nombre.Name = "lb_nombre";
            this.lb_nombre.Size = new System.Drawing.Size(44, 13);
            this.lb_nombre.TabIndex = 72;
            this.lb_nombre.Text = "Nombre";
            // 
            // lb_top
            // 
            this.lb_top.AutoSize = true;
            this.lb_top.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_top.Location = new System.Drawing.Point(46, 18);
            this.lb_top.Name = "lb_top";
            this.lb_top.Size = new System.Drawing.Size(292, 31);
            this.lb_top.TabIndex = 71;
            this.lb_top.Text = "Detalles del Interesado";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(96, 67);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(220, 20);
            this.tb_Email.TabIndex = 69;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Location = new System.Drawing.Point(51, 70);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(42, 13);
            this.lb_email.TabIndex = 67;
            this.lb_email.Text = "EMAIL:";
            // 
            // bt_Aceptar
            // 
            this.bt_Aceptar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_Aceptar.Location = new System.Drawing.Point(203, 150);
            this.bt_Aceptar.Name = "bt_Aceptar";
            this.bt_Aceptar.Size = new System.Drawing.Size(135, 23);
            this.bt_Aceptar.TabIndex = 77;
            this.bt_Aceptar.Text = "ACEPTAR CAMBIOS";
            this.bt_Aceptar.UseVisualStyleBackColor = true;
            this.bt_Aceptar.Click += new System.EventHandler(this.bt_Aceptar_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.ForeColor = System.Drawing.Color.Red;
            this.bt_Cancelar.Location = new System.Drawing.Point(74, 150);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 76;
            this.bt_Cancelar.Text = "CANCELAR";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            this.bt_Cancelar.Click += new System.EventHandler(this.bt_Cancelar_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(3, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 79;
            this.button1.Text = "Eliminar Registro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InteresadoEspecifico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 220);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_Aceptar);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.lb_Apellido);
            this.Controls.Add(this.tb_Apellido);
            this.Controls.Add(this.tb_Nombre);
            this.Controls.Add(this.lb_nombre);
            this.Controls.Add(this.lb_top);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.lb_email);
            this.MaximumSize = new System.Drawing.Size(411, 259);
            this.Name = "InteresadoEspecifico";
            this.Text = "InteresadoEspecifico";
            this.Load += new System.EventHandler(this.InteresadoEspecifico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Apellido;
        private System.Windows.Forms.TextBox tb_Apellido;
        private System.Windows.Forms.TextBox tb_Nombre;
        private System.Windows.Forms.Label lb_nombre;
        private System.Windows.Forms.Label lb_top;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.Button bt_Aceptar;
        private System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.Button button1;
    }
}