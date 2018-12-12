using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.Office.Interop;


namespace SASAI
{
    public partial class AlumnoSelecionado : Form
    {
        int pagar = 0;
        DateTime fecha = new DateTime();
        public string Alumno { get; set; }
        public int Tabla { get; set; }
        DataSet ds;
        string consulta;
        AccesoDatos sq;
        bool analitico { get; set; }
        public AlumnoSelecionado(string alumno, int tabla = 1)
        {
            InitializeComponent();
            Alumno = alumno;

            Tabla = tabla;


        }
        public void CargarTextboxInscripto(DataSet ds)
        {
            tb_DNI.Text = ds.Tables["TablaSelecionado"].Rows[0]["DNI"].ToString();
            // tb_CodCurso.Text = ds.Tables[0].Rows[0]["UltimoCurso"].ToString();
            if (saberlegajo(tb_DNI.Text) == "-1")
            {
                tb_CodCurso.Text = "Sin legajo.";
            }
            else { tb_CodCurso.Text = saberlegajo(tb_DNI.Text); }
            
            textBox2.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["Apellido"].ToString();
            tb_Email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            tb_Telefono.Text = ds.Tables[0].Rows[0]["Telefono"].ToString();
            tb_Observaciones.Text = ds.Tables[0].Rows[0]["Observaciones"].ToString();
            tb_Fecha.Text = ds.Tables[0].Rows[0]["FechaEntregaDoc"].ToString();
        }
        public void CargarTextboxPreInscripto(DataSet ds)
        {

            tb_DNI.Text = ds.Tables[0].Rows[0]["DNI"].ToString();
            if (saberlegajo(tb_DNI.Text) == "-1")
            {
                tb_CodCurso.Text = "Sin legajo.";
            }
            else { tb_CodCurso.Text = saberlegajo(tb_DNI.Text); }
            textBox2.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["Apellido"].ToString();
            tb_Email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            tb_Telefono.Text = ds.Tables[0].Rows[0]["Telefono"].ToString();

        }
        public void CargarBoleanos(DataSet ds) {


            if (ds.Tables[0].Rows[0]["Const_Analitico"].ToString() == "True") {

                switch (ds.Tables[0].Rows[0]["TipoConst"].ToString()) {
                    case "Comprobante de alumno regular.":
                        listBox1.SelectedIndex = 0;
                        analitico = true;
                        break;
                    case "Comprobante de Titulo en tramite.":
                        listBox1.SelectedIndex = 1;
                        analitico = true;
                        break;
                    case "Comprobante de Titulo legalizado.":
                        listBox1.SelectedIndex = 2;
                        analitico = true;
                        break;
                    case "No trajo comprobante.":
                        listBox1.SelectedIndex = 3;
                        analitico = false;
                        break;
                    case "vencido.":

                        break;

                    default:
                        listBox1.SelectedIndex = 3;
                        analitico = false;
                        break;


                }




            }
            else
            {

                listBox1.SelectedIndex = 3;
                analitico = false;

            }
            if (ds.Tables[0].Rows[0]["Const_Cuil"].ToString() == "True")
            {

                cb_cuil.Checked = true;
            }
            else
            {
                cb_cuil.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["constNaci"].ToString() == "True")
            {

                cb_naci.Checked = true;
            }
            else
            {
                cb_naci.Checked = false;
            }


            if (ds.Tables[0].Rows[0]["Fotoc_DNI"].ToString() == "True")
            {

                cb_Dni.Checked = true;

            }
            else
            {
                cb_Dni.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["Foto4x4"].ToString() == "True")
            {

                cb_4x4.Checked = true;
            }
            else
            {
                cb_4x4.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["Const_Trabajo"].ToString() == "True")
            {

                cb_ConstanciaTrabajo.Checked = true;
            }
            else
            {
                cb_ConstanciaTrabajo.Checked = false;
            }


        }

