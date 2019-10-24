//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
using System.IO;
using Excel;
using System.Data;
using UnityEngine;
using System.Collections.Generic;

public class LoadDataManager
{
    void Start()
    {
    }

    public static void XLSX(string filename, List<List<int> > dataList)
    {
        FileStream stream = File.Open(Application.dataPath+ "/Resources/" + filename, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();

        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;

        for (int i = 1; i < rows; i++)
        {
            List<int> data = new List<int>();
            
            for (int j = 0; j < columns; j++)
            {
                string nvalue = result.Tables[0].Rows[i][j].ToString();
                Debug.Log(nvalue);
                data.Add(int.Parse(nvalue));
            }
            dataList.Add(data);
        }
    }

    public static void XLSX(string filename, List<List<float>> dataList)
    {
        FileStream stream = File.Open(Application.dataPath + "/Resources/" + filename, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();

        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;

        for (int i = 1; i < rows; i++)
        {
            List<float> data = new List<float>();

            for (int j = 0; j < columns; j++)
            {
                string nvalue = result.Tables[0].Rows[i][j].ToString();
                Debug.Log(nvalue);
                data.Add(float.Parse(nvalue));
            }
            dataList.Add(data);
        }
    }
}