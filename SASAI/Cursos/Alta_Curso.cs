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
namespace SASAI
{
    public partial class Alta_Curso : Form
    {

    public void mesage(string aq) { MessageBox.Show(aq); }
        public string[] cod;
        public int tam;
        AccesoDatos aq;
        DataSet ds;
        SqlCommand comando = new SqlCommand();
        public Alta_Curso()
        {
            InitializeComponent();
        }

        public int verificarcombo(string val, ComboBox box) {

            for (int i = 0; i < box.Items.Count; i++) {
                if (val == box.Items[i].ToString()) { return i; }
            }


            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool guardar = true;
            string b = "\n";
            string error = "No se pudo crear el curso por los siguientes errores:"+b;
            
            int cont = 0;

            try {
                try {
                    if (verificarcombo(comboBox1.SelectedItem.ToString(), comboBox1) == -1)
                    {
                        cont++;
                        guardar = false;
                        error +=cont+") "+"Especialidad inexistente." + b;

                    }
                } catch (Exception) {
                    cont++;
                    guardar = false;
                    error += cont + ") " + "Especialidad inexistente." + b;
                }

                try
                {
                    if (verificarcombo(comboBox2.SelectedItem.ToString(), comboBox2) == -1)
                    {
                        cont++;
                        guardar = false;
                        error += cont + ") " + "Porfavor seleccione un valor de la lista." + b;

                    }
                } catch (Exception)
                {
                    cont++;
                    guardar = false;
                    error += cont + ") " + "Porfavor seleccione un valor de la lista." + b;
                }
               


                if (textBox2.Text == "")
                {
                    cont++;
                    guardar = false;
                    error += cont + ") " + "El curso deberia tener un nombre o idenficador." + b;
                }

                if (numericUpDown1.Value <= 0)
                {
                    cont++;
                    guardar = false;
                    error += cont + ") " + "La cantidad maxima de alumnos no puede ser <=0" + b;

                }

                if (listBox1.Items.Count <= 0)
                {
                    cont++;
                    guardar = false;
                    error += cont + ") " + "El curso debe tener por lo menos alguna materia cargada" + b;
                }

              //  MessageBox.Show(dateTimePicker1.Value.ToShortDateString());

                DateTime f1 = new DateTime();
                DateTime f2 = new DateTime();
                f1 =  DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                f2 =  DateTime.Parse(dateTimePicker2.Value.ToShortDateString());
                if (f1 >= f2) {

                    cont++;
                    guardar = false;
                    error += cont + ") " + "La fecha de finalizacion del curso debe ser menor a la del inicio." + b;
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

            if (guardar == true)
            {
                string consulta = "";
                try
                {
                    consulta = "Update Cursos set actual = 0 where actual = 1";
                    aq.cargaTabla("ActualCambio", consulta, ref ds);

                    //orden carga en bd

                    //armado de nombre del curso.



                    //insert into Cursos select 001,'20/08/2017','20/08/2017','Mayo2018',7,150,1
                    consulta = "insert into Cursos select " + textBox1.Text + ",'" + dateTimePicker1.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + textBox2.Text + "'," + int.Parse(comboBox2.SelectedItem.ToString()) + "," + numericUpDown1.Value + ",";
                    if (checkBox1.Checked == true)
                    {
                        consulta += "1";
                    }
                    else { consulta += "0"; }
                    //aq.cargaTabla("Espe", consulta, ref ds);
                  //  MessageBox.Show(consulta);
                    aq.cargaTabla("Cursos0", consulta, ref ds);
                    //3 especialidades x cursos

                    DatosSP.EspecialidadNombre(ref comando, comboBox1.SelectedItem.ToString());

                    string aux = aq.Reader_Procedure(comando, "EncontrarEspecialidad");
                    if (aux != "error")
                    {

                        consulta = "insert into especialidadesxCursos select '" + textBox1.Text + "','" + aux + "'";
                       
                        aq.cargaTabla("espexcursos", consulta, ref ds);
                    }

                    //4 materias xcursos
                     consulta = "select nombre,Codespecialidad from especialidades";
                    aq.cargaTabla("CodEspe", consulta, ref ds);

                    for (int i = 0; i < tam; i++)
                    {
                     
                        consulta = "insert into MateriasxCurso select '" + cod[i] + "','" + textBox1.Text + "','";

                        for (int x = 0; x < ds.Tables["CodEspe"].Rows.Count; x++)
                        {



                            if (ds.Tables["CodEspe"].Rows[x][0].ToString() == comboBox1.SelectedItem.ToString())
                            {
                                consulta += ds.Tables["CodEspe"].Rows[x][1].ToString() + "'";
                            }

                        }
                    
                        aq.cargaTabla("Materiasxcurso" + i, consulta, ref ds);
                    }

                    MessageBox.Show("Curso Creado.");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }



            }
            else { MessageBox.Show(error); }


        }
        int verificarlistbox(ListBox a,string val) {

            for (int i = 0; i < a.Items.Count; i++)
            {
                if(a.Items[i].ToString() ==val)
                    return i;
            }

            return -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listar_Materias mate = new Listar_Materias();
            Formularios.AbrirFormularioHijos(mate);

            if (mate.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < mate.tam; i++)
                {
                    //insertar cada codigo en el listBox1
                    if(verificarlistbox(listBox1,mate.NombreM[i])==-1)
                    listBox1.Items.Add(mate.NombreM[i]);
                    //MessageBox.Show(mate.codigo[i]);
                }
                cod = new string[mate.tam];
                cod = mate.codigo;
                tam = mate.tam;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listar_Materias mate = new Listar_Materias();
            Formularios.AbrirFormularioHijos(mate);

            if (mate.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < mate.tam; i++)
                {
                    //insertar cada codigo en el listBox1
                    //listBox1.Items.Remove(mate.NombreM[i]);
                    listBox1.Items.Add(mate.NombreM[i]);
                    //MessageBox.Show(mate.codigo[i]);
                }


            }
        }

        void cargarespe()
        {
            DataSet dr = new DataSet();
            comboBox1.Items.Clear();
            string consulta = "select nombre,Codespecialidad from especialidades";
            aq.cargaTabla("CodEspe", consulta, ref dr);
            for (int i = 0; i < dr.Tables["CodEspe"].Rows.Count; i++)
                comboBox1.Items.Add(dr.Tables["CodEspe"].Rows[i][0].ToString());
            comboBox1.SelectedIndex = 0;
        }
        private void Alta_Curso_Load(object sender, EventArgs e)
        {
            //1 cargar cod de curso
            string consulta = "select COUNT(CodCurso)from Cursos";
            aq = new AccesoDatos();
            ds = new DataSet();
            aq.cargaTabla("Codcursocount", consulta, ref ds);
            textBox1.Text = (int.Parse(ds.Tables["Codcursocount"].Rows[0][0].ToString()) + 1).ToString();
            //2 cargar especialidades
            cargarespe();

            //3 cargas las notas
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(5);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(7);
            comboBox2.Items.Add(8);
            comboBox2.Items.Add(9);
            comboBox2.Items.Add(10);
            //4 si se marca@ el actual@ (poner en 0  el actual anterior)


        }

        private void btnmas_Click(object sender, EventArgs e)
        {

            Alta_Especialidad esp = new Alta_Especialidad();
            Formularios.AbrirFormularioHijos(esp);
            cargarespe();
        }
    }
}
