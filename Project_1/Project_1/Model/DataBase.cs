using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    public class DataBase
    {
        string DataBaseName;

        public string DataBaseName1
        {
            get { return DataBaseName; }
            set { DataBaseName = value; }
        }
        List<Table> listTable;

        internal List<Table> ListTable
        {
            get { return listTable; }
            set { listTable = value; }
        }

        
        List<ForeignKey> listFK;

        internal List<ForeignKey> ListFK
        {
            get { return listFK; }
            set { listFK = value; }
        }
        List<PrimaryKey> listPK;

        internal List<PrimaryKey> ListPK
        {
            get { return listPK; }
            set { listPK = value; }
        }

        public DataBase()
        {
            listFK = new List<ForeignKey>();
            listPK = new List<PrimaryKey>();
            listTable = new List<Table>();
            
        }
    }
}
