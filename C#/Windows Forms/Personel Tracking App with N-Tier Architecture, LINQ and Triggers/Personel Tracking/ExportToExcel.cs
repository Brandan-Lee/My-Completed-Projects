using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Tracking
{
    public class ExportToExcel
    {
        internal static void ExcelExport(DataGridView dataGridView1)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workBook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = null;
            app.Visible = true;
            workSheet = workBook.Sheets["Sheet1"];
            workSheet = workBook.ActiveSheet;

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                workSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    workSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            }
        }
    }
}
