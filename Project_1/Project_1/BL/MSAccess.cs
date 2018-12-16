using Project_1.DAL;
using Project_1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1.BL
{
    class MSAccess : ConvertDB
    {
        ConectMSAccess db;
        OleDbConnection connAccess;
        OleDbCommand cmd;

        public MSAccess(ConectSQL conn, string path, string DBName, List<string> listTableChecked, int TypeScript, List<Mapping> listMap)
            : base(conn, path, DBName, listTableChecked, TypeScript, listMap)
        {
            db = new ConectMSAccess(path);
            connAccess = db.getConect();
            db.setTableChecked(listTableChecked);

            
        }

        public bool getScript(ProgressBar pro)
        {
            //try
            //{
                if (TypeScript1 == 0)
                {
                    DropAllFK(pro, 10);
                    pro.Value = 10;
                    DropAllTable(pro, 10);
                    pro.Value = 20;
                    AddTableIntoAccess(pro, 40);
                    pro.Value = 60;
                    AddFKIntoAccess(pro, 40);
                    pro.Value = 100;
                }
                else if (TypeScript1 == 1)
                {
                    DropAllFK(pro, 20);
                    pro.Value = 20;
                    pro.Step = 20;

                    GetSchema();
                    pro.PerformStep();
                    pro.Value = 40;
                    AddDataIntoAccess(pro, 60);
                    pro.Value = 100;
                }
                else
                {
                    DropAllFK(pro, 10);
                    pro.Value = 10;
                    DropAllTable(pro, 10);
                    pro.Value = 20;
                    AddTableIntoAccess(pro, 20);
                    pro.Value = 40;
                    AddDataIntoAccess(pro, 40);
                    pro.Value = 80;
                    AddFKIntoAccess(pro, 20);
                    pro.Value = 100;
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
                    datatype = item.Access.Trim();
            }
            if (!datatype.Contains("("))
            {
                string lengthNumber = "char,nchar,nvarchar,varchar,varbinary";
                string dec = "decimal,numeric";
                string length = "";
                if (lengthNumber.Contains(type))
                {
                    if (maxlength == "-1")
                    {
                        datatype = datatype.Replace("long", "");
                        length = "(231)";
                    }
                    else if (Convert.ToInt32(maxlength) < 256)
                    {
                        datatype = datatype.Replace("long", "");
                        length = "(" + maxlength + ")";
                    }
                }
                else if (dec.Contains(type))
                {
                    length = "(" + numpre + "," + numscale + ")";
                }

                return datatype + length;
            }

            return datatype;
        }
        public void AddTableIntoAccess(ProgressBar pro, int rest)
        {
            List<string> listResult = getScriptTableAndPK();
            if (listResult.Count != 0)
            {
                pro.Step = Convert.ToInt32(Math.Ceiling(1.0 * rest / listResult.Count));
                pro.PerformStep();
                foreach (var item in listResult)
                {
                    cmd = connAccess.CreateCommand();
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                    pro.PerformStep();
                }
            }
            

        }

        public void DropAllFK(ProgressBar pro, int rest)
        {
            //lấy danh sách các khóa ngoại trong access
            List<Tuple<string, string>> list = db.getAllFK();
            if (list.Count != 0)
            {
                pro.Step = Convert.ToInt32(Math.Ceiling(1.0 * rest / list.Count));
                pro.PerformStep();
                foreach (var item in list)
                {
                    string tam = "alter table [" + item.Item1 + "] drop constraint "
                        + item.Item2.ToString();
                    cmd = connAccess.CreateCommand();
                    cmd.CommandText = tam;
                    cmd.ExecuteNonQuery();
                    pro.PerformStep();
                }
            }
        }

        public void DropAllTable(ProgressBar pro, int rest)
        {
            List<string> list = db.getAllTable();
            if (list.Count != 0)
            {
                pro.Step = Convert.ToInt32(Math.Ceiling(1.0 * rest / list.Count));
                pro.PerformStep();
                foreach (var item in list)
                {
                    cmd = connAccess.CreateCommand();
                    cmd.CommandText = "Drop table " + standardizing(item.ToString());
                    cmd.ExecuteNonQuery();
                    pro.PerformStep();
                }
            }

        }

        public void AddDataIntoAccess(ProgressBar pro, int rest)
        {
            DataTable dtTemp;
            OleDbDataAdapter ada;
            string cmdText = "select * from ";
            if (Db.ListTable.Count != 0)
            {
                pro.Step = Convert.ToInt32(Math.Ceiling(1.0 * rest / Db.ListTable.Count));
                pro.PerformStep();
                foreach (var item in Db.ListTable)
                {
                    dtTemp = Conn.getTableByName(item.TableName1);
                    foreach (DataRow it in dtTemp.Rows)
                    {
                        it.SetAdded();
                    }


                    dtTemp.TableName = item.TableName1;
                    //Nếu tồn tại 1 bảng chưa set khóa chính thì sẽ bị lỗi
                    ada = new OleDbDataAdapter(cmdText + item.TableName1, connAccess);
                    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(ada);
                    cmdBuilder.QuotePrefix = "[";
                    cmdBuilder.QuoteSuffix = "]";

                    ada.InsertCommand = cmdBuilder.GetInsertCommand();
                    //ada.UpdateCommand = cmdBuilder.GetUpdateCommand();
                    ada.Update(dtTemp);
                    pro.PerformStep();
                }
            }
            
        }

        public void AddFKIntoAccess(ProgressBar pro, int rest)
        {
            List<string> listResult = getScriptFK();
            if (listResult.Count != 0)
            {
                pro.Step = Convert.ToInt32(Math.Ceiling(1.0 * rest / listResult.Count));
                pro.PerformStep();
                foreach (var item in listResult)
                {
                    cmd = connAccess.CreateCommand();
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                    pro.PerformStep();
                }
            }
            
        }
        public override string standardizing(string name)
        {
            name = name.Trim();

            return "[" + name + "]";
        }
        
    }
}
