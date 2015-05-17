using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem.Core
{
    public class StringExtensions
    {
        public static string ConvertAccountNoToDisplay(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                return string.Empty;
            }
            var strings = new List<string>();
            int startIndex = 0;
            for (int i = 0; i < account.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    var element = account.Substring(startIndex, 4);
                    strings.Add(element);
                    startIndex = i;
                }
            }
            var newAccount = string.Join("-", strings);

            return newAccount;
        }

        public static string ConvertAccountNoToDb(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                return string.Empty;
            }
            if (account.Contains("-"))
            {
                account = account.Replace("-", "");
            }
            return account;
        }
    }
}
