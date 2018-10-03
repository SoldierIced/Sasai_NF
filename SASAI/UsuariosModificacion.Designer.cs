namespace SASAI
{
    partial class UsuariosModificacion
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
            this.lbl_ModPass = new System.Windows.Forms.Label();
            this.tbx_passAnterior = new System.Windows.Forms.TextBox();
            this.tbx_passNueva = new System.Windows.Forms.TextBox();
            this.tbx_passNuevaConfirm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_passAnterior = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ModPass
            // 
            this.lbl_ModPass.AutoSize = true;
            this.lbl_ModPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ModPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ModPass.Location = new System.Drawing.Point(134, 9);
            this.lbl_ModPass.Name = "lbl_ModPass";
            this.lbl_ModPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ModPass.Size = new System.Drawing.Size(294, 33);
            this.lbl_ModPass.TabIndex = 0;
            this.lbl_ModPass.Text = "Modificar Contraseña";
            // 
            // tbx_passAnterior
            // 
            this.tbx_passAnterior.Location = new System.Drawing.Point(175, 74);
            this.tbx_passAnterior.Name = "tbx_passAnterior";
            this.tbx_passAnterior.Size = new System.Drawing.Size(220, 20);
            this.tbx_passAnterior.TabIndex = 1;
            // 
            // tbx_passNueva
            // 
            this.tbx_passNueva.Location = new System.Drawing.Point(174, 189);
            this.tbx_passNueva.Name = "tbx_passNueva";
            this.tbx_passNueva.Size = new System.Drawing.Size(220, 20);
            this.tbx_passNueva.TabIndex = 2;
            // 
            // tbx_passNuevaConfirm
            // 
            this.tbx_passNuevaConfirm.Location = new System.Drawing.Point(173, 235);
            this.tbx_passNuevaConfirm.Name = "tbx_passNuevaConfirm";
            this.tbx_passNuevaConfirm.Size = new System.Drawing.Size(232, 20);
            this.tbx_passNuevaConfirm.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(213, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "CONFIRMAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_passAnterior
            // 
            this.lbl_passAnterior.AutoSize = true;
            this.lbl_passAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_passAnterior.Location = new System.Drawing.Point(171, 51);
            this.lbl_passAnterior.Name = "lbl_passAnterior";
            this.lbl_passAnterior.Size = new System.Drawing.Size(224, 20);
            this.lbl_passAnterior.TabIndex = 5;
            this.lbl_passAnterior.Text = "Ingrese Contraseña Actual";
            this.lbl_passAnterior.Click += new System.EventHandler(this.lbl_passAnterior_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ingrese Contraseña Nueva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Confirme Contraseña Nueva";
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_passAnterior);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbx_passNuevaConfirm);
            this.Controls.Add(this.tbx_passNueva);
            this.Controls.Add(this.tbx_passAnterior);
            this.Controls.Add(this.lbl_ModPass);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ModPass;
        private System.Windows.Forms.TextBox tbx_passAnterior;
        private System.Windows.Forms.TextBox tbx_passNueva;
        private System.Windows.Forms.TextBox tbx_passNuevaConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_passAnterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}