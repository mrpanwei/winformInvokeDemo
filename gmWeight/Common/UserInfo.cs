using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gmWeight
{
    static class UserInfo
	{
        private static string userName;
        private static int terminalID;

        public static string getUserName()
        {
            return userName;
        }

        public static void setUserName(string username)
        {
            userName = username;
        }

        public static int getTerminalID()
        {
            return terminalID;
        }

        public static void setTerminalID(int terminalid)
        {
            terminalID = terminalid;
        }
	}
}