         public string inscriptonumero(string codcurso,string codespe)
        {


            string cons = "select count(legajo) from AlumnosxMateriasxCursos";
            AccesoDatos da = new AccesoDatos();
            DataSet dt = new DataSet();
            da.cargaTabla("inscrip", cons, ref dt);

            cons = "select CodMateria from MateriasxCurso where CodCurso ='" + codcurso + "' and CodEspecialidad = '" + codespe + "'";

            da.cargaTabla("materiasxcurso", cons, ref dt);
            int a = int.Parse(dt.Tables["inscrip"].Rows[0][0].ToString()) ;
            a = a / dt.Tables["materiasxcurso"].Rows.Count;
           // MessageBox.Show(a.ToString());
            a++;
            return a.ToString();
            }

        
        private void AlumnoSelecionado_Load(object sender, EventArgs e)
        {
            textBox4.Visible = false;

            sq = new AccesoDatos();
            ds = new DataSet();

           
          
            if (Tabla == 1) { 
                consulta = "select DNI,Nombre,Apellido,UltimoCurso,Email,Telefono,Activo,TipoConst,Const_Analitico,Const_Cuil,Fotoc_DNI,Foto4x4,Const_Trabajo,constNaci,FechaEntregaDoc,observaciones,especialidad from Inscriptos where DNI=" + Alumno;
                sq.cargaTabla("TablaSelecionado", consulta, ref ds);
                CargarTextboxInscripto(ds);
                CargarBoleanos(ds);
                titulo.Text = "Inscripto";
            }
            else {
                consulta = "select * from Preinscriptos where DNI=" + Alumno;
                sq.cargaTabla("TablaSelecionado", consulta, ref ds);
                CargarTextboxPreInscripto(ds);
                CursarCursoActual.Checked = true;

                titulo.Text = "Preinscripto, todavia no es alumno.";

            }
            consulta = "select nombre,Codespecialidad from especialidades";
            sq.cargaTabla("CodEspe", consulta, ref ds);
            for (int i = 0; i < ds.Tables["CodEspe"].Rows.Count; i++)
               textBox3.Text=ds.Tables["CodEspe"].Rows[i][0].ToString(); ;

            //for (int i = 0; i < comboBox1.Items.Count; i++)
            //{
            //   // az(ds.Tables["CodEspe"].Rows[i][0].ToString() + "    " + ds.Tables["TablaSelecionado"].Rows[0][ds.Tables["TablaSelecionado"].Columns.Count - 1].ToString());

            //    if (ds.Tables["CodEspe"].Rows[i][1].ToString() == ds.Tables["TablaSelecionado"].Rows[0][ds.Tables["TablaSelecionado"].Columns.Count - 1].ToString())
            //    {
            //       comboBox1.SelectedIndex = i;
            //    }
            //}
           
            sq.cargaTabla("verificarsicursaelalumno", "select * from Inscriptos inner join Cursos on Cursos.CodCurso= UltimoCurso where Cursos.actual =1 and DNI=" + tb_DNI.Text, ref ds);

            try
            {
                if (ds.Tables["verificarsicursaelalumno"].Rows[0][0].ToString() != string.Empty) {
                    CursarCursoActual.Checked = true;
                }
            }
            catch (Exception ) { CursarCursoActual.Checked = false; }

            if (Tabla == 1) { apagar(1); }
            else { apagar(2); }
        }
        public void apagar(int opcion) {
            bool p = false;
            if (opcion == 1)
            {
                p = false;
            }
            else { p = true; }
            textBox1.ReadOnly = !p;
            textBox2.ReadOnly = !p;
           // tb_CodCurso.ReadOnly = !p;
            tb_DNI.ReadOnly = !p;
            tb_Email.ReadOnly = !p;
            tb_Observaciones.ReadOnly = !p;
            tb_Telefono.ReadOnly = !p;
            listBox1.Enabled = p;
                cb_4x4.Enabled = p;
                cb_ConstanciaTrabajo.Enabled = p;
                cb_cuil.Enabled = p;
                cb_Dni.Enabled = p;
                cb_naci.Enabled = p;
           // comboBox1.Enabled = p;
            CursarCursoActual.Enabled = p;
           // bt_Aceptar.Enabled = p;
          //  bt_Cancelar.Enabled = p;

        }

        public string codespe(string nombre)
        {

            for (int i = 0; i < ds.Tables["CodEspe"].Rows.Count; i++)
            {
                if (ds.Tables["CodEspe"].Rows[i][0].ToString() == nombre)
                {

                    return ds.Tables["CodEspe"].Rows[i][1].ToString();
                }
            }
            return "";
        }


