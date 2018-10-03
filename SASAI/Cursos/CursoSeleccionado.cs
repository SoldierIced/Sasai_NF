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
    public partial class CursoSeleccionado : Form
    {
        DataSet ds = new DataSet();
        string consulta = "";
        AccesoDatos aq = new AccesoDatos();

        public string codcurso = "";
        public string codespecialidad = "";
        public CursoSeleccionado(string codc,string codesp)
        {
            InitializeComponent();
            codcurso = codc;
            codespecialidad = codesp;
            
        }
        public void az(string val) { MessageBox.Show(val); }
        public void cargartabla(string consult,string name)
        {
            aq.cargaTabla(name, consult, ref ds);

        }
        public void cargardatos() {
           
            consulta = "select c.CodCurso,c.FechaFinal,c.FechaInicio,c.NombreCurso,c.CapacidadMax,Especialidades.nombre " +
                "from cursos as c inner join EspecialidadesXCursos on c.CodCurso= EspecialidadesXCursos.CodCurso " +
                "inner join Especialidades on EspecialidadesXCursos.CodEspecialidad= Especialidades.Codespecialidad  " +
                "where c.CodCurso  = '" + codcurso+ "' and especialidades.nombre = '" + codespecialidad+"' ";
            aq.cargaTabla("cargadedatos", consulta, ref ds);
       
            textBox1.Text = ds.Tables["cargadedatos"].Rows[0][0].ToString();
            textBox2.Text = ds.Tables["cargadedatos"].Rows[0][3].ToString();
            textBox3.Text = ds.Tables["cargadedatos"].Rows[0][2].ToString();
            textBox4.Text = ds.Tables["cargadedatos"].Rows[0][1].ToString();
            textBox5.Text = ds.Tables["cargadedatos"].Rows[0][5].ToString();
            label4.Text ="Cantidad: "+(dataGridView1.Rows.Count)+"/" + ds.Tables["cargadedatos"].Rows[0][4].ToString();

        }// carga de todos los datosde los checkbox.

        public bool buscardata(string val) {


            for (int i = 0; i < dataGridView1.Rows.Count; i++) {

                try
                {
                    if (val == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        return true;
                    }
                } catch (Exception) { }
               
            }
            return false;


        }
       private void CursoSeleccionado_Load(object sender, EventArgs e)
        {
            cargartodo();

        }
        
        public void cargartodo()
        {

            try
            { //primero que nada -
              //1 armar el datagrid 
              //1 saber cuantas materias son:
                
           
                consulta = "select MateriasxCurso.CodMateria,Materias.NombreMateria from MateriasxCurso inner join Materias on Materias.CodMateria= MateriasxCurso.CodMateria  where CodCurso ='" + codcurso + "' and materiasxcurso.codespecialidad='" + saberCodEspe(codespecialidad) + "'";
                aq.cargaTabla("cantmaterias", consulta, ref ds);



                //    *2 cargar todos los alumnos. 

                dataGridView1.Columns.Add("Legajo", "Legajo");
                dataGridView1.Columns.Add("Idinscripto", "Idinscripto");

                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Apellido", "Apellido");
                dataGridView1.Columns["Idinscripto"].ReadOnly = true;
                dataGridView1.Columns["Legajo"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Apellido"].ReadOnly = true;


                for (int i = 0; i < ds.Tables["cantmaterias"].Rows.Count; i++)
                {
                    dataGridView1.Columns.Add(ds.Tables["cantmaterias"].Rows[i][0].ToString(), ds.Tables["cantmaterias"].Rows[i][1].ToString());

                    comboBox1.Items.Add(ds.Tables["cantmaterias"].Rows[i][1].ToString());

                } // carga de columnas y nombres de materias

                //monto y observacion  y posiblemente email
                int pos = 0;
                dataGridView1.Columns.Add("Monto a Abonar", "Monto a Abonar");
                dataGridView1.Columns.Add("Observaciones", "Observaciones");
                dataGridView1.Columns["Monto a Abonar"].ReadOnly = true;



                consulta = "select di.legajo, idInscripto,Nombre,Apellido,di.observaciones , NotaMateria,NombreMateria,materias.codmateria,Monto,al.modalidad" +
                    "   from AlumnosxMateriasxCursos as al  inner join Inscriptos  as di on al.legajo=di.legajo inner join Materias on " +
                    " al.CodMateria=Materias.CodMateria where Codcurso='" + codcurso + "' and CodEspecialidad='" + saberCodEspe(codespecialidad) + "'";

                aq.cargaTabla("Datos", consulta, ref ds);
               
                if (ds.Tables["Datos"].Rows.Count > 0)
                {
                    dataGridView1.Rows.Add(ds.Tables["Datos"].Rows.Count/ ds.Tables["cantmaterias"].Rows.Count);
                }



                int cont = 0;

                for (int i = 0; i < ds.Tables["Datos"].Rows.Count; i++)
                {

                    if (buscardata(ds.Tables["Datos"].Rows[i][0].ToString()) == false)
                    {
                        dataGridView1.Rows[cont].Cells[0].Value = ds.Tables["Datos"].Rows[i][0].ToString();
                        dataGridView1.Rows[cont].Cells[1].Value = ds.Tables["Datos"].Rows[i][1].ToString();
                        dataGridView1.Rows[cont].Cells[2].Value = ds.Tables["Datos"].Rows[i][2].ToString();
                        dataGridView1.Rows[cont].Cells[3].Value = ds.Tables["Datos"].Rows[i][3].ToString();
                        dataGridView1.Rows[cont].Cells[4].Value = ds.Tables["Datos"].Rows[i][4].ToString();
                        dataGridView1.Rows[cont].Cells["Observaciones"].Value = ds.Tables["Datos"].Rows[i]["observaciones"].ToString();
                        // dataGridView1.Rows[cont].Cells["Monto a Abonar"].Value += ds.Tables["Datos"].Rows[i][7].ToString();
                        dataGridView1.Rows[cont].Cells[ds.Tables["Datos"].Rows[i][7].ToString()].Value = ds.Tables["Datos"].Rows[i][5].ToString();

                        if (ds.Tables["Datos"].Rows[i]["modalidad"].ToString() != "LIBRE")
                        {
                            dataGridView1.Rows[cont].Cells["Monto a Abonar"].Value = ds.Tables["Datos"].Rows[i][8].ToString();
                        }
                        else { dataGridView1.Rows[cont].Cells["Monto a Abonar"].Value = "0"; }

                        cont++;
                    }
                    else
                    {
                        //carga de nota de materias
                        dataGridView1.Rows[cont - 1].Cells[ds.Tables["Datos"].Rows[i][7].ToString()].Value = ds.Tables["Datos"].Rows[i][5].ToString();
                        if (ds.Tables["Datos"].Rows[i]["modalidad"].ToString() != "LIBRE") {
                      
                       
                        //ver que esta recibiendo en b..
                      
                        int a = pasardestringaint(dataGridView1.Rows[cont - 1].Cells["Monto a Abonar"].Value.ToString()) + pasardestringaint(ds.Tables["Datos"].Rows[i][8].ToString());

                        dataGridView1.Rows[cont - 1].Cells["Monto a Abonar"].Value = a.ToString();
                        }


                    }


                }


                cargardatos();

            }
            catch (Exception ex) { az(ex.ToString()); }

           
        }
        public int pasardestringaint(string val) {
            string doble = val;
            decimal doblesss = Convert.ToDecimal(doble);
            int b = Decimal.ToInt32(doblesss);
            return b;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SubirNotas sn = new SubirNotas(sabercodmateria(comboBox1.Items[comboBox1.SelectedIndex].ToString()), codcurso, saberCodEspe(codespecialidad));
                Formularios.AbrirFormularioHijos(sn);
                Formularios.AbrirFormularioPadre(new CursoSeleccionado(codcurso, codespecialidad));
            }
            catch (Exception ex) {

                MessageBox.Show(ex.ToString());
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

        public string saberCodEspe(string nombre)
        {

            try
            {
                string consulta2 = "select Codespecialidad from Especialidades where nombre='" + nombre + "'";
                aq.cargaTabla("consulta22", consulta2, ref ds);
                return ds.Tables["consulta22"].Rows[0][0].ToString();
            }
            catch (Exception) { return ""; }

        }

        public void cargarnota(int cell,int row) {
            if (sabercodmateria(dataGridView1.Columns[cell].HeaderText) != "")
            {
                string codmate = sabercodmateria(dataGridView1.Columns[cell].HeaderText);
                string codespe = saberCodEspe(codespecialidad);
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
            //valor modificado.
            //   dataGridView1.Rows[row].Cells[cell].Value.ToString();

            int row = dataGridView1.CurrentRow.Index;
            int cell = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                /*int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) <= 10 &&
int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) >= 0 ||*/

                if (dataGridView1.Columns[cell].HeaderText != "Observaciones")
                {
                    try
                    {
                        if ( dataGridView1.Rows[row].Cells[cell].Value.ToString()=="EQUIVALENCIA" ||
                            dataGridView1.Rows[row].Cells[cell].Value.ToString()=="equivalencia")

                        {
                            cargarnota(cell, row);
                        }
                        else
                        {
                            if (int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) <= 10 &&
int.Parse(dataGridView1.Rows[row].Cells[cell].Value.ToString()) >= 0)
                            {
                                cargarnota(cell, row);
                            }
                            else { az("Recuerde que las notas van del 0 al 10"); }
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }

                }
                else {
                    //cargar observacion..
                    consulta = "update Inscriptos set observaciones='" + dataGridView1.Rows[row].Cells[cell].Value.ToString() +
                        "' where legajo=" + dataGridView1.Rows[row].Cells["Legajo"].Value.ToString();
                    aq.cargaTabla("cargadeobservacion", consulta, ref ds);

                }
            } catch (Exception) { }
           
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CursoSeleccionado_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height -177;
        }
    }
    
}
