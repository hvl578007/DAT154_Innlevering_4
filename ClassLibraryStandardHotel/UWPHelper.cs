using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryStandardHotel
{
    public class UWPHelper
    {
    }
    
    public enum TaskType
    {
        CleaningService,
        RoomService,
        Maintenace
    }

    public enum TaskState
    {
        New,
        InProgress,
        Finished
    }
}
