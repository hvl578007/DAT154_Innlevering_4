using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHotel
{
    public class HotelController
    {

        public static List<Room> RetrieveAvaliableRooms(HotelContext hcx, int beds, int quality, DateTime dateStart, DateTime dateEnd)
        {
            hcx.Rooms.Load();
            hcx.Reservations.Load();
            return hcx.Rooms.Local
                .Where(r => r.NumOfBeds >= beds && r.Size >= quality)
                .Where(r =>
                {
                    bool notConflictingRes = r.Reservations.All(res =>
                    {
                        bool isBefore = res.DateStart.CompareTo(dateStart) < 0 && res.DateEnd.CompareTo(dateStart) < 0;
                        bool isAfter = res.DateStart.CompareTo(dateEnd) > 0 && res.DateEnd.CompareTo(dateEnd) > 0;
                        return isBefore || isAfter;
                    });
                    bool emptyRes = r.Reservations.Count == 0 || r.Reservations == null;
                    return notConflictingRes || emptyRes;
                    //var obj = r.Reservations.FirstOrDefault(res => !res.CheckedOut);
                    //return obj == null;
                }).ToList();
        }
    }
}
