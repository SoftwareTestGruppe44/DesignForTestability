namespace DoorControlSystem
{
    public interface IEntryNotification
    {
        void NotifyEntryGranted(int id);
        void NotifyEntryDenied(int id);
    }
}