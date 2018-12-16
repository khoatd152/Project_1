using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Project_1.DAL
{
    public class ConectSQL
    {
        SqlConnection conn ;
        SqlDataAdapter ada ;
        DataTable dt = null;
        string tableChecked;
        string sql;
        public ConectSQL()
        {
        }
        public SqlConnection getConn(){
            return conn;
        }

        public bool conectToSQL(string user, string pass,int typeConect)
        {
            try
            {
                conn = new SqlConnection();
                if (typeConect == 0)
                {
                    conn.ConnectionString =
                    "Data Source=localhost;" +
                    "Initial Catalog=master; " +
                    "Integrated Security=True;";
                }
                else
                {
                    conn.ConnectionString =
                    "Data Source=localhost;" +
                    "Initial Catalog=master; " +
                     "User Id = " + user + ";" +
                    "Password = " + pass;
                }
                conn.Open();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
                
        }
        public void disconectSQL()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void changeDB(string nameDB)
        {
            conn.ChangeDatabase(nameDB);
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
        public DataTable getTableStructure()
        {
            sql = "SELECT TABLE_NAME ,COLUMN_NAME ,IS_NULLABLE,"
                   + "DATA_TYPE ,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,"
                    + "NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME in "
                    + tableChecked;
            ada = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getPK()
        {
            sql = "SELECT i.name AS IndexName, OBJECT_NAME(ic.OBJECT_ID) AS TableName, "
                + "COL_NAME(ic.OBJECT_ID,ic.column_id) AS ColumnName FROM sys.indexes AS i "
                 + "INNER JOIN sys.index_columns AS ic ON i.OBJECT_ID = ic.OBJECT_ID "
                  + "AND i.index_id = ic.index_id WHERE i.is_primary_key = 1 and OBJECT_NAME(ic.OBJECT_ID) in "
                  + tableChecked + " order by TableName";
            ada = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getFK()
        {
            sql = "SELECT f.name constraint_name,OBJECT_NAME(f.parent_object_id) referencing_table_name "
               + ",COL_NAME(fc.parent_object_id, fc.parent_column_id) referencing_column_name "
              + ",OBJECT_NAME (f.referenced_object_id) referenced_table_name "
               + ",COL_NAME(fc.referenced_object_id, fc.referenced_column_id) referenced_column_name  "
                + " FROM sys.foreign_keys AS f  "
                + "INNER JOIN sys.foreign_key_columns AS fc  "
               + " ON f.object_id = fc.constraint_object_id  "
                + "where OBJECT_NAME(f.parent_object_id) in " + tableChecked
                + "and OBJECT_NAME (f.referenced_object_id) in " + tableChecked
               + " ORDER BY f.name";
            ada = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getDataByTableName(string table)
        {
            
                ada = new SqlDataAdapter("select * from [" + table+"]", conn);
            
            
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getTableNameInChecked()
        {
            sql = "select name as TableName from sys.tables where name in " + tableChecked;
            ada = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getAllDataBase()
        {
            ada = new SqlDataAdapter("SELECT name FROM sys.databases where LEN(owner_sid)>1;", conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getAllTableName()
        {
            ada = new SqlDataAdapter("select name as TableName from sys.tables where name != 'sysdiagrams'", conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public DataTable getTableByName(string name)
        {
            ada = new SqlDataAdapter("select * from " + name, conn);
            dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }


    }
}
