using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SASAI.Alumnos
{
    public partial class NuevoInteresado : Form
    {
        public NuevoInteresado()
        {
            InitializeComponent();
        }

        private void NuevoInteresado_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            DataSet dt = new DataSet();

            try
            {
                aq.cargaTabla("asd", "insert into interesados select '" + tb_email.Text + "','" + tb_nombre.Text + "','" + tb_apellido.Text + "','" + dtp_fecha.Value.ToShortDateString() + "','" + tb_observacion.Text + "'", ref dt);
                MessageBox.Show("Interesado dado de alta correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ya existe ese email en interesados!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
