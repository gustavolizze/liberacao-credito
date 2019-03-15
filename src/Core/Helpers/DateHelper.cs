using System;

namespace Core.Helpers
{
    public class DateHelper
    {
        public static DateTime ConvertDateString(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                throw new Exception("Informe uma data válida");

            if (dateString.Length < 10)
                throw new Exception("Informe uma data válida");

            var dia = Convert.ToInt32(dateString.Substring(0, 2));
            var mes = Convert.ToInt32(dateString.Substring(3, 2));
            var ano = Convert.ToInt32(dateString.Substring(6, 4));

            return new DateTime(ano, mes, dia);
        }
    }
}
