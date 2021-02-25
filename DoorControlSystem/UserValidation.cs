using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DoorControlSystem
{
    public class UserValidation
    {
        readonly List<int> _idList = new List<int>();

        bool ValidateEntryRequest(int id)
        {
            return _idList.Contains(id);
        }

        void AddId(int id)
        {
            _idList.Add(id);
        }
    }
}