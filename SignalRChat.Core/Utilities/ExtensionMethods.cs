using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Core.Utilities
{
    public static class ExtensionMethods
    {
        public static string ToInnerFormatString(this Exception ex)
        {
            string msg = "";
            try
            {
                msg = ex.Message + "\n" +
                    ex.InnerException?.Message + "\n" +
                    ex.InnerException?.InnerException?.Message + "\n" +
                    ex.InnerException?.InnerException?.InnerException?.Message + "\n" +
                    ex.InnerException?.InnerException?.InnerException?.InnerException?.Message + "\n" +
                    ex.InnerException?.InnerException?.InnerException?.InnerException?.InnerException?.Message + "\n" +
                    ex.InnerException?.InnerException?.InnerException?.InnerException?.InnerException?.InnerException?.Message;
            }
            catch (System.Exception)
            {
                msg = ex.Message;
            }
            return msg;
        }


        public static string Md5Create(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(str);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
