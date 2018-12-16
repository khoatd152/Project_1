using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Model
{
    public class Mapping
    {
        string mssql;
        string access;
        string mysql;

        public Mapping(string a, string b, string c)
        {
            mssql = a;
            mysql = b;
            access = c;
        }
        public Mapping()
        {

        }
        public string Mssql
        {
            get { return mssql; }
            set { mssql = value; }
        }


        public string Mysql
        {
            get { return mysql; }
            set { mysql = value; }
        }


        public string Access
        {
            get { return access; }
            set { access = value; }
        }
    }
}
