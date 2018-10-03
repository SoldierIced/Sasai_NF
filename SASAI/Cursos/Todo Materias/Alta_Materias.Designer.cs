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
            this.n1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.n2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.n1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_altaMateria
            // 
            this.btn_altaMateria.Location = new System.Drawing.Point(77, 190);
            this.btn_altaMateria.Name = "btn_altaMateria";
            this.btn_altaMateria.Size = new System.Drawing.Size(157, 32);
            this.btn_altaMateria.TabIndex = 19;
            this.btn_altaMateria.Text = "Crear Materia";
            this.btn_altaMateria.UseVisualStyleBackColor = true;
            this.btn_altaMateria.Click += new System.EventHandler(this.btn_altaMateria_Click);
            // 
            // lbl_precio_M_Alta
            // 
            this.lbl_precio_M_Alta.AutoSize = true;
            this.lbl_precio_M_Alta.Location = new System.Drawing.Point(12, 44);
            this.lbl_precio_M_Alta.Name = "lbl_precio_M_Alta";
            this.lbl_precio_M_Alta.Size = new System.Drawing.Size(116, 13);
            this.lbl_precio_M_Alta.TabIndex = 18;
            this.lbl_precio_M_Alta.Text = "Precio de la Materia  ->";
            // 
            // txb_PrecioM
            // 
            this.txb_PrecioM.Location = new System.Drawing.Point(151, 44);
            this.txb_PrecioM.Name = "txb_PrecioM";
            this.txb_PrecioM.Size = new System.Drawing.Size(133, 20);
            this.txb_PrecioM.TabIndex = 17;
            // 
            // lbl_nombre_M_Alta
            // 
            this.lbl_nombre_M_Alta.AutoSize = true;
            this.lbl_nombre_M_Alta.Location = new System.Drawing.Point(12, 9);
            this.lbl_nombre_M_Alta.Name = "lbl_nombre_M_Alta";
            this.lbl_nombre_M_Alta.Size = new System.Drawing.Size(120, 13);
            this.lbl_nombre_M_Alta.TabIndex = 16;
            this.lbl_nombre_M_Alta.Text = "Nombre de la Materia ->";
            // 
            // txb_NombreM
            // 
            this.txb_NombreM.Location = new System.Drawing.Point(151, 6);
            this.txb_NombreM.Name = "txb_NombreM";
            this.txb_NombreM.Size = new System.Drawing.Size(133, 20);
            this.txb_NombreM.TabIndex = 15;
            // 
            // n1
            // 
            this.n1.Location = new System.Drawing.Point(181, 80);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(87, 20);
            this.n1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cantidad de Parciales:";
            // 
            // n2
            // 
            this.n2.Location = new System.Drawing.Point(181, 110);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(87, 20);
            this.n2.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cantidad de Recuperatorios:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Cantidad de Finales:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(19, 20);
            this.textBox1.TabIndex = 36;
            this.textBox1.Text = "1";
            // 
            // Alta_Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 257);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_altaMateria);
            this.Controls.Add(this.lbl_precio_M_Alta);
            this.Controls.Add(this.txb_PrecioM);
            this.Controls.Add(this.lbl_nombre_M_Alta);
            this.Controls.Add(this.txb_NombreM);
            this.Name = "Alta_Materias";
            this.Text = "Alta_Materias";
            this.Load += new System.EventHandler(this.Alta_Materias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.n1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_altaMateria;
        private System.Windows.Forms.Label lbl_precio_M_Alta;
        private System.Windows.Forms.TextBox txb_PrecioM;
        private System.Windows.Forms.Label lbl_nombre_M_Alta;
        private System.Windows.Forms.TextBox txb_NombreM;
        private System.Windows.Forms.NumericUpDown n1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown n2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}