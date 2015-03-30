using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BM_TimeTracker.Classes
{
    public class Hash
    {

        public static string HashString(string strInput, string strSalt)
        {//generiere einen hash mitm salt aus dem eingegangen Text
            SHA256Managed sh1 = new SHA256Managed();
            byte[] data = sh1.ComputeHash(Encoding.UTF8.GetBytes(strInput + strSalt));

            StringBuilder sBuild = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuild.Append(data[i].ToString("X2"));
            }
            return sBuild.ToString();
        }
    }
}
