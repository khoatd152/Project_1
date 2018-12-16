using Project_1.DAL;
using Project_1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.BL
{
    public class ConvertDB
    {
        private DataTable dt;

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        ConectSQL conn;

        public ConectSQL Conn
        {
            get { return conn; }
            set { conn = value; }
        }
        string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        string DBName;

        public string DBName1
        {
            get { return DBName; }
            set { DBName = value; }
        }
        List<string> listTableChecked;

        public List<string> ListTableChecked
        {
            get { return listTableChecked; }
            set { listTableChecked = value; }
        }
        int TypeScript;

        public int TypeScript1
        {
            get { return TypeScript; }
            set { TypeScript = value; }
        }

        private List<Mapping> listMap;

        public List<Mapping> ListMap
        {
            get { return listMap; }
            set { listMap = value; }
        }

        DataBase db;

        public DataBase Db
        {
            get { return db; }
            set { db = value; }
        }
        public ConvertDB(ConectSQL conn, string path, string DBName, List<string> listTableChecked, int TypeScript, List<Mapping> listMap)
        {
            this.conn = conn;
            this.path = path;
            this.DBName = DBName;
            conn.setTableChecked(listTableChecked);
            this.TypeScript = TypeScript;
            this.listMap = listMap;
            db = new DataBase();
        }

        public virtual string standardizing(string name)
        {
            return "";
        }
        public virtual string getTypeData(string type, string maxlength, string numpre, string numscale)
        {
            return "";
        }
        
        public bool checkNull(string str)
        {
            return str == "NO" ? false : true;
        }
        public virtual DataBase CreateTable()
        {
            dt = conn.getTableStructure();
            db.DataBaseName1 = DBName;
            string tempTable = "a b c";
            string kieuDuLieu;
            Table tb = null;
            foreach (DataRow item in dt.Rows)
            {
                kieuDuLieu = item["DATA_TYPE"].ToString().ToLower();

                if (tempTable != item["TABLE_NAME"].ToString())
                {

                    if (tempTable != item["TABLE_NAME"].ToString() && tb!=null)
                        db.ListTable.Add(tb);
                    //chuẩn hóa tên bảng nếu chứa khoảng trắng
                    tempTable = item["TABLE_NAME"].ToString();

                    tb = new Table();
                    tb.TableName1 = standardizing(tempTable);

                }


                tb.ListColumns.Add(new Column(standardizing(item["COLUMN_NAME"].ToString()),
                 getTypeData(kieuDuLieu, item["CHARACTER_MAXIMUM_LENGTH"].ToString(), item["NUMERIC_PRECISION"].ToString(), item["NUMERIC_SCALE"].ToString()),
                 checkNull(item["IS_NULLABLE"].ToString())));
            }
            db.ListTable.Add(tb);
            return db;
        }

        public virtual DataBase AddPK()
        {
            dt = conn.getPK();
            string tempTable = null;
            PrimaryKey pk = null;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (tempTable != item["TableName"].ToString())
                    {
                        if (tempTable != null)
                        {
                            db.ListPK.Add(pk);
                        }
                        tempTable = item["TableName"].ToString();

                        pk = new PrimaryKey();
                        pk.PKName1 = item["IndexName"].ToString();
                        pk.PkOfTable1 = standardizing(tempTable);
                    }
                    pk.ListColumnsPK.Add(standardizing(item["ColumnName"].ToString()));

                }

                db.ListPK.Add(pk);
            }
            
            return db;
        }

        public virtual DataBase AddFK()
        {
            dt = conn.getFK();
            ForeignKey fk = null;
            string bangthamchieu = "";
            string bangdcthamchieu = "";
            string cotthamchieu = "";
            string cotdcthamchieu = "";
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (bangthamchieu != item["referencing_table_name"].ToString() ||
                        bangdcthamchieu !=  item["referenced_table_name"].ToString())
                    {
                        if (fk != null)
                        {
                            
                            db.ListFK.Add(fk);
                        }

                        bangthamchieu = item["referencing_table_name"].ToString();
                        cotthamchieu = item["referencing_column_name"].ToString();
                        bangdcthamchieu = item["referenced_table_name"].ToString();
                        cotdcthamchieu = item["referenced_column_name"].ToString();
                        
                        fk = new ForeignKey();
                        fk.FKName1 = item["constraint_name"].ToString();
                        fk.ReferencedTable1 = standardizing(bangdcthamchieu);
                        fk.ReferencingTable1 = standardizing(bangthamchieu);
                        
                        fk.ReferencedColumn1.Add(standardizing(cotdcthamchieu));
                        fk.ReferencingColumn1.Add(standardizing(cotthamchieu));
                        
                    }
                    else
                    {
                        
                       fk.ReferencedColumn1.Add(standardizing(item["referenced_column_name"].ToString()));
                       fk.ReferencingColumn1.Add(standardizing(item["referencing_column_name"].ToString()));
                        
                    }
                }
                
                db.ListFK.Add(fk);
            }
            
            return db;
        }

        public virtual DataBase GetSchema()
        {
            db = CreateTable();
            db = AddPK();
            db = AddFK();
            return db;
        }

        //chuyển modal thành các chuỗi string
        public virtual List<string> GetScriptSchema()
        {
            db = GetSchema();
            List<string> listResult = new List<string>();
            
            //chuyển table thành string
            string table;
            foreach (var item in db.ListTable)
            {
                table = "CREATE TABLE " + item.TableName1 + " (";
                foreach (var it in item.ListColumns)
                {
                    table = table + "\n" + it.ColumnName + " "
                        + it.TypeOfData1 + " "
                        + ChangeNullable(it.AllowNullAble) + ",";
                }
                table = table.Remove(table.Length - 1, 1) + ");\n";
                listResult.Add(table);
            }
            

            //chuyển khóa chính thành string
            string pk;
            foreach (var item in db.ListPK)
            {
                pk = "ALTER TABLE " + item.PkOfTable1 + " ADD CONSTRAINT "
                    + item.PKName1 + " PRIMARY KEY(";
                foreach (var it in item.ListColumnsPK)
                {
                    pk = pk + it + ",";
                }
                pk = pk.Remove(pk.Length - 1, 1) + ");\n";
                listResult.Add(pk);
            }

            //chuyển khóa ngoại thành string
            string fkF;
            string fkS;
            foreach (var item in db.ListFK)
            {
                fkF = "ALTER TABLE " + item.ReferencingTable1 + " ADD FOREIGN KEY (";
                fkS = "REFERENCES " + item.ReferencedTable1+" (";
                foreach (var x in item.ReferencingColumn1)
                {
                    fkF = fkF + x + ",";
                }
                foreach (var y in item.ReferencedColumn1)
                {
                    fkS = fkS + y + ",";
                }
                fkF = fkF.Remove(fkF.Length - 1, 1)+") ";
                fkS = fkS.Remove(fkS.Length - 1, 1) + ");\n";
                listResult.Add(fkF + fkS);
            }

            return listResult;
        }
        public string ChangeNullable(bool nullable)
        {
            return nullable ? "NULL" : "NOT NULL";
        }

        public virtual List<string> getScriptTableAndPK()
        {
            db = CreateTable();
            db = AddPK();
            List<string> listResult = new List<string>();

            //chuyển table thành string
            string table;
            foreach (var item in db.ListTable)
            {
                table = "CREATE TABLE " + item.TableName1 + " (";
                foreach (var it in item.ListColumns)
                {
                    table = table + "\n" + it.ColumnName + " "
                        + it.TypeOfData1 + " "
                        + ChangeNullable(it.AllowNullAble) + ",";
                }
                table = table.Remove(table.Length - 1, 1) + ");\n";
                listResult.Add(table);
            }

            //chuyển khóa chính thành string
            string pk;
            foreach (var item in db.ListPK)
            {
                pk = "ALTER TABLE " + item.PkOfTable1 + " ADD CONSTRAINT "
                    + item.PKName1 + " PRIMARY KEY(";
                foreach (var it in item.ListColumnsPK)
                {
                    pk = pk + it + ",";
                }
                pk = pk.Remove(pk.Length - 1, 1) + ");\n";
                listResult.Add(pk);
            }
            return listResult;
        }

        public virtual List<string> getScriptFK()
        {
            db = AddFK();
            List<string> listResult = new List<string>();
            //chuyển khóa ngoại thành string
            string fkF;
            string fkS;
            foreach (var item in db.ListFK)
            {
                fkF = "ALTER TABLE " + item.ReferencingTable1 + " ADD FOREIGN KEY (";
                fkS = "REFERENCES " + item.ReferencedTable1 + " (";
                foreach (var x in item.ReferencingColumn1)
                {
                    fkF = fkF + x + ",";
                }
                foreach (var y in item.ReferencedColumn1)
                {
                    fkS = fkS + y + ",";
                }
                fkF = fkF.Remove(fkF.Length - 1, 1) + ") ";
                fkS = fkS.Remove(fkS.Length - 1, 1) + ");\n";
                listResult.Add(fkF + fkS);
            }

            return listResult;
        }
        public string standardizingData(object row)
        {
            if (row.ToString() != "")
            {
                string data;

                Type type = row.GetType();
                if (isNumericType(row))
                {
                    return row.ToString() + ",";
                }
                else if (type == typeof(Boolean))
                {
                    if ((bool)row)
                    {
                        return "1,";
                    }
                    else
                    {
                        return "0,";
                    }
                }
                else if (type == typeof(Byte[]))
                {
                    data = BitConverter.ToString((byte[])row).Replace("-", ""); ;
                    return "0x" + data + ",";
                }
                else if (type == typeof(DateTime) || type == typeof(DateTimeOffset))
                {
                    DateTime d = Convert.ToDateTime(row.ToString());
                    string date = d.ToString("yyyy-MM-dd hh:mm:ss");
                    return "'" + date + "',";
                }
                else
                {
                    data = row.ToString();
                    if (data.Contains("\n") || data.Contains("\r"))
                    {
                        data = data.Replace("\n", "\\n");
                        data = data.Replace("\r", "\\r");
                    }
                    if (data.Contains("'"))
                    {
                        string kq = "";
                        while (data.Contains("'"))
                        {
                            kq = kq + data.Substring(0, data.IndexOf("'")) + "\\\'";
                            data = data.Substring(data.IndexOf("'") + 1, data.Length - data.IndexOf("'") - 1);
                        }
                        return "'" + kq + data + "',";
                    }

                    return "'" + data + "',";
                }
            }
            return "null,";

        }
        public bool isNumericType(object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}

