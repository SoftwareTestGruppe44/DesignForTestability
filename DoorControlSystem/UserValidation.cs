using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DoorControlSystem
{
    public class UserValidation
    { 
        List<int> idList = new List<int>();

        bool ValidateEntryRequest(int id)
        {
            return idList.Contains(id);
        }

        void AddId(int id)
        {
            idList.Add(id);
        }
    }
}