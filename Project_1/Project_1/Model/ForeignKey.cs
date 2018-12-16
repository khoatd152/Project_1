using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    class ForeignKey
    {
        string FKName;

        public string FKName1
        {
            get { return FKName; }
            set { FKName = value; }
        }
        string ReferencingTable;

        internal string ReferencingTable1
        {
            get { return ReferencingTable; }
            set { ReferencingTable = value; }
        }
        List<string> ReferencingColumn;

        internal List<string> ReferencingColumn1
        {
            get { return ReferencingColumn; }
            set { ReferencingColumn = value; }
        }
        string ReferencedTable;

        internal string ReferencedTable1
        {
            get { return ReferencedTable; }
            set { ReferencedTable = value; }
        }
        List<string> ReferencedColumn;

        internal List<string> ReferencedColumn1
        {
            get { return ReferencedColumn; }
            set { ReferencedColumn = value; }
        }
        public ForeignKey()
        {
            ReferencingColumn = new List<string>();
            ReferencedColumn = new List<string>();
        }
    }
}
