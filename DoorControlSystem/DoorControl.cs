using System;

namespace DoorControlSystem
{
    public enum States 
    {
        DoorClosed,
        DoorOpening,
        DoorClosing,
        DoorBreached
    }

    public class DoorControl
    {
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IAlarm _alarm;
        private IUserValidation _validation;
        private States _state;

        public DoorControl(IAlarm alarm, IDoor door, IEntryNotification notification, IUserValidation validation)
        {
            _door = door;
            _entryNotification = notification;
            _alarm = alarm;
            _validation = validation;
            _state = States.DoorClosed;
        }
        public void RequestEntry(int id)
        {
            //User validation
            if (_validation.ValidateEntryRequest(id))
            {
                _state = States.DoorOpening;
                if (_door.Open())
                {
                    _entryNotification.NotifyEntryGranted(id);
                }
                else
                {
                    _state = States.DoorClosed;
                    throw new Exception("Door couldnt open");
                }
            }
            else
            {
                _entryNotification.NotifyEntryDenied(id);
            }
        }

        public void DoorOpened()
        {
            _door.Close();
            _state = States.DoorClosing;
        }

        public void DoorClosed()
        {
            _state = States.DoorClosed;
        }

        public void DoorBreached()
        {
            _door.Close();
            _alarm.RaiseAlarm();
            _state = States.DoorBreached;
        }
    }
}