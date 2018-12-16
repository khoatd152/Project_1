using Project_1.DAL;
using Project_1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1.BL
{
    class MySQL:ConvertDB
    {
        string sql;
        public MySQL(ConectSQL conn,string path,string DBName,List<string> listTableChecked,int TypeScript,List<Mapping> listMap)
            :base(conn,path,DBName,listTableChecked,TypeScript,listMap)
        {
            
        }
        public bool getScript(ProgressBar pro)
        {
            //try
            //{
                if (TypeScript1 == 0)
                {
                    AddSchema(pro);
                }
                else if (TypeScript1 == 1)
                {
                    AddDataWithoutSchema(pro, 100);

                }
                else
                {
                    AddSchemaAndData(pro);
                }
                return true;
            //}
            //catch
            //{
            //    return false;
            //}   
                
            
        }
        public override string getTypeData(string type, string maxlength, string numpre, string numscale)
        {
            string datatype = "";
            foreach (var item in ListMap)
            {
                if (item.Mssql.ToLower().Trim().Equals(type))
                {
                    datatype = item.Mysql.Trim();
                    break;
                }
            }

            string lengthNumber = "char,nchar,nvarchar,varchar";
            string dec = "decimal,numeric";
            string length;
            if (lengthNumber.Contains(type))
            {
                if (maxlength == "-1")
                    length = "(231)";
                else if (Convert.ToInt32(maxlength) > 255)
                    return "text(" + maxlength + ")";
                else length = "(" + maxlength + ")";
            }
            else if (dec.Contains(type))
            {
                length = "(" + numpre + "," + numscale + ")";
            }
            else
            {
                length = "";
            }
            return datatype + length;
        }
        public string AddData(ProgressBar pro,int rest)
        {
            //lấy tên tất cả các bảng trong database
            DataTable dt = Conn.getTableNameInChecked();

            //init
            DataTable dtt = null;
            string tempTable;
            sql = "";
            pro.Step = Convert.ToInt32( Math.Ceiling(1.0 * rest / dt.Rows.Count));
            pro.PerformStep();
            foreach (DataRow item in dt.Rows)
            {
                tempTable = item[0].ToString();
                //lấy dữ liệu của bảng tepmTable
                dtt = Conn.getDataByTableName(tempTable);

                if (dtt.Rows.Count > 0)
                {
                    string insert = null;


                    insert = "";
                    insert = insert + "\n" + "insert into " + standardizing(tempTable) + " values ";
                    foreach (DataRow it in dtt.Rows)
                    {
                        insert = insert + " \n(";
                        for (int i = 0; i < dtt.Columns.Count; i++)
                        {
                            string tam = standardizingData(it[i]);
                            insert = insert + tam;

                        }
                        insert = insert.Remove(insert.Length - 1) + "),";
                    }
                    insert = insert.Remove(insert.Length - 1) + ";";
                    sql = sql + insert + "\n";
                    if (pro.Value != 100)
                        pro.PerformStep();
                }
                
            }
            return sql;
        }
        
        
        public void AddDataWithoutSchema(ProgressBar pro, int rest)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                sql = "USE `" + DBName1 + "`;\n" + "SET foreign_key_checks = 0;"
                   + AddData(pro,rest) + "SET foreign_key_checks = 1;\n";
                writer.WriteLine(sql);
                pro.Value = 100;
            }
        }
        public void AddSchema(ProgressBar pro)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine("CREATE DATABASE IF NOT EXISTS " + DBName1 + ";");
                writer.WriteLine("USE " + DBName1 + ";\n");
                List<string> listResult = new List<string>();
                listResult = GetScriptSchema();
                pro.Step = 100 / listResult.Count;
                pro.PerformStep();
                foreach (var item in listResult)
                {
                    writer.WriteLine(item);
                    pro.PerformStep();
                }
                pro.Value = 100;
            }
        }
        public void AddSchemaAndData(ProgressBar pro)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine("CREATE DATABASE IF NOT EXISTS " + DBName1 + ";");
                writer.WriteLine("USE " + DBName1 + ";");
                List<string> listResult = new List<string>();
                listResult = GetScriptSchema();
                pro.Step = 50 / listResult.Count;
                pro.PerformStep();
                foreach (var item in listResult)
                {
                    writer.WriteLine(item);
                    pro.PerformStep();
                }
                sql = "SET foreign_key_checks = 0;"
                   + AddData(pro,100-pro.Value) + "SET foreign_key_checks = 1;\n";
                writer.WriteLine(sql);
                pro.Value = 100;
            }
        }
        public override string standardizing(string name)
        {
            name = name.Trim();
            if (name.Contains("`"))
            {
                name = name.Replace("`", "``");
            }
            return "`" + name + "`";
        }
    }
}
