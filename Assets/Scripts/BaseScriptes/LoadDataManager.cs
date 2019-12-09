using System.IO;
using Excel;
using System.Data;
using UnityEngine;
using System.Collections.Generic;

public class LoadDataManager : Singleton<LoadDataManager>
{
    public static void XLSX(string filename, List<List<int> > dataList)
    {
        FileStream stream = File.Open(Application.streamingAssetsPath + "/" + filename, FileMode.Open, FileAccess.Read);
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
        FileStream stream = File.Open(Application.streamingAssetsPath + "/" + filename, FileMode.Open, FileAccess.Read);
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

    public static void XLSX(string filename, List<List<string>> dataList)
    {
        FileStream stream = File.Open(Application.streamingAssetsPath + "/" + filename, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();
        
        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;

        for (int i = 1; i < rows; i++)
        {
            List<string> data = new List<string>();

            for (int j = 0; j < columns; j++)
            {
                string nvalue = result.Tables[0].Rows[i][j].ToString();
                data.Add(nvalue);
            }
            dataList.Add(data);
        }
    }


    public static void XLSX(string filename, Dictionary<string, string> dString)
    {
        FileStream stream = File.Open(Application.streamingAssetsPath + "/" + filename, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();

        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;

        for (int i = 1; i < rows; i++)
        {
            List<string> lString = new List<string>();
            for (int j = 0; j < columns; j++)
            {
                string nvalue = result.Tables[0].Rows[i][j].ToString();
                lString.Add(nvalue);
            }

            dString.Add(lString[0], lString[1]);
        }
    }
}