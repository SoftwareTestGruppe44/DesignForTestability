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
            _door.Control = this;
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
                _entryNotification.NotifyEntryGranted(id);
                _door.Open();
            }
            else
            {
                _entryNotification.NotifyEntryDenied(id);
            }
        }

        public void DoorOpened()
        {
            if (_door.Close())
            {
                _state = States.DoorClosing;
            }
            else
            {
                _state = States.DoorBreached;
                _alarm.RaiseAlarm();
            }
        }

        public void DoorClosed()
        {
            _state = States.DoorClosed;
        }

    }
}