using Project_1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.BL
{
    public class LoginAndGetDataForMain
    {
        private ConectSQL connSQL;

        public ConectSQL ConnSQL
        {
            get { return connSQL; }
            set { connSQL = value; }
        }

        
        public LoginAndGetDataForMain()
        {
            connSQL = new ConectSQL();
        }
        public bool LoginSQL(string tk, string mk, int typeConect)
        {

            if (connSQL.conectToSQL(tk, mk, typeConect))
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getAllDataBase()
        {
            return connSQL.getAllDataBase();
        }

        public void changeDB(string name){
            connSQL.changeDB(name);
        }
        public DataTable getAllTable()
        {
            return connSQL.getAllTableName();
        }
        
    }
}
