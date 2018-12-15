using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;


namespace SASAI
{
    public partial class EnviarMailMasivo : Form
    {

        public int column { get; set; }
        public EnviarMailMasivo(DataGridView listado, int columna)
        {
            InitializeComponent();
            dataGridView1 = listado;
            column = columna;

        }

        private void lbl_Email_Click(object sender, EventArgs e)
        {

        }

        private void EnviarMailMasivo_Load(object sender, EventArgs e)
        {
           

        }

        public string MandarEmail(string email) {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje

                          
                  mmsg.To.Add(email);
                    //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario
            
            //Asunto
            mmsg.Subject = txb_asunto.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            // mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = txb_Mensaje.Text;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(txb_Mail.Text);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(txb_Mail.Text, txb_pass.Text);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            ///*
            cliente.Port = 25;
            cliente.EnableSsl = true;
            //*/
            //Para Hotmail "smtp.live.com"; //Para Gmail "smtp.gmail.com";
            cliente.Host = "outlook.office365.com"; 


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
              //  MessageBox.Show("Enviado correctamente a: " + email);
                return "1";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "error";
                //Aquí gestionamos los errores al intentar enviar el correo
            }

        }



        private void btn_EnviarMail_Click(object sender, EventArgs e)
        {
            // boton de enviar 
            int cont = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                
                if (dataGridView1.Rows[i].Cells[column].Value.ToString() != "")
                    if (MandarEmail(dataGridView1.Rows[i].Cells[column].Value.ToString()) != "1")
                    {
                        // los emails rechazados serian estos
                        // estaria faltando crear un listbox o un reporte de dichos emails a cuales no pudo enviarse 
                        // despues de eso, agregar el boton de Masivo o en la parte del form1 o en cada parte que haya
                        //un datagrid con emails.
                      //  MessageBox.Show(dataGridView1.Rows[i].Cells[column].Value.ToString());
                    }
                    else { cont++; }

                label1.Text = "Emails Enviados: " + cont + "/" + dataGridView1.Rows.Count;
            }
            label1.Text = "Emails Enviados: ";
            txb_asunto.Text = "";
            txb_Mail.Text = "";
            txb_Mensaje.Text = "";
            txb_pass.Text = "";
        }

        private void txb_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_EnviarMail_Click(sender, e);
            }
        }
    }
}
