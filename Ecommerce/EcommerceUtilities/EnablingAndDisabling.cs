using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceUtilities
{
    public static class EnablingAndDisabling
    {
        private const string Enable = "Enable";
        private const string Disable = "Disable";
        public static string ReturnCategoryStatus(string status)
        {
            return status=="True" ? Enable : Disable;
        }
        public static string EnableDisableLiteral(bool status)
        {
            return status ? Enable : Disable;
        }
        public static List<string> EnableDisableCommandNames()
        {
            return new List<string>() { Enable, Disable };
        }

        public static bool ReturnBoolBasedOnEnableDisableLiteral(string strEnableDisable)
        {
            return strEnableDisable != Enable;
        }
        public static string ReturnConcanetatedCommandNameWithRowIndex(string rowIndex,bool commandName)
        {
            return rowIndex +","+EnableDisableLiteral(commandName);
        }
        public static bool ReturnCommandNameWithRowIndex(string commandArgument,out int rowIndex,out string commandName)
        {
            try
            {
                var strCollections = commandArgument.Split(',');
                if(strCollections.Length==2)
                {
                    rowIndex = Convert.ToInt32(strCollections[0].ToString());
                    commandName = strCollections[1].ToString();
                    return true;
                }
               
            }
            catch (Exception)
            {
                
                
            }
            rowIndex = -1;
            commandName = string.Empty;
            return false;
        }

        public static string ReturnOneOrZero(bool status)
        {
            return status ? "1": "0";
        }
        public static bool ReturnBooleanFromOneOrZero(string status)
        {
            return status == "1";
        }


        public static string ReturnStringValueBasedOnInt(int val)
        {
            return val==0 ? Disable : Enable;
        }
    }
}
