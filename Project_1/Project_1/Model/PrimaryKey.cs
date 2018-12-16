using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    class PrimaryKey
    {
        string PKName;

        public string PKName1
        {
            get { return PKName; }
            set { PKName = value; }
        }
        string PkOfTable;

        internal string PkOfTable1
        {
            get { return PkOfTable; }
            set { PkOfTable = value; }
        }
        List<string> listColumnsPK;

        internal List<string> ListColumnsPK
        {
            get { return listColumnsPK; }
            set { 
                listColumnsPK = value; 
            }
        }
        public PrimaryKey()
        {
            listColumnsPK = new List<string>();
        }
    }
}
