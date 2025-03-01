using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MisaintLibrary
{
    public static class RFCValidator
    {
        public static bool ValidateRFC(string rfc)
        {
            rfc = RFCCorrect(rfc);

            return Regex.IsMatch(rfc, @"^[A-ZÑ&]{4}\d{6}[A-Z0-9]\d{2,3}$");
        }

        public static string RFCCorrect(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc))
                return String.Empty;
            return rfc.Trim().ToUpper();
        }
    }
}
