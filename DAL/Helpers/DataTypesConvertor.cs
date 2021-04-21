using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
   public class DataTypesConvertor
    {
        public static DateTime ConvertToDateTime(object datetimeval)
        {

            DateTime result = DateTime.MaxValue;

            if (datetimeval != null)
            {
                DateTime.TryParse(datetimeval.ToString(), out result);
            }

            return result;
        }

        public static Guid ConvertToGuid(string stringGuid)
        {
            Guid result = new Guid("00000000-0000-0000-0000-000000000000");
            if (stringGuid != null)
            {
                Guid.TryParse(stringGuid, out result);
            }

            return result;
        }
        public static double ConvertToDouble(object number)
        {
            double result = Convert.ToDouble("0");
            if (number != null)
            {
                Double.TryParse(number.ToString(), out result);

            }

            return result;
        }

        public static int ConvertToInt(object number)
        {
            int result = 0;
            if (number != null)
            {
                int.TryParse(number.ToString(), out result);
            }

            return result;
        }
        public static decimal ConvertToDecimal(object number)
        {
            decimal result = Convert.ToDecimal("0");
            if (number != null)
            {
                Decimal.TryParse(number.ToString(), out result);

            }

            return result;
        }
    }
}
