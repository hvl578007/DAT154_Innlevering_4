using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHotel
{
    public class RoomHelper
    {
        public static string ConvertQualityToText(string str)
        {
            int x = int.Parse(str);
            return ((RoomQuality)x).ToString();
        }
    }

    public enum RoomQuality
    {
        Ok,
        Good,
        Amazing
    }


}
