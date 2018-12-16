using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    class Table
    {
        string TableName;

        public string TableName1
        {
            get { return TableName; }
            set { TableName = value; }
        }
        List<Column> listColumns;

        public List<Column> ListColumns
        {
            get { return listColumns; }
            set { listColumns = value; }
        }

        public Table()
        {
            listColumns = new List<Column>();
            data = new DataTable();
        }

        DataTable data;

        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
