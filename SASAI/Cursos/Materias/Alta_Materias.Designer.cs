namespace SASAI
{
    partial class Alta_Materias
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
            this.btn_altaMateria = new System.Windows.Forms.Button();
            this.lbl_precio_M_Alta = new System.Windows.Forms.Label();
            this.txb_PrecioM = new System.Windows.Forms.TextBox();
            this.lbl_nombre_M_Alta = new System.Windows.Forms.Label();
            this.txb_NombreM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_altaMateria
            // 
            this.btn_altaMateria.Location = new System.Drawing.Point(97, 116);
            this.btn_altaMateria.Name = "btn_altaMateria";
            this.btn_altaMateria.Size = new System.Drawing.Size(157, 32);
            this.btn_altaMateria.TabIndex = 14;
            this.btn_altaMateria.Text = "Crear Materia";
            this.btn_altaMateria.UseVisualStyleBackColor = true;
            this.btn_altaMateria.Click += new System.EventHandler(this.btn_altaMateria_Click);
            // 
            // lbl_precio_M_Alta
            // 
            this.lbl_precio_M_Alta.AutoSize = true;
            this.lbl_precio_M_Alta.Location = new System.Drawing.Point(26, 71);
            this.lbl_precio_M_Alta.Name = "lbl_precio_M_Alta";
            this.lbl_precio_M_Alta.Size = new System.Drawing.Size(116, 13);
            this.lbl_precio_M_Alta.TabIndex = 13;
            this.lbl_precio_M_Alta.Text = "Precio de la Materia  ->";
            // 
            // txb_PrecioM
            // 
            this.txb_PrecioM.Location = new System.Drawing.Point(165, 71);
            this.txb_PrecioM.Name = "txb_PrecioM";
            this.txb_PrecioM.Size = new System.Drawing.Size(133, 20);
            this.txb_PrecioM.TabIndex = 12;
            // 
            // lbl_nombre_M_Alta
            // 
            this.lbl_nombre_M_Alta.AutoSize = true;
            this.lbl_nombre_M_Alta.Location = new System.Drawing.Point(26, 36);
            this.lbl_nombre_M_Alta.Name = "lbl_nombre_M_Alta";
            this.lbl_nombre_M_Alta.Size = new System.Drawing.Size(120, 13);
            this.lbl_nombre_M_Alta.TabIndex = 11;
            this.lbl_nombre_M_Alta.Text = "Nombre de la Materia ->";
            // 
            // txb_NombreM
            // 
            this.txb_NombreM.Location = new System.Drawing.Point(165, 33);
            this.txb_NombreM.Name = "txb_NombreM";
            this.txb_NombreM.Size = new System.Drawing.Size(133, 20);
            this.txb_NombreM.TabIndex = 10;
            // 
            // Alta_Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 180);
            this.Controls.Add(this.btn_altaMateria);
            this.Controls.Add(this.lbl_precio_M_Alta);
            this.Controls.Add(this.txb_PrecioM);
            this.Controls.Add(this.lbl_nombre_M_Alta);
            this.Controls.Add(this.txb_NombreM);
            this.Name = "Alta_Materias";
            this.Text = "Alta_Materias";
            this.Load += new System.EventHandler(this.Alta_Materias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_altaMateria;
        private System.Windows.Forms.Label lbl_precio_M_Alta;
        private System.Windows.Forms.TextBox txb_PrecioM;
        private System.Windows.Forms.Label lbl_nombre_M_Alta;
        private System.Windows.Forms.TextBox txb_NombreM;
    }
}