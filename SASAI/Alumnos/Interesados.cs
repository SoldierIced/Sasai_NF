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


    public partial class Interesados : Form
    {
        string emailviejo = "";
        AccesoDatos aq = new AccesoDatos();
        public Interesados()
        {
            InitializeComponent();
        }

        void cargagrid()
        {
            DataSet ds = new DataSet();
            string consulta = "select * from interesados";
            aq.cargaTabla("asd", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables["asd"];
        }

        private void Interesados_Load(object sender, EventArgs e)
        {
            cargagrid();
            
        }


    }

}

