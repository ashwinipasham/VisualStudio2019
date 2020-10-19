using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ExecuteAutomationTraining
{
    class ExcelDataReader
    {
        /*public DataTable ExceltoDataTable(String filename)
        {
            //open the file and returns as Stream 
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            //Create open xml via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
            // Set the First Row as Column Name
           excelReader.IsFirstRowColumnNames = true;
            //Returns a Dataset
           DataSet result = excelReader.AsDataSet();
            //Get all Tables
           DataTableCollection table = result.Tables;
            //Store in DataTable 
            DataTable resultTable = table["Sheet1"]; 

            //return
            return resultTable; 
        }*/
    }
}
