using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.DAL
{
    class ConectMSAccess
    {
        string strcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        OleDbConnection conn;
        OleDbDataAdapter ada;
        DataTable dt = new DataTable();
        string tableChecked="";
        public ConectMSAccess(string datasource)
        {
                strcon = strcon + datasource;
                conn = new OleDbConnection();
                conn.ConnectionString = strcon;
                conn.Open();    
        }

        public OleDbConnection getConect()
        {
            return conn;
        }
        public List<Tuple<string, string>> getFKInChecked()
        {
            dt = conn.GetSchema("indexes");
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            
            foreach (DataRow item in dt.Rows)
            {
                if (!item[2].ToString().StartsWith("MSys")
                    && tableChecked.Contains(item[2].ToString())
                    && item[6].ToString()=="False")
                {
                   
                    result.Add(new Tuple<string,string>(item[2].ToString(),item[5].ToString()));
                }

            }
            return result;
        }
        public void setTableChecked(List<string> listTB)
        {
            tableChecked = "(";
            foreach (var item in listTB)
            {
                tableChecked = tableChecked + "'" + item + "',";
            }
            tableChecked = tableChecked.Remove(tableChecked.Length - 1) + ")";
        }
        public List<string> getAllTable()
        {
            List<string> list = new List<string>();
            dt = conn.GetSchema("TABLES");
            foreach (DataRow item in dt.Rows)
            {
                if (item[3].ToString().Equals("TABLE"))
                {
                    list.Add(item[2].ToString());
                }
            }
            return list;
        }
        public List<Tuple<string, string>> getAllFK()
        {
            dt = conn.GetSchema("indexes");
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            foreach (DataRow item in dt.Rows)
            {
                if (!item[2].ToString().StartsWith("MSys")
                    && item[6].ToString() == "False")
                {
                    if (!result.Contains(new Tuple<string, string>(item[2].ToString(), item[5].ToString())))
                        result.Add(new Tuple<string, string>(item[2].ToString(), item[5].ToString()));
                }

            }
            return result;
        }
    }
}
