using System.Linq;
using System.IO;
using System.Data;

namespace InvitationMail
{
    public static class CustomerExcel
    {
        public static DataTable ReadCsvFile()
        {
            DataTable dtCsv = new DataTable();
            string Fulltext;
            string FileSaveWithPath = "C:\\Users\\heman\\Documents\\Customer Info\\Data.csv";
            using (StreamReader sr = new StreamReader(FileSaveWithPath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j]); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                if (dr != null)
                                {
                                    dtCsv.Rows.Add(dr);
                                }//add other rows  
                            }
                        }
                    }
                }
            }

            return dtCsv;
        }
    }
}
