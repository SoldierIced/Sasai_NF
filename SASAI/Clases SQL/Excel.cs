using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office;
using System.Windows.Forms;


namespace SASAI.Clases_SQL
{
    class Excel
    {
        public static void exportar(DataGridView grd)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    //Recorremos los headers del datagrid
                     
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[1 , j+1] = grd.Columns[j].HeaderText;
                        }
                    

                    //Recorremos el DataGridView rellenando la hoja de trabajo

                    for (int i = 0; i < grd.Rows.Count ; i++)
                    {
                      
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            try
                            {
                              //  MessageBox.Show(grd.Rows[i].Cells[j].Value.ToString());
                                hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           

        }
    }
}
   
