using Project_1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1.BL
{
    class ReadMappingFile
    {
        List<Mapping> list;

        public ReadMappingFile()
        {
        }

        public List<Mapping> getListMapping()
        {
            string tam;
            List<Mapping> list = new List<Mapping>();
            string path = "../../Mapping/mapping.txt";
            string a = Application.StartupPath;
            using (StreamReader str = new StreamReader(path))
            {
                while ((tam = str.ReadLine()) != "")
                {
                    Mapping m = new Mapping();
                    m.Mssql = tam.Substring(tam.IndexOf("!")+1, tam.IndexOf("@") - tam.IndexOf("!")-1);
                    m.Mysql = tam.Substring(tam.IndexOf("@")+1, tam.IndexOf("#") - tam.IndexOf("@")-1);
                    m.Access = tam.Substring(tam.IndexOf("#")+1, tam.Length - tam.IndexOf("#")-1);
                    list.Add(m);
                }
                
            }
            return list;
        }
    }
}
