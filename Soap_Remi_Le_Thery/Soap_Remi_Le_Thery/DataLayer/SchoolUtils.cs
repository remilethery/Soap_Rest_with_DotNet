using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soap_Remi_Le_Thery.DataLayer
{
    public class SchoolUtils
    {

        // General methods to get a school by name or ID
        // Uses subs methods below
        internal static Schools LookForSchool(string name)
        {
            // Looking if School name already existing in DB
            return GetSchoolByName(name);
        }

        internal static Schools LookForSchool(int? id)
        {
            return GetSchoolByID((int)id);
        }

        // Method to insert a school in DB
        internal static int InsertSchool(string name)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                dbContext.Schools.Add(new Schools { Name = name });
                return dbContext.SaveChanges();
            }
        }

        // Method to get a school by ID, using entity
        internal static Schools GetSchoolByID(int id)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                return dbContext.Schools.FirstOrDefault(f => f.Id == id);
            }
        }

        // Method to get a school by Name, using entity
        internal static Schools GetSchoolByName(string name)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                return dbContext.Schools.FirstOrDefault(f => f.Name == name);
            }
        }

        // Method to modify a school name
        internal static int ModifySchoolName(int id, string newName)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Schools renamedSchool = dbContext.Schools.FirstOrDefault(f => f.Id == id);
                renamedSchool.Name = newName;
                return dbContext.SaveChanges();
            }
        }
        // Method to delete a school by ID
        internal static int DeleteSchool(int id)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Schools deletedSchool;
                deletedSchool = dbContext.Schools.FirstOrDefault(f => f.Id == id);
                dbContext.Schools.Remove(deletedSchool);
                return dbContext.SaveChanges();
            }
        }
        // Method to delete a school by Name
        internal static int DeleteSchool(string name)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Schools deletedSchool = new Schools();
                deletedSchool = dbContext.Schools.FirstOrDefault(f => f.Name == name);
                dbContext.Schools.Remove(deletedSchool);
                return dbContext.SaveChanges();
            }
        }
        // Method to check if a school has rooms
        internal static bool SchoolHadRooms(Schools deletingSchool)
        {
            using (schoolEntities dbContext = new schoolEntities())
            {
                Rooms deletedRooms = new Rooms();
                deletedRooms = dbContext.Rooms.FirstOrDefault(f => f.SchoolId == deletingSchool.Id);
                return (deletedRooms != null);
            }
        }
    }
}