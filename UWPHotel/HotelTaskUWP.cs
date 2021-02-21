using System;
using System.Collections.Generic;
using System.Text;

namespace UWPHotel
{
    /// <summary>
    /// Denne klassen føl JSON-output av Web-API til WebFormsHotel-appen - MÅ endre på om Task blir endra på!
    /// For bruk i UWP appen (WebFormsHotel / Desktop brukar .NET Framework og jobbar ikkje i lag med UWP så lett)
    /// </summary>
    public class HotelTaskUWP
    {
        public HotelTaskUWP() { }
        public int TaskId { get; set; }
        public string Note { get; set; }
        public string Info { get; set; }
        public int State { get; set; }
        public int Type { get; set; }
        public int RoomRoomId { get; set; }
    }
}
