namespace SASAI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaNuevoCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosLosAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interesadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preinscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darBajaAPreinscriptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDeContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadistcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaBajaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlXUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursosToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.preinscripcionToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.estadistcasToolStripMenuItem,
            this.administradorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursoActualToolStripMenuItem,
            this.todosToolStripMenuItem,
            this.altaNuevoCursoToolStripMenuItem});
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cursosToolStripMenuItem.Text = "Cursos";
            // 
            // cursoActualToolStripMenuItem
            // 
            this.cursoActualToolStripMenuItem.Name = "cursoActualToolStripMenuItem";
            this.cursoActualToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.cursoActualToolStripMenuItem.Text = "Actual";
            this.cursoActualToolStripMenuItem.Click += new System.EventHandler(this.cursoActualToolStripMenuItem_Click);
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            this.todosToolStripMenuItem.Click += new System.EventHandler(this.todosToolStripMenuItem_Click);
            // 
            // altaNuevoCursoToolStripMenuItem
            // 
            this.altaNuevoCursoToolStripMenuItem.Name = "altaNuevoCursoToolStripMenuItem";
            this.altaNuevoCursoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.altaNuevoCursoToolStripMenuItem.Text = "Alta Nuevo Curso";
            this.altaNuevoCursoToolStripMenuItem.Click += new System.EventHandler(this.altaNuevoCursoToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosLosAlumnosToolStripMenuItem,
            this.interesadosToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            this.alumnosToolStripMenuItem.Click += new System.EventHandler(this.alumnosToolStripMenuItem_Click);
            // 
            // todosLosAlumnosToolStripMenuItem
            // 
            this.todosLosAlumnosToolStripMenuItem.Name = "todosLosAlumnosToolStripMenuItem";
            this.todosLosAlumnosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.todosLosAlumnosToolStripMenuItem.Text = "Todos los Alumnos";
            this.todosLosAlumnosToolStripMenuItem.Click += new System.EventHandler(this.todosLosAlumnosToolStripMenuItem_Click);
            // 
            // interesadosToolStripMenuItem
            // 
            this.interesadosToolStripMenuItem.Name = "interesadosToolStripMenuItem";
            this.interesadosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.interesadosToolStripMenuItem.Text = "Interesados";
            this.interesadosToolStripMenuItem.Click += new System.EventHandler(this.interesadosToolStripMenuItem_Click_1);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materiasToolStripMenuItem1,
            this.especialidadesToolStripMenuItem});
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.materiasToolStripMenuItem.Text = "Carreras";
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.materiasToolStripMenuItem_Click);
            // 
            // materiasToolStripMenuItem1
            // 
            this.materiasToolStripMenuItem1.Name = "materiasToolStripMenuItem1";
            this.materiasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.materiasToolStripMenuItem1.Text = "Materias";
            this.materiasToolStripMenuItem1.Click += new System.EventHandler(this.materiasToolStripMenuItem1_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Enabled = false;
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.ShowShortcutKeys = false;
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // preinscripcionToolStripMenuItem
            // 
            this.preinscripcionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.darBajaAPreinscriptosToolStripMenuItem});
            this.preinscripcionToolStripMenuItem.Name = "preinscripcionToolStripMenuItem";
            this.preinscripcionToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.preinscripcionToolStripMenuItem.Text = "Preinscripcion";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.exportarToolStripMenuItem.Text = "Importar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // darBajaAPreinscriptosToolStripMenuItem
            // 
            this.darBajaAPreinscriptosToolStripMenuItem.Enabled = false;
            this.darBajaAPreinscriptosToolStripMenuItem.Name = "darBajaAPreinscriptosToolStripMenuItem";
            this.darBajaAPreinscriptosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.darBajaAPreinscriptosToolStripMenuItem.Text = "Dar Baja a Preinscriptos";
            this.darBajaAPreinscriptosToolStripMenuItem.Click += new System.EventHandler(this.darBajaAPreinscriptosToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioDeContraseñaToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cambioDeContraseñaToolStripMenuItem
            // 
            this.cambioDeContraseñaToolStripMenuItem.Name = "cambioDeContraseñaToolStripMenuItem";
            this.cambioDeContraseñaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cambioDeContraseñaToolStripMenuItem.Text = "Cambio de Contraseña";
            this.cambioDeContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambioDeContraseñaToolStripMenuItem_Click);
            // 
            // estadistcasToolStripMenuItem
            // 
            this.estadistcasToolStripMenuItem.Name = "estadistcasToolStripMenuItem";
            this.estadistcasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadistcasToolStripMenuItem.Text = "Estadisticas";
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaBajaUsuarioToolStripMenuItem,
            this.controlXUsuarioToolStripMenuItem,
            this.auditoriaToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administradorToolStripMenuItem.Text = "Administrador";
            this.administradorToolStripMenuItem.Click += new System.EventHandler(this.administradorToolStripMenuItem_Click);
            // 
            // cargaBajaUsuarioToolStripMenuItem
            // 
            this.cargaBajaUsuarioToolStripMenuItem.Name = "cargaBajaUsuarioToolStripMenuItem";
            this.cargaBajaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cargaBajaUsuarioToolStripMenuItem.Text = "Alta de usuario";
            this.cargaBajaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cargaBajaUsuarioToolStripMenuItem_Click);
            // 
            // controlXUsuarioToolStripMenuItem
            // 
            this.controlXUsuarioToolStripMenuItem.Name = "controlXUsuarioToolStripMenuItem";
            this.controlXUsuarioToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.controlXUsuarioToolStripMenuItem.Text = "Baja/modificacion usuario";
            this.controlXUsuarioToolStripMenuItem.Click += new System.EventHandler(this.controlXUsuarioToolStripMenuItem_Click);
            // 
            // auditoriaToolStripMenuItem
            // 
            this.auditoriaToolStripMenuItem.Name = "auditoriaToolStripMenuItem";
            this.auditoriaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.auditoriaToolStripMenuItem.Text = "Auditoria";
            this.auditoriaToolStripMenuItem.Click += new System.EventHandler(this.auditoriaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(755, 420);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "S.A.S.A.I";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursoActualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preinscripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDeContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadistcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaBajaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlXUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosLosAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interesadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darBajaAPreinscriptosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaNuevoCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
    }
}

