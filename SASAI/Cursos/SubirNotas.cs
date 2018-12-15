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

namespace SASAI.Cursos
{
    public partial class SubirNotas : Form
    {
        public string codmateria = "";
        public string codcurso = "";
        public string codespe = "";
        AccesoDatos aq = new AccesoDatos();
        SqlCommand comando = new SqlCommand();
        DataSet ds = new DataSet();
        void az(string val) { MessageBox.Show(val); }
        string consulta = "";
        public SubirNotas(string codmateriaa, string codcursoo, string codespee)
        {
            InitializeComponent();

            codmateria = codmateriaa;
            codcurso = codcursoo;
            codespe = codespee;



        }
        public void agregarcolumnasdata() {
            dataGridView1.Columns.Add("Legajo", "Legajo");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns["Legajo"].ReadOnly = true;
            dataGridView1.Columns["Nombre"].ReadOnly = true;
            dataGridView1.Columns["Apellido"].ReadOnly = true;

            //los parciales
            string consulta = "select * from Materias select CantPar,CantRec from Materias inner join MateriasxCurso as mc on Materias.CodMateria= mc.CodMateria where mc.CodCurso = '"+codcurso+"'  and mc.CodEspecialidad ='"+codespe+"' and Materias.CodMateria = '"+codmateria+"'";
            aq.cargaTabla("materiasCant", consulta, ref ds);

            for (int i = 0; i < int.Parse(ds.Tables["materiasCant"].Rows[0]["CantPar"].ToString()); i++) {
                dataGridView1.Columns.Add("Parcial " + (i + 1), "Parcial " + (i + 1));

            }
            //los recuperatorios
            for (int i = 0; i < int.Parse(ds.Tables["materiasCant"].Rows[0]["CantRec"].ToString()); i++)
            {
                dataGridView1.Columns.Add("Recuperatorio " + (i + 1), "Recuperatorio " + (i + 1));
               
            }

            // la nota final
            dataGridView1.Columns.Add("Nota Final", "Nota Final");
            dataGridView1.Columns.Add("Modalidad", "Modalidad");
            dataGridView1.Columns.Add("Turno", "Turno");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns["Email"].ReadOnly = true;
        }
        public void CargarDatos() {
           // az(codespe);
            consulta = "select al.legajo,Nombre,Apellido,notaparcial,tipoNota from NotasxMateriaXalumnoxCurso as al inner join Inscriptos on al.legajo=Inscriptos.legajo where al.Codcurso = '"+codcurso+"' and al.codespecialidad = '"+codespe+"' and al.CodMateria = '"+codmateria+"'";

            aq.cargaTabla("CargaDatos", consulta, ref ds);


            consulta = "select al.legajo,NotaMateria,MontoaPagar,modalidad,turno,Nombre,Apellido,Email from AlumnosxMateriasxCursos as al inner join Inscriptos on al.legajo=Inscriptos.legajo where al.Codcurso='" + codcurso + "' and al.CodEspecialidad='" + codespe + "' and al.CodMateria='" + codmateria + "'";
            aq.cargaTabla("Datos", consulta, ref ds);
            int cont = 0;
         //   dataGridView1.Rows.Add();
         
            for (int i = 0; i < ds.Tables["Datos"].Rows.Count; i++)
            {
                try {
                 //   MessageBox.Show(ds.Tables["Datos"].Rows[i][0].ToString());
                    int pos = verificardata(ds.Tables["Datos"].Rows[i][0].ToString(), 0);
                    if (pos == -1)
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[cont].Cells["Legajo"].Value = ds.Tables["Datos"].Rows[i]["legajo"].ToString();
                        dataGridView1.Rows[cont].Cells["Nombre"].Value = ds.Tables["Datos"].Rows[i]["Nombre"].ToString();
                        dataGridView1.Rows[cont].Cells["Apellido"].Value = ds.Tables["Datos"].Rows[i]["Apellido"].ToString();
                        dataGridView1.Rows[cont].Cells["Modalidad"].Value = ds.Tables["Datos"].Rows[i]["modalidad"].ToString();
                       // MessageBox.Show(ds.Tables["Datos"].Rows[i]["modalidad"].ToString());
                        dataGridView1.Rows[cont].Cells["Turno"].Value = ds.Tables["Datos"].Rows[i]["turno"].ToString();
                        dataGridView1.Rows[cont].Cells["Nota Final"].Value = ds.Tables["Datos"].Rows[i]["NotaMateria"].ToString();
                        dataGridView1.Rows[cont].Cells["Email"].Value = ds.Tables["Datos"].Rows[i]["Email"].ToString();
                        
                       // dataGridView1.Rows[cont].Cells[ds.Tables["CargaDatos"].Rows[i]["tiponota"].ToString()].Value = ds.Tables["CargaDatos"].Rows[i]["notaparcial"].ToString();
                        cont++;
                    }
                    else
                    {
                       // dataGridView1.Rows[pos].Cells[ds.Tables["CargaDatos"].Rows[i]["tiponota"].ToString()].Value = ds.Tables["CargaDatos"].Rows[i]["notaparcial"].ToString();
                    }
                } catch (Exception ex) {

                  //  az(ex.ToString());
                }
               
               
            }
            cont = 0;
            for (int i = 0; i < ds.Tables["CargaDatos"].Rows.Count; i++) {

                try
                {

                    // dataGridView1.Rows[cont].Cells[ds.Tables["CargaDatos"].Rows[i]["tiponota"].ToString()].Value = ds.Tables["CargaDatos"].Rows[i]["notaparcial"].ToString();
                    //  MessageBox.Show(ds.Tables["CargaDatos"].Rows[i]["legajo"].ToString() + "   " + dataGridView1.Rows[cont].Cells["Legajo"].Value.ToString() + "  " + cont + "  "+ds.Tables["CargaDatos"].Rows[i]["tiponota"].ToString()+"  "+ ds.Tables["CargaDatos"].Rows[i]["notaparcial"].ToString());

                    if (verificardata(ds.Tables["CargaDatos"].Rows[i]["legajo"].ToString(), 0) != -1)
                    {
                        cont = verificardata(ds.Tables["CargaDatos"].Rows[i]["legajo"].ToString(), 0);
                        dataGridView1.Rows[cont].Cells[ds.Tables["CargaDatos"].Rows[i]["tiponota"].ToString()].Value = ds.Tables["CargaDatos"].Rows[i]["notaparcial"].ToString();
                    
                    }
                    
                }
                catch (Exception ex)
                {

                   // az(ex.ToString());
                }
            }

            //falta la carga de las notas de cada alumno.

            cargadedatosok = true;
        }
        public bool cargadedatosok = false;
    
        public int verificardata(string val,int column) {

            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                try {
                   // MessageBox.Show(val+"  "+dataGridView1.Rows[i].Cells[column].Value.ToString());
                    if (val == dataGridView1.Rows[i].Cells[column].Value.ToString()) { return i; }
                } catch (Exception ex) {
                 //   MessageBox.Show(ex.ToString());
                }
               

            }
            return -1;
        }

        private void SubirNotas_Load(object sender, EventArgs e)
        {
            try {
                consulta = "select al.legajo,NombreMateria,Monto,Nombre,Apellido,CantPar,CantRec,NotaMateria,modalidad,turno from Materias inner join AlumnosxMateriasxCursos as al on Materias.CodMateria = al.CodMateria inner join inscriptos on al.legajo = Inscriptos.legajo where Materias.CodMateria = '" + codmateria + "'";
             //   az(consulta);
                aq.cargaTabla("Tablainicial", consulta, ref ds);
                textBox1.Text = ds.Tables["Tablainicial"].Rows[0][1].ToString();
               agregarcolumnasdata();
                CargarDatos();
            }
            catch (Exception ex) {
                //az(ex.ToString());
            }

        }
        public string sabercodmateria(string name)
        {

            for (int i = 0; i < ds.Tables["cantmaterias"].Rows.Count; i++)
            {
                if (ds.Tables["cantmaterias"].Rows[i][1].ToString() == name)
                {
                    return ds.Tables["cantmaterias"].Rows[i][0].ToString();
                }

            }
            return "";
        }
        public void cargarnota(int cell, int row)
        {
            if (sabercodmateria(dataGridView1.Columns[cell].HeaderText) != "")
            {
                string codmate = sabercodmateria(dataGridView1.Columns[cell].HeaderText);
                string codespe = "001";
                SqlCommand comando = new SqlCommand();

                DatosSP.Notasp(ref comando, codcurso, codmate, codespe, dataGridView1.Rows[row].Cells[cell].Value.ToString(), int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString()));
                aq.ConfigurarProcedure(ref comando, "UpdateNotas2");
                comando.Connection = aq.ObtenerConexion();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                { }

            }
        }









        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            int cell = dataGridView1.CurrentCell.ColumnIndex;
            try
            {

                if (dataGridView1.Columns[cell].HeaderText.Contains("Parcial") == true|| dataGridView1.Columns[cell].HeaderText.Contains("Recuper")) {
                    if (int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) <= 10 &&
            int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) >= 0)
                    {

                        SqlCommand comando = new SqlCommand();
                       // MessageBox.Show(dataGridView1.Columns[cell].HeaderText);
                        DatosSP.Notasp(ref comando, codcurso, codmateria, codespe, dataGridView1.Rows[row].Cells[cell].Value.ToString(), int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString()));
                        DatosSP.Notas_tiponota(ref comando, dataGridView1.Columns[cell].HeaderText);
                        aq.ConfigurarProcedure(ref comando, "updatenotaparciales");
                        comando.Connection = aq.ObtenerConexion();

                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        { }


                    }
                    else {az("Recuerde que las notas deben ser del 0 al 10, las notas que no cumplan esa regla no seran guardadas."); }

                }
            }
            catch (Exception) { MessageBox.Show("Solo se permiten numeros en esa celda."); }

            bool guardarNotaf = true;
            //if (dataGridView1.Columns[cell].HeaderText.Contains("Nota Final") == true) {
            //    if (int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) > 10 ||
            //    int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) < 0) {
            //        guardarNotaf = false;
            //        az("Recuerde que las notas deben ser del 0 al 10, las notas que no cumplan esa regla no seran guardadas.");
            //    }
            //}
            if (dataGridView1.Columns[cell].HeaderText.Contains("Nota Final") == true) {
            if (dataGridView1.Rows[row].Cells[cell].Value.ToString() == "EQUIVALENCIA" ||
                          dataGridView1.Rows[row].Cells[cell].Value.ToString() == "equivalencia")

            {
                // cargarnota(cell, row);
                guardarNotaf = true;
            }
            else
            {
                    try {
                        if (int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) <= 10 &&
int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) >= 0)
                        {
                            //  cargarnota(cell, row);
                            guardarNotaf = true;
                        }
                        else { az("Recuerde que las notas van del 0 al 10"); }
                    } catch (Exception) {
                        az("Recuerde que las notas van del 0 al 10, o equivalencia/EQUIVALENCIA.");
                    }
                

            }

            }
            if (dataGridView1.Columns[cell].HeaderText == "Modalidad") {
                
                if (dataGridView1.Rows[row].Cells[cell].Value.ToString().ToUpper()!="PRESENCIAL" && dataGridView1.Rows[row].Cells[cell].Value.ToString().ToUpper() != "LIBRE")
                    //|| dataGridView1.Rows[row].Cells[cell].Value.ToString() != "LIBRE")
                {
                    guardarNotaf = false;
                    az("Las modalidades tienen que ser: PRESENCIAL  o  LIBRE");
                }
                else {  }
                
            }
            if (dataGridView1.Columns[cell].HeaderText == "Turno")
            {
                if (dataGridView1.Rows[row].Cells[cell].Value.ToString() == "NOCHE" ||
                    dataGridView1.Rows[row].Cells[cell].Value.ToString() == "MAÑANA" ||
                    dataGridView1.Rows[row].Cells[cell].Value.ToString() == "noche" ||
                    dataGridView1.Rows[row].Cells[cell].Value.ToString() == "mañana")
                {
                    
                }
                else {
                    guardarNotaf = false;
                    az("El turno tiene que ser: NOCHE o MAÑANA");
                }

            }

            if (cargadedatosok == true) { 
            if (guardarNotaf == true) {
                try
                {
                    /*
                    if (int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) <= 10 &&
                 int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) > 0)
                    {
                       */ 
                            
                            SqlCommand comando = new SqlCommand();



                        try {

                            //   int.Parse(dataGridView1.Rows[row].Cells["Legajo"].Value.ToString()),
                            DatosSP.Notas(ref comando, codcurso, codmateria, codespe,
                                 dataGridView1.Rows[row].Cells["Nota Final"].Value.ToString(),
                                 int.Parse(dataGridView1.Rows[row].Cells["Legajo"].Value.ToString()),
                                 dataGridView1.Rows[row].Cells["Modalidad"].Value.ToString(),
                                  dataGridView1.Rows[row].Cells["Turno"].Value.ToString()

                                 );
                            aq.ConfigurarProcedure(ref comando, "UpdateNotas");
                            comando.Connection = aq.ObtenerConexion();

                            SqlDataReader reader = comando.ExecuteReader();

                            while (reader.Read())
                            { }

                        }
                        catch (Exception) {
                            DatosSP.Notas(ref comando, codcurso, codmateria, codespe,
                                dataGridView1.Rows[row].Cells["Nota Final"].Value.ToString(),
                                int.Parse(dataGridView1.Rows[row].Cells["Legajo"].Value.ToString()),
                                dataGridView1.Rows[row].Cells["Modalidad"].Value.ToString(),
                                 dataGridView1.Rows[row].Cells["Turno"].Value.ToString()

                                );
                            aq.ConfigurarProcedure(ref comando, "UpdateNotas");
                            comando.Connection = aq.ObtenerConexion();

                            SqlDataReader reader = comando.ExecuteReader();

                            while (reader.Read())
                            { }
                        }
                        
                    
                }
                catch (Exception ex) {
                   // az(ex.ToString());
                }


            }
            }


        }

        string conseguiremail(string legajo)
        {

            AccesoDatos aq = new AccesoDatos();
            DataSet dt = new DataSet();
            aq.cargaTabla("asd", "select email from inscriptos where legajo='" + legajo + "'", ref dt);
            return dt.Tables["asd"].Rows[0][0].ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
                 
            Clases_SQL.Excel.exportar(dataGridView1);
        }
    }
}
