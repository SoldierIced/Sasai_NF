using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SASAI.Cursos
{ 
    public partial class Alta_Curso : Form
    {
        public string[] cod;
        public int tam;
        AccesoDatos aq;
        DataSet ds;

        public Alta_Curso()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listarMaterias mate = new listarMaterias();
            Formularios.AbrirFormularioHijos(mate);

            if (mate.DialogResult == DialogResult.OK) {
                for (int i = 0; i < mate.tam; i++) {
                    //insertar cada codigo en el listBox1
                    listBox1.Items.Add(mate.NombreM[i]);
                    //MessageBox.Show(mate.codigo[i]);
                }
                cod = new string[mate.tam];
                cod = mate.codigo;
                tam = mate.tam;
              
            }
            //hacer insert into

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listarMaterias mate = new listarMaterias();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "";
            try {
                consulta = "Update Cursos set actual = 0 where actual = 1";
                aq.cargaTabla("ActualCambio", consulta, ref ds);

                //orden carga en bd

               
              
                //2 cursos
                //
                consulta = "insert into Cursos select '" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "'," + int.Parse(comboBox2.SelectedItem.ToString()) + "," + numericUpDown1.Value + ",";
                if (checkBox1.Checked == true)
                {
                    consulta += "1";
                }
                else { consulta += "0"; }
                //aq.cargaTabla("Espe", consulta, ref ds);
                MessageBox.Show(consulta);
                aq.cargaTabla("Cursos0", consulta, ref ds);
                //3 especialidades x cursos
               

                for (int i = 0; i < ds.Tables["CodEspe"].Rows.Count; i++)
                {
                    if (ds.Tables["CodEspe"].Rows[i][0].ToString() == comboBox1.SelectedItem.ToString())
                    {

                        consulta = "insert into EspecialidadesxCursos(CodCurso, Codespecialidad)select '" + textBox1.Text + "','" + ds.Tables["CodEspe"].Rows[i][1].ToString() + "'";
                    }


                }

                MessageBox.Show(consulta);
                aq.cargaTabla("Espe", consulta, ref ds);
                //4 materias xcursos
                for (int i = 0; i < tam; i++)
                {
                    consulta = "insert into MateriasxCurso select '" + cod[i] + "','" + textBox1.Text + "','";

                    for (int x = 0; x < ds.Tables["CodEspe"].Rows.Count; x++) {

                        //MessageBox.Show(ds.Tables["CodEspe"].Rows[x][0].ToString());
                       // MessageBox.Show(comboBox1.SelectedItem.ToString());

                        if (ds.Tables["CodEspe"].Rows[x][0].ToString() == comboBox1.SelectedItem.ToString()) { 
                      consulta+=  ds.Tables["CodEspe"].Rows[x][1].ToString() + "'";
                        }
                        
                    }
                    MessageBox.Show(consulta);
                    aq.cargaTabla("Materiasxcurso" + i, consulta, ref ds);
                    }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        private void Alta_Curso_Load(object sender, EventArgs e)
        {
            //1 cargar cod de curso
            string consulta = "select COUNT(CodCurso)from Cursos";
            aq = new AccesoDatos();
            ds = new DataSet();
            aq.cargaTabla("Codcursocount", consulta, ref ds);
            textBox1.Text="00"+ (int.Parse(ds.Tables["Codcursocount"].Rows[0][0].ToString())+1);
            //2 cargar especialidades
            consulta = "select nombre,Codespecialidad from especialidades";
           aq.cargaTabla("CodEspe", consulta, ref ds);
            for(int i =0; i<ds.Tables["CodEspe"].Rows.Count; i++)
            comboBox1.Items.Add( ds.Tables["CodEspe"].Rows[i][0].ToString());

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
    }
}
