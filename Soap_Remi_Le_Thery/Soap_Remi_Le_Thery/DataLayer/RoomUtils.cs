using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soap_Remi_Le_Thery.DataLayer
{
    public class RoomUtils
    {
        internal static Rooms LookForRoom(int schoolID, string roomName)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                return dbContext.Rooms.FirstOrDefault(f => f.SchoolId == schoolID && f.Number == roomName);
            }
        }

        internal static Rooms LookForRoom(int schoolID, int roomID)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                return dbContext.Rooms.FirstOrDefault(f => f.SchoolId == schoolID && f.Id == roomID);
            }
        }


        internal static int InsertRoom(int schoolID, string roomName)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                dbContext.Rooms.Add(new Rooms { SchoolId = schoolID, Number = roomName });
                return dbContext.SaveChanges();
            }
        }

        internal static int ModifyRoomName(int schoolID, int roomID, string newRoomName)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Rooms roomToRename;
                roomToRename = dbContext.Rooms.FirstOrDefault(f => f.SchoolId == schoolID && f.Id == roomID);
                roomToRename.Number = newRoomName;
                return dbContext.SaveChanges();
            }
        }

        internal static int DeleteRoomByID(int schoolID, int roomID)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Rooms roomToDelete;
                roomToDelete = dbContext.Rooms.FirstOrDefault(f => f.SchoolId == schoolID && f.Id == roomID);
                dbContext.Rooms.Remove(roomToDelete);
                return dbContext.SaveChanges();
            }
        }

        internal static int DeleteRoomByName(int schoolID, string roomName)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Rooms roomToDelete;
                roomToDelete = dbContext.Rooms.FirstOrDefault(f => f.SchoolId == schoolID && f.Number == roomName);
                dbContext.Rooms.Remove(roomToDelete);
                return dbContext.SaveChanges();
            }
        }

        internal static int DeleteAllRoomsInSchool(int schoolID)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                dbContext.Rooms.RemoveRange(dbContext.Rooms.Where(f => f.SchoolId == schoolID));
                dbContext.SaveChanges();
                return dbContext.SaveChanges();
            }
        }
    }
}