using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DoorControlSystem
{
    public class UserValidation : IUserValidation
    {
        readonly List<int> _idList = new List<int>();

        public bool ValidateEntryRequest(int id)
        {
            return _idList.Contains(id);
        }

        public void AddId(int id)
        {
            _idList.Add(id);
        }
    }
}