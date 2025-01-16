using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Talepler
{
    public static class ExportOperations
    {
        public static void ExportExcel(DataTable dataTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyaları|.xlsx";
            saveFileDialog.Title = "Excel olarak kaydet";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    DataTable dt = dataTable;
                    var worksheet = workbook.AddWorksheet("Sayfa1");
                    worksheet.Cell(1, 1).InsertTable(dt);
                    workbook.SaveAs(filePath);
                }
                MessageBox.Show("Veriler başarıyla dışa aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
