﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMA.Models;
using HMA.Repositories.Interfaces;
using Excel = Microsoft.Office.Interop.Excel;

namespace HMA.Repositories
{
  public class ExcelRepository : IDataRepository
  {
    public void SaveData(List<ComingHomeModel> list)
    {
      object misValue = System.Reflection.Missing.Value;

      var xlApp = new Excel.Application();
      var xlWorkBook = xlApp.Workbooks.Add(misValue);
      var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
      var i = 1;

      foreach (var var in list)
      {
        var j = 1;
        xlWorkSheet.Cells[i, j] = var.Date;
        xlWorkSheet.Cells[i, j+1] = var.Hour;
        i++;
      }

      xlWorkBook.SaveAs("testData.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
      xlWorkBook.Close(true, misValue, misValue);
      xlApp.Quit();

      releaseObject(xlWorkSheet);
      releaseObject(xlWorkBook);
      releaseObject(xlApp);
    }

    public List<ComingHomeModel> GetData()
    {
      var list = new List<ComingHomeModel>(); 
      var rCnt = 0;
      var cCnt = 0;

      var xlApp = new Excel.Application();
      var xlWorkBook = xlApp.Workbooks.Open("testData.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
      var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

      var range = xlWorkSheet.UsedRange;

      for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
      {
        var o = (range.Cells[rCnt,1] as Excel.Range).get_Value();
        var range1 = (range.Cells[rCnt, 2] as Excel.Range).get_Value();
        if (o != null && range1 != null)
        {
          list.Add(new ComingHomeModel()
            {
              Date = o.ToString(),
              Hour = range1.ToString()
            });
        }
      }

      xlWorkBook.Close(true, null, null);
      xlApp.Quit();

      releaseObject(xlWorkSheet);
      releaseObject(xlWorkBook);
      releaseObject(xlApp);

      return list;
    }

    private void releaseObject(object obj)
    {
      try
      {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        obj = null;
      }
      catch (Exception ex)
      {
        obj = null;
        MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
      }
      finally
      {
        GC.Collect();
      }
    }
  }
}
