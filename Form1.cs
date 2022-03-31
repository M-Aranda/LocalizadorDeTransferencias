using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Storage;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace LocalizadorDeFacturasPendientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sFileName = "";

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Archivos XLSX (*.xlsx)|*.xlsx";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            string[] arrAllFiles = new string[] { };

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                sFileName = choofdlog.FileName;
                arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }

            List<TransferenciaPendiente> transferencias = leerExcelDeTransferencias(sFileName);


            string localfolder = ApplicationData.Current.LocalFolder.Path;
            var array = localfolder.Split('\\');
            var username = array[2];
            string downloads = @"C:\Users\" + username + @"\Downloads";


            var archivo = new FileInfo(downloads + @"\Asistencias.xlsx");

            SaveExcelFileTransferencias(transferencias, archivo);

            MessageBox.Show("Archivo Excel de asistencias creado en carpeta de descargas!");



        }



        private static async Task SaveExcelFileTransferencias(List<TransferenciaPendiente> transferencias, FileInfo file)
        {
            var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("Transferencias");

            var range = ws.Cells["A1"].LoadFromCollection(transferencias, true);

            range.AutoFitColumns();

            await package.SaveAsync();
        }



        private List<TransferenciaPendiente> leerExcelDeTransferencias(string FilePath)
        {
            List<TransferenciaPendiente> transferencias = new List<TransferenciaPendiente>();
            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                //get the second worksheet in the workbook
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets[1];
                int colCount2 = worksheet2.Dimension.End.Column;  //get Column Count
                int rowCount2 = worksheet2.Dimension.End.Row;     //get row count

                //get the third worksheet in the workbook
                ExcelWorksheet worksheet3 = package.Workbook.Worksheets[2];
                int colCount3 = worksheet3.Dimension.End.Column;  //get Column Count
                int rowCount3 = worksheet3.Dimension.End.Row;     //get row count

                //get the fourth worksheet in the workbook
                ExcelWorksheet worksheet4 = package.Workbook.Worksheets[3];
                int colCount4 = worksheet4.Dimension.End.Column;  //get Column Count
                int rowCount4 = worksheet4.Dimension.End.Row;     //get row count


                for (int row = 1; row <= rowCount4; row++)
                {
                    TransferenciaPendiente t = new TransferenciaPendiente();

                    t.Centro = worksheet.Cells[row, 1].Value?.ToString().Trim();
                    t.FechaProg = worksheet.Cells[row, 2].Value?.ToString().Trim();
                    t.Planilla = worksheet.Cells[row, 3].Value?.ToString().Trim();
                    t.Conductor = worksheet.Cells[row, 4].Value?.ToString().Trim();
                    t.Banco = worksheet.Cells[row, 5].Value?.ToString().Trim();
                    t.Observacion = worksheet.Cells[row, 6].Value?.ToString().Trim();
                    t.Corte = worksheet.Cells[row, 7].Value?.ToString().Trim();
                    t.Monto = worksheet.Cells[row, 8].Value?.ToString().Trim();
                    t.Rut = worksheet.Cells[row, 9].Value?.ToString().Trim();


                    transferencias.Add(t);

                }



                    



                }
            

            return transferencias;

        }



    }
}
