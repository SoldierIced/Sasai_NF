namespace SASAI
{
    partial class CursoT_Filtrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CursoT_Filtrar));
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_fechaf = new System.Windows.Forms.TextBox();
            this.tb_fechai = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            resources.ApplyResources(this.btn_aceptar, "btn_aceptar");
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_nombre
            // 
            resources.ApplyResources(this.tb_nombre, "tb_nombre");
            this.tb_nombre.Name = "tb_nombre";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tb_fechaf
            // 
            resources.ApplyResources(this.tb_fechaf, "tb_fechaf");
            this.tb_fechaf.Name = "tb_fechaf";
            // 
            // tb_fechai
            // 
            resources.ApplyResources(this.tb_fechai, "tb_fechai");
            this.tb_fechai.Name = "tb_fechai";
            // 
            // CursoT_Filtrar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_fechai);
            this.Controls.Add(this.tb_fechaf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.btn_aceptar);
            this.Name = "CursoT_Filtrar";
            this.Load += new System.EventHandler(this.CursoT_Filtrar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_fechaf;
        private System.Windows.Forms.TextBox tb_fechai;
    }
}