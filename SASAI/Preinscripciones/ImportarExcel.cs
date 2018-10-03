using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

using System.Data.SqlClient;
//using Microsoft.Office.Interop;


namespace SASAI
{
    public partial class ImportarExcel : Form
    {
        string consulta = "";
        DataSet ds=new DataSet();
        AccesoDatos aq = new AccesoDatos();
        bool MEDUSA { get; set; }

        public ImportarExcel()
        {
            InitializeComponent();
            MEDUSA = false;
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select *" +
                " from [" + hoja + "$]";
            //      NRO. INSC.,FECHA INSC.,INSTANCIA,CARRERA,ANEXO,MODALIDAD,TURNO,APELLIDO,NOMBRE,TIPO DOC.,NRO. DOC.

            //esta cadena es para archivos excel 2007 y 2010
            // string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
            //    string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Excel 12.0 xml;HDR=No;IMEX=1;Readonly=True;";
            //para archivos de 97-2003 usar la siguiente cadena

            string cadenaConexionArchivoExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + archivo + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
            //  conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    dataGridView1.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    conexion.Close();//cerramos la conexion
                    dataGridView1.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja " + ex);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
                                                                             //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox

                string hoja = "Todas"; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                LLenarGrid(dialog.FileName, hoja); //se manda a llamar al metodo
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las

            }
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;

            revisargrid(dataGridView1);

            try  {if (dataGridView1.Rows[0].Cells[0].Value.ToString() != string.Empty) { MEDUSA = true; } } catch (Exception) { }
           
        }

        public void revisargrid(DataGridView dq) {
            AccesoDatos aq = new AccesoDatos();

            for (int i = 0; i < dq.Rows.Count; i++) {

                // dni    MessageBox.Show(  dq.Rows[i].Cells[10].Value.ToString());
                SqlCommand comando = new SqlCommand();
                try {

                    DatosSP.Preinscriptos_DNI(ref comando, dq.Rows[i].Cells[10].Value.ToString());
                    


                    aq.ConfigurarProcedure(ref comando, "VerificarPreinscripto");
                    comando.Connection = aq.ObtenerConexion();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {


                        //  MessageBox.Show( reader[0].ToString());
                       
                        if (reader[0].ToString() == "1")
                        {
                            // pintar de verde porque fue encontrado..
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;

                        }
                        else
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }

                    }


                }
                catch (Exception) { }
            }

        } 

        private void button2_Click(object sender, EventArgs e)
        {
            if (MEDUSA == true)
            {
                try
                {
                    Preinscripciones.Confirmacion conf = new Preinscripciones.Confirmacion();
                    int registros_ok = 0;
                    if (conf.ShowDialog() == DialogResult.OK)
                    {

                        AccesoDatos aq = new AccesoDatos();

                        SqlCommand comando = new SqlCommand();



                        SqlCommand comando2 = new SqlCommand();
                        AccesoDatos aq2 = new AccesoDatos();
                        string codcurso = "";

                        aq2.ConfigurarProcedure(ref comando, "ExistenciaCurso");
                        comando.Connection = aq.ObtenerConexion();

                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {



                            if (reader[0].ToString() != "-1")
                            {
                                bool asd = false;
                                // MessageBox.Show(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                              
                            //    MessageBox.Show(comboBox1.Text);

                                if (textBox1.Text != "")
                                {

                                   
                                    asd = true;
                                    if (asd == true)
                                    {
                                  //      MessageBox.Show(reader[0].ToString());
                                        codcurso = reader[0].ToString();

                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            try
                                            {



                                                comando = DatosSP.Preinscriptos(int.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()), codcurso, "0",
                                       dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString(),
                                       dataGridView1.Rows[i].Cells[20].Value.ToString(), dataGridView1.Rows[i].Cells[19].Value.ToString(),
                                        dataGridView1.Rows[i].Cells[6].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(),
                                       codespe(textBox1.Text)
                                      );


                                                aq.EjecutarProcedimientoAlmacenado(comando, "CargaPreinscripto");
                                                registros_ok++;
                                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;

                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }

                                        MessageBox.Show("Registros cargados correctamente: " + registros_ok);
                                    }
                                    else {
                                        MessageBox.Show("Esa especialidad no existe."); }

                                    
                                }
                                else { MessageBox.Show("Tiene que seleccionar una especialidad."); }

                            }
                            else
                            {
                                MessageBox.Show("No hay un curso que sea el actual, antes de cargar preinscriptos favor de crear curso actual.");

                            }


                        }




                    }
                }
                catch (Exception ex) {
                 //  MessageBox.Show(ex.ToString());
                }
              }
            else {
                MessageBox.Show("Recuerde que tiene que cargar antes el excel.");
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string codespe(string nombre) {

            for (int i = 0; i < ds.Tables["CodEspe"].Rows.Count; i++)
            {
                if (ds.Tables["CodEspe"].Rows[i][0].ToString() == nombre) {

                    return ds.Tables["CodEspe"].Rows[i][1].ToString();
                }
            }


                return "";
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            try { 
            for (int j = 11; j < dataGridView1.Columns.Count; j++)
            {
                dataGridView1.Columns[j].Visible = false;
            }
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[20].Visible = true;
            dataGridView1.Columns[19].Visible = true;
            }
            catch (Exception ex) {

            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            try { 
             for (int j = 11; j < dataGridView1.Columns.Count; j++)
                {
                dataGridView1.Columns[j].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
             }
            }

        
            catch (Exception ex) {

            }

        }

        private void ImportarExcel_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 150;

        }

        private void ImportarExcel_Load(object sender, EventArgs e)
        {
            
            consulta = "select nombre,Codespecialidad from especialidades";
            aq.cargaTabla("CodEspe", consulta, ref ds);
            for (int i = 0; i < ds.Tables["CodEspe"].Rows.Count; i++)
               textBox1.Text=ds.Tables["CodEspe"].Rows[i][0].ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnviarMailMasivo en = new EnviarMailMasivo(dataGridView1,20);
            en.ShowDialog();
        }
    }
}
