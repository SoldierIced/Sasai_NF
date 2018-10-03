namespace SASAI
{
    partial class Materias
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
            this.btn_Agregar_M = new System.Windows.Forms.Button();
            this.btn_Modificar_M = new System.Windows.Forms.Button();
            this.btn_Filtrar_M = new System.Windows.Forms.Button();
            this.ListadoMaterias = new System.Windows.Forms.DataGridView();
            this.lbl_ID_M = new System.Windows.Forms.Label();
            this.lbl_NOMBRE_M = new System.Windows.Forms.Label();
            this.lbl_PRECIO_M = new System.Windows.Forms.Label();
            this.txb_ID_M = new System.Windows.Forms.TextBox();
            this.txb_NOMBRE_M = new System.Windows.Forms.TextBox();
            this.txb_PRECIO_M = new System.Windows.Forms.TextBox();
            this.grp_Materias = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoMaterias)).BeginInit();
            this.grp_Materias.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Agregar_M
            // 
            this.btn_Agregar_M.Location = new System.Drawing.Point(21, 146);
            this.btn_Agregar_M.Name = "btn_Agregar_M";
            this.btn_Agregar_M.Size = new System.Drawing.Size(141, 38);
            this.btn_Agregar_M.TabIndex = 1;
            this.btn_Agregar_M.Text = "Agregar Materia";
            this.btn_Agregar_M.UseVisualStyleBackColor = true;
            this.btn_Agregar_M.Click += new System.EventHandler(this.btn_Agregar_M_Click);
            // 
            // btn_Modificar_M
            // 
            this.btn_Modificar_M.Location = new System.Drawing.Point(393, 146);
            this.btn_Modificar_M.Name = "btn_Modificar_M";
            this.btn_Modificar_M.Size = new System.Drawing.Size(141, 38);
            this.btn_Modificar_M.TabIndex = 2;
            this.btn_Modificar_M.Text = "Modificar Materia";
            this.btn_Modificar_M.UseVisualStyleBackColor = true;
            this.btn_Modificar_M.Click += new System.EventHandler(this.btn_Modificar_M_Click);
            // 
            // btn_Filtrar_M
            // 
            this.btn_Filtrar_M.Location = new System.Drawing.Point(197, 146);
            this.btn_Filtrar_M.Name = "btn_Filtrar_M";
            this.btn_Filtrar_M.Size = new System.Drawing.Size(141, 38);
            this.btn_Filtrar_M.TabIndex = 3;
            this.btn_Filtrar_M.Text = "Filtrar";
            this.btn_Filtrar_M.UseVisualStyleBackColor = true;
            this.btn_Filtrar_M.Click += new System.EventHandler(this.btn_Filtrar_M_Click);
            // 
            // ListadoMaterias
            // 
            this.ListadoMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListadoMaterias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListadoMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadoMaterias.Location = new System.Drawing.Point(37, 281);
            this.ListadoMaterias.MultiSelect = false;
            this.ListadoMaterias.Name = "ListadoMaterias";
            this.ListadoMaterias.ReadOnly = true;
            this.ListadoMaterias.Size = new System.Drawing.Size(513, 162);
            this.ListadoMaterias.TabIndex = 4;
            this.ListadoMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListadoMaterias_CellContentClick);
            // 
            // lbl_ID_M
            // 
            this.lbl_ID_M.AutoSize = true;
            this.lbl_ID_M.Location = new System.Drawing.Point(18, 35);
            this.lbl_ID_M.Name = "lbl_ID_M";
            this.lbl_ID_M.Size = new System.Drawing.Size(75, 13);
            this.lbl_ID_M.TabIndex = 5;
            this.lbl_ID_M.Text = "ID MATERIA: ";
            // 
            // lbl_NOMBRE_M
            // 
            this.lbl_NOMBRE_M.AutoSize = true;
            this.lbl_NOMBRE_M.Location = new System.Drawing.Point(194, 35);
            this.lbl_NOMBRE_M.Name = "lbl_NOMBRE_M";
            this.lbl_NOMBRE_M.Size = new System.Drawing.Size(108, 13);
            this.lbl_NOMBRE_M.TabIndex = 6;
            this.lbl_NOMBRE_M.Text = "NOMBRE MATERIA:";
            // 
            // lbl_PRECIO_M
            // 
            this.lbl_PRECIO_M.AutoSize = true;
            this.lbl_PRECIO_M.Location = new System.Drawing.Point(461, 35);
            this.lbl_PRECIO_M.Name = "lbl_PRECIO_M";
            this.lbl_PRECIO_M.Size = new System.Drawing.Size(53, 13);
            this.lbl_PRECIO_M.TabIndex = 7;
            this.lbl_PRECIO_M.Text = "PRECIO: ";
            // 
            // txb_ID_M
            // 
            this.txb_ID_M.Enabled = false;
            this.txb_ID_M.Location = new System.Drawing.Point(21, 65);
            this.txb_ID_M.Name = "txb_ID_M";
            this.txb_ID_M.Size = new System.Drawing.Size(72, 20);
            this.txb_ID_M.TabIndex = 8;
            // 
            // txb_NOMBRE_M
            // 
            this.txb_NOMBRE_M.Location = new System.Drawing.Point(162, 65);
            this.txb_NOMBRE_M.Name = "txb_NOMBRE_M";
            this.txb_NOMBRE_M.Size = new System.Drawing.Size(176, 20);
            this.txb_NOMBRE_M.TabIndex = 9;
            // 
            // txb_PRECIO_M
            // 
            this.txb_PRECIO_M.Location = new System.Drawing.Point(430, 65);
            this.txb_PRECIO_M.Name = "txb_PRECIO_M";
            this.txb_PRECIO_M.Size = new System.Drawing.Size(104, 20);
            this.txb_PRECIO_M.TabIndex = 10;
            // 
            // grp_Materias
            // 
            this.grp_Materias.AutoSize = true;
            this.grp_Materias.Controls.Add(this.txb_PRECIO_M);
            this.grp_Materias.Controls.Add(this.txb_NOMBRE_M);
            this.grp_Materias.Controls.Add(this.txb_ID_M);
            this.grp_Materias.Controls.Add(this.lbl_PRECIO_M);
            this.grp_Materias.Controls.Add(this.lbl_NOMBRE_M);
            this.grp_Materias.Controls.Add(this.lbl_ID_M);
            this.grp_Materias.Controls.Add(this.btn_Agregar_M);
            this.grp_Materias.Controls.Add(this.btn_Filtrar_M);
            this.grp_Materias.Controls.Add(this.btn_Modificar_M);
            this.grp_Materias.Location = new System.Drawing.Point(12, 25);
            this.grp_Materias.Name = "grp_Materias";
            this.grp_Materias.Size = new System.Drawing.Size(553, 203);
            this.grp_Materias.TabIndex = 11;
            this.grp_Materias.TabStop = false;
            this.grp_Materias.Text = "MATERIAS:";
            // 
            // Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 460);
            this.Controls.Add(this.grp_Materias);
            this.Controls.Add(this.ListadoMaterias);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Materias";
            this.Text = "Materias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Materias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListadoMaterias)).EndInit();
            this.grp_Materias.ResumeLayout(false);
            this.grp_Materias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Agregar_M;
        private System.Windows.Forms.Button btn_Modificar_M;
        private System.Windows.Forms.Button btn_Filtrar_M;
        private System.Windows.Forms.DataGridView ListadoMaterias;
        private System.Windows.Forms.Label lbl_ID_M;
        private System.Windows.Forms.Label lbl_NOMBRE_M;
        private System.Windows.Forms.Label lbl_PRECIO_M;
        private System.Windows.Forms.TextBox txb_ID_M;
        private System.Windows.Forms.TextBox txb_NOMBRE_M;
        private System.Windows.Forms.TextBox txb_PRECIO_M;
        private System.Windows.Forms.GroupBox grp_Materias;
    }
}