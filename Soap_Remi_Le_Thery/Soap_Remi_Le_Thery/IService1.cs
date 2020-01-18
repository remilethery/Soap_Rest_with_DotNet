using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Soap_Remi_Le_Thery
{

    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int InsertSchool(string name);

        [OperationContract]
        int ModifySchool(int? id, string newName);

        [OperationContract]
        int DeleteSchoolByID(int? id);

        [OperationContract]
        int DeleteSchoolByName(string name);

        [OperationContract]
        int InsertRoom(int? schoolID, string name);

        [OperationContract]
        int ModifyRoomName(int? schoolID, int? roomID, string newName);

        [OperationContract]
        int DeleteRoomByID(int? schoolID, int? roomID);

        [OperationContract]
        int DeleteRoomByName(int? schoolID, string newName);

        [OperationContract]
        int DeleteAllRoomsFromASchool(int? schoolID);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    






}
