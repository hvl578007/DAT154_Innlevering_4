using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHotel
{
    class HotelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            Random rnd = new Random();
            int numOfRoomsCreated = 20;
            var rooms = new List<Room>();
            for (int i = 0; i < numOfRoomsCreated; i++)
            {
                int beds = rnd.Next(1, 5); //få mellom 1-4
                int size = rnd.Next(0, 3); //få mellom 0-2
                context.Rooms.Add(new Room { RoomId = (i + 1), NumOfBeds = beds, Size = size });
            }
            context.Users.Add(new User { Name = "Test Person", Username = "TestPerson" });
            context.Reservations.Add(new Reservation { ReservationId = 0, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(1), RoomRoomId = 1, UserUsername="TestPerson", CheckedIn=false, CheckedOut=false });
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
