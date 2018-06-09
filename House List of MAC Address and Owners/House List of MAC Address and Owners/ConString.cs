using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace House_List_of_MAC_Address_and_Owners
{
    class ConString
    {
        public static string oledbString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OwnerandMacAddress.accdb;";
        public static string connect
        {
            get
            {
                return oledbString;
            }
            set
            {
                oledbString = value;
            }
        }
    }
}
