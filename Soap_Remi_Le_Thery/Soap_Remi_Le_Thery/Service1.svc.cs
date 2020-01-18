using Soap_Remi_Le_Thery.DataLayer;

namespace Soap_Remi_Le_Thery
{
    public class Service1 : IService1
    {

        #region Room Services

        public int InsertRoom(int? schoolID, string roomName)
        {
            int returnCode;
            // Check if arguments are null
            if (schoolID != null && roomName != null)
            {
                // Look for school in DB
                Schools existingSchool;
                existingSchool = SchoolUtils.LookForSchool((int)schoolID);
                // If School already existing
                if (existingSchool != null)
                {
                    // Looking if room already exists
                    Rooms newRoom;
                    newRoom = RoomUtils.LookForRoom((int)schoolID, roomName);
                    if (newRoom == null)
                    {
                        // Create a new Room in DB ; returnCode = 1 if operation successful in method // 0 if not 
                        returnCode = RoomUtils.InsertRoom((int)schoolID, roomName);
                    }
                    else
                        returnCode = 0; // Room already existing
                }
                else  // School not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;

        }

        public int ModifyRoomName(int? schoolID, int? roomID, string newName)
        {
            int returnCode;
            // Check if arguments are null
            if (schoolID != null && roomID != null && newName != null)
            {
                // Look for school in DB
                Schools existingSchool;
                Rooms existingRoom;
                existingSchool = SchoolUtils.LookForSchool((int)schoolID);
                existingRoom = RoomUtils.LookForRoom((int)schoolID, (int)roomID);
                // If ID already existing => modifyname
                if (existingSchool != null && existingRoom != null)
                {
                    // Modify Room name in DB; returnCode = 1 if operation successful in method // 0 if not 
                    returnCode = RoomUtils.ModifyRoomName((int)schoolID, (int)roomID, newName);
                }
                else  // School not existing or Room not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;

        }


        public int DeleteRoomByID(int? schoolID, int? roomID)
        {
            int returnCode;
            // Check if arguments are null
            if (schoolID != null && roomID != null)
            {
                // Look for school in DB
                Schools existingSchool;
                Rooms existingRoom;
                existingSchool = SchoolUtils.LookForSchool((int)schoolID);
                existingRoom = RoomUtils.LookForRoom((int)schoolID, (int)roomID);
                // If ID already existing => modifyname
                if (existingSchool != null && existingRoom != null)
                {
                    // Delete Roomin DB ; returnCode = 1 if operation successful in method // 0 if not 
                    returnCode = RoomUtils.DeleteRoomByID((int)schoolID, (int)roomID);
                }
                else  // School not existing or Room not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }

        public int DeleteRoomByName(int? schoolID, string roomName)
        {
            int returnCode;
            // Check if arguments are null
            if (schoolID != null && roomName != null)
            {
                // Look for school in DB
                Schools existingSchool;
                Rooms existingRoom;
                existingSchool = SchoolUtils.LookForSchool((int)schoolID);
                existingRoom = RoomUtils.LookForRoom((int)schoolID, roomName);
                // If ID already existing => modifyname
                if (existingSchool != null && existingRoom != null)
                {
                    // Delete Roomin DB ; returnCode = 1 if operation successful in method // 0 if not 
                    returnCode = RoomUtils.DeleteRoomByName((int)schoolID, roomName);
                }
                else  // School not existing or Room not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }

        public int DeleteAllRoomsFromASchool(int? schoolID)
        {
            int returnCode;
            // Check if arguments are null
            if (schoolID != null)
            {
                // Look for school in DB
                Schools existingSchool;
                existingSchool = SchoolUtils.LookForSchool((int)schoolID);
                // If ID already existing => modifyname
                if (existingSchool != null)
                {
                    // Delete Roomin DB ; returnCode = 1 if operation successful in method // 0 if not 
                    returnCode = RoomUtils.DeleteAllRoomsInSchool((int)schoolID);
                }
                else  // School not existing or Room not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }


        #endregion


        #region School Services
        public int InsertSchool(string name)
        {
            int returnCode;
            if (name != null)
            {
                Schools newSchool;
                // Look for school in DB
                newSchool = SchoolUtils.LookForSchool(name);
                // If Name not existing => Create a new schol
                if (newSchool == null)
                {
                    // Create School in DB ; returnCode = 1 if operation successful in method
                    returnCode = SchoolUtils.InsertSchool(name);
                }
                else // If school already exists : return 0
                {
                    returnCode = 0;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }

        public int ModifySchool(int? id, string newName)
        {
            int returnCode;
            // Check if arguments are null
            if (id != null && newName != null)
            {
                // Look for school in DB
                Schools renamingSchool;
                renamingSchool = SchoolUtils.LookForSchool((int)id);
                // If ID already existing => modifyname
                if (renamingSchool != null)
                {
                    // Create School in DB ; returnCode = 1 if operation successful in method
                    returnCode = SchoolUtils.ModifySchoolName((int)id, newName);
                }
                else  // School not existing, returnCode = -1
                {
                    returnCode = -1;
                }
            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }

        public int DeleteSchoolByID(int? id)
        {
            int returnCode;
            // Checking id
            if (id != null)
            {
                // Looking if School exists in DB
                Schools deletingSchool;
                deletingSchool = SchoolUtils.LookForSchool((int)id);
                if (deletingSchool != null)
                {// If school exists => Try to delete
                    returnCode = SchoolUtils.DeleteSchool((int)id);
                }
                else
                {// If school not existing => School not deleted, returns 0
                    returnCode = 0;
                }

            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }

        public int DeleteSchoolByName(string name)
        {
            int returnCode;
            // Checking name
            if (name != null)
            {
                // Looking if School exists in DB
                Schools deletingSchool;
                deletingSchool = SchoolUtils.LookForSchool(name);
                if (deletingSchool != null)
                { // If school exists => Try to delete

                    // Check if school has rooms
                    if (SchoolUtils.SchoolHadRooms(deletingSchool))
                    { // Impossible to delete a school, return -1
                        returnCode = -1;
                    }
                    else
                    { // School can be deleted safely
                        returnCode = SchoolUtils.DeleteSchool(name);
                    }
                }
                else
                { // If school not existing => School not deleted, returns 0
                    returnCode = 0;
                }

            }
            else
            { // Arguments not valid
                returnCode = -1;
            }
            return returnCode;
        }



        // Code by Rémi Le Théry
        #endregion


    }
}