            private void bt_Aceptar_Click(object sender, EventArgs e)
        {

                            try {
                                int.Parse(tb_DNI.Text);
                                     if (tb_DNI.Text != string.Empty)
                                {
                    if (listBox1.SelectedIndex >= 0)
                    {

                        switch (listBox1.Items[listBox1.SelectedIndex].ToString())
                        {

                            case "Comprobante de alumno regular.":
                                listBox1.SelectedIndex = 0;
                                analitico = true;

                                break;
                            case "Comprobante de Titulo en tramite.":
                                listBox1.SelectedIndex = 1;
                                analitico = true;

                                break;
                            case "Comprobante de Titulo legalizado.":
                                listBox1.SelectedIndex = 2;
                                analitico = true;


                                break;
                            case "No trajo comprobante.":
                                listBox1.SelectedIndex = 3;
                                analitico = false;

                                break;
                            case "vencido.":

                                break;
                            default:
                                listBox1.SelectedIndex = 3;
                                analitico = false;
                                break;


                        }




                        if (Tabla == 1)
                        {

                            fecha = DateTime.Parse(tb_Fecha.Text);

                            tb_Fecha.Text = fecha.ToString();


                            AccesoDatos aq = new AccesoDatos();

                            SqlCommand comando = new SqlCommand();

                            string codcurso = "";
                            try
                            {
                                codcurso = "select CodCurso from Cursos where actual =1";
                                AccesoDatos aff = new AccesoDatos();
                                aff.cargaTabla("5:35AM..", codcurso, ref ds);

                                codcurso = ds.Tables["5:35AM.."].Rows[0][0].ToString();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No hay curso asignado como el actual");
                            }




                            try
                            {

                                comando = DatosSP.Inscriptos(ds.Tables["TablaSelecionado"].Rows[0][0].ToString(), int.Parse(tb_DNI.Text), textBox2.Text, textBox1.Text, codcurso, tb_Email.Text, tb_Telefono.Text, true
                                                , analitico, cb_cuil.Checked, cb_Dni.Checked, cb_4x4.Checked, cb_ConstanciaTrabajo.Checked, fecha, tb_Observaciones.Text,
                                                listBox1.Items[listBox1.SelectedIndex].ToString(), cb_naci.Checked, codespe(textBox3.Text));
                                aq.EjecutarProcedimientoAlmacenado(comando, "ModificarInscripto");

                                if (CursarCursoActual.Checked == true)
                                {
                                    string asd = "select COUNT(legajo) from AlumnosxMateriasxCursos where legajo=" + saberlegajo(tb_DNI.Text)+"and codcurso="+codcurso;
                                    DataSet dt = new DataSet();
                                    aq.cargaTabla("queseyo222", asd, ref dt);
                                    if (dt.Tables["queseyo222"].Rows[0][0].ToString() == "0") { CargaCursoAcutal(); }
                                }
                                MessageBox.Show("Alumno modificado correctamente");

                                apagar(1);
                                //this.Close();
                            }
                            catch (Exception ex)
                            {
                                //     az(ex.ToString());
                            }



                        }
                        else
                        {
                            AccesoDatos aq = new AccesoDatos();

                            SqlCommand comando = new SqlCommand();

                            DateTime fecha = new DateTime();
                            fecha = DateTime.Today;
                            tb_Fecha.Text = fecha.ToString();
                            string codcurso = "";
                            int error = 0;
                            try
                            {
                                codcurso = "select CodCurso from Cursos where actual =1";
                                AccesoDatos aff = new AccesoDatos();
                                aff.cargaTabla("5:35AM..", codcurso, ref ds);

                                codcurso = ds.Tables["5:35AM.."].Rows[0][0].ToString();
                                error = 1;

                                comando = DatosSP.Inscriptos(ds.Tables["TablaSelecionado"].Rows[0][0].ToString(), int.Parse(tb_DNI.Text), textBox2.Text, textBox1.Text, codcurso, tb_Email.Text, tb_Telefono.Text, true
                                       , analitico,
                                    cb_cuil.Checked, cb_Dni.Checked, cb_4x4.Checked, cb_ConstanciaTrabajo.Checked, fecha, tb_Observaciones.Text,
                                    listBox1.Items[listBox1.SelectedIndex].ToString(), cb_naci.Checked, codespe(textBox3.Text));
                                // aq.EjecutarProcedimientoAlmacenado(comando, "ModificarInscripto");
                                aq.EjecutarProcedimientoAlmacenado(comando, "CargaInscripto");

                                if (CursarCursoActual.Checked == true)
                                {
                                    string asd = "select COUNT(legajo) from AlumnosxMateriasxCursos where legajo=" + saberlegajo(tb_DNI.Text);
                                    DataSet dt = new DataSet();
                                    aq.cargaTabla("queseyo222", asd, ref dt);
                                    if (dt.Tables["queseyo222"].Rows[0][0].ToString() == "0") { CargaCursoAcutal(); }



                                }


                                MessageBox.Show("Alumno Inscripto correctamente.");
                                apagar(1);

                                //  this.Close();
                            }
                            catch (Exception ex)
                            {
                                if (error == 0)
                                    MessageBox.Show("No hay un curso asignado como el actual.");
                                else
                                {
                                         MessageBox.Show(ex.ToString());
                                }

                            }
                        }

                    }
                    else {
                        MessageBox.Show("Debe seleccionar un comprobante.");
                        textBox4.Visible = true;
                    }

                                }
                                else
                                {
                                    az("El campo DNI esta mal.");
                                }


            }
            catch (Exception ex) {
           //     az(ex.ToString());
            }
           



        }


