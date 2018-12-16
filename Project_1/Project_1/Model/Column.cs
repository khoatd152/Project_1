using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    class Column
    {
        string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        string TypeOfData;

        public string TypeOfData1
        {
            get { return TypeOfData; }
            set { TypeOfData = value; }
        }
        bool allowNullAble;

        public bool AllowNullAble
        {
            get { return allowNullAble; }
            set { allowNullAble = value; }
        }


        public Column(string name, string TypeOfData, bool AllowNullAble)
        {
            this.ColumnName = name;
            this.TypeOfData = TypeOfData;
            this.allowNullAble = AllowNullAble;
        }
        public Column()
        {

        }
    }
}