        public int verificarAprobadaMateria(string codmaa,string legajo,string idinscripto,
            string codcurso,string modalidad,string turno,string fecha) {
            SqlCommand comando = new SqlCommand();
            AccesoDatos aq = new AccesoDatos();
            //( @legajo int ,@codmateria varchar (40) , @idinscripto int,@codcurso varchar(40)
            //,@modalidad varchar(120),@turno varchar(120),@user varchar(120) )
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@legajo", SqlDbType.Int);
            SqlParametros.Value = legajo;
            SqlParametros = comando.Parameters.Add("@codmateria", SqlDbType.NVarChar, 40);
            SqlParametros.Value = codmaa;
            SqlParametros = comando.Parameters.Add("@idinscripto", SqlDbType.NVarChar, 40);
            SqlParametros.Value =idinscripto;
            SqlParametros = comando.Parameters.Add("@codcurso", SqlDbType.NVarChar, 40);
            SqlParametros.Value = codcurso;
            SqlParametros = comando.Parameters.Add("@modalidad", SqlDbType.NVarChar, 40);
            SqlParametros.Value = modalidad;
            SqlParametros = comando.Parameters.Add("@turno", SqlDbType.NVarChar, 40);
            SqlParametros.Value = turno;
            SqlParametros = comando.Parameters.Add("@user", SqlDbType.NVarChar, 40);
            SqlParametros.Value = Formularios.Usuario;
            SqlParametros = comando.Parameters.Add("@fechita", SqlDbType.Date);
            SqlParametros.Value = fecha;
            aq.ConfigurarProcedure(ref comando, "VerificarMateriaPosta");
            comando.Connection = aq.ObtenerConexion();
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
              return  int.Parse(reader[0].ToString());
                
                    
                    

                

            }

            return -1;
        }

        public void az(string val) { MessageBox.Show(val); }
        public int sabermontomateria(string codmateria) {
            AccesoDatos aq = new AccesoDatos();
            int aux = 0;
            
            string consulta = "select monto from materias where codmateria='" + codmateria + "'";
          
            aq.cargaTabla("montomateria", consulta, ref ds);
            string doble = ds.Tables["montomateria"].Rows[0][0].ToString();
            decimal doblesss = Convert.ToDecimal(doble);
            int number = Decimal.ToInt32(doblesss);
            
            return number;

       }
        public void CargaCursoAcutal() {
            consulta = "";
            AccesoDatos aq = new AccesoDatos();
            DataSet ar = new DataSet();
            string codespe = "";
            string codcurso = "";
            string fecha_venci = "";
            string[] materias;
           
            try {
                // primero saber la especialidad que esta en la tabla que fue cargada en el load
              //  MessageBox.Show(ds.Tables["TablaSelecionado"].Rows[0][ds.Tables["TablaSelecionado"].Columns.Count - 1].ToString());
                 codespe = ds.Tables["TablaSelecionado"].Rows[0][ds.Tables["TablaSelecionado"].Columns.Count - 1].ToString();
            } catch (Exception ex ) {

//                MessageBox.Show(ex.ToString());
            }
            //saber el curso acutual de dicha especialidad
            //esto devuelve el curso actual..de dicha especialidad
            try
            {
           

            consulta = "select * from Cursos inner join EspecialidadesXCursos on cursos.CodCurso=EspecialidadesXCursos.CodCurso" +
                " where EspecialidadesXCursos.CodEspecialidad='" + codespe + "' and Cursos.actual=1 ";
             //  MessageBox.Show(consulta);
                aq.cargaTabla("cursoespecifico", consulta, ref ar);
             codcurso = ar.Tables["cursoespecifico"].Rows[0][0].ToString();
             fecha_venci = ar.Tables["cursoespecifico"].Rows[0][2].ToString();
                DateTime a = new DateTime();
               a= DateTime.Parse(fecha_venci);
               fecha_venci= a.ToShortDateString();
                     }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }


            //saber las materias que tiene  dicho curso
            try
            {
                consulta = "select CodMateria from MateriasxCurso where CodCurso ='" + codcurso + "' and CodEspecialidad = '" + codespe+"'";
                aq.cargaTabla("materiasxcurso", consulta, ref ar);
            }
            //vector de materias del curso actual

            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
             
            }

            materias = new string[ar.Tables["materiasxcurso"].Rows.Count];
                for (int i = 0; i < ar.Tables["materiasxcurso"].Rows.Count; i++)
                {
                    materias[i] = ar.Tables["materiasxcurso"].Rows[i][0].ToString();
                }

            //verificar que el alumno no haya cursado anteriormente dichas materias
            // y que las tenga aprobadas..

            //saber legajo  del alumno.
            consulta = "select legajo from inscriptos where dni ='" + tb_DNI.Text + "'";
            aq.cargaTabla("123123", consulta, ref ds);

            for (int i = 0; i < ar.Tables["materiasxcurso"].Rows.Count; i++) {

                try {
                    Alumnos.inscripcionmaterias im = new Alumnos.inscripcionmaterias(materias[i]);
                    if (im.ShowDialog() == DialogResult.OK)
                    {

                        verificarAprobadaMateria(materias[i], ds.Tables["123123"].Rows[0][0].ToString(),
                            inscriptonumero(codcurso, "001"), codcurso, im.modalidad, im.turno,fecha_venci);


                    }
                    else
                    {
                        verificarAprobadaMateria(materias[i], ds.Tables["123123"].Rows[0][0].ToString(),
                               inscriptonumero(codcurso, "001"), codcurso, "MODALIDAD NO CARGADA", "TURNO NO CARGADO", fecha_venci);

                    }
                } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                


                }
            }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_cuil_CheckedChanged(object sender, EventArgs e)
        {

        }

       public string sabernombrecurso(string codc) {

            string a = "select NombreCurso from cursos where codcurso='" + codc + "'";
            DataSet dq = new DataSet();
            AccesoDatos ag = new AccesoDatos();
            ag.cargaTabla("blabla", a, ref dq);
      return      dq.Tables["blabla"].Rows[0][0].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           tb_Fecha.Text = DateTime.Today.ToString();
        }

        public string saberlegajo(string dni) {
            try
            {
                string aw = "select legajo from inscriptos where DNI=" + dni;
                DataSet dr = new DataSet();
                AccesoDatos aq = new AccesoDatos();
                aq.cargaTabla("a0", aw, ref dr);
                if (dr.Tables["a0"].Rows[0][0].ToString() != string.Empty) { 
                    return dr.Tables["a0"].Rows[0][0].ToString();
                }
                else { return "-1"; }
            }
            catch (Exception ) { return "-1"; }
           

        }

        private void cursadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            Alumnos.CursadaAlumno ac = new Alumnos.CursadaAlumno(textBox2.Text,textBox1.Text,saberlegajo(tb_DNI.Text));
            Formularios.AbrirFormularioHijos(ac);
        }

        private void matricularACursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void editarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pagar != 2)
            {
                pagar = 2;
                apagar(pagar);
            }
            else { pagar = 1; apagar(1); }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
