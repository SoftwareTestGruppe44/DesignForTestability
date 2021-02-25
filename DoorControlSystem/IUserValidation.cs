namespace DoorControlSystem
{
    public interface IUserValidation
    {
        bool ValidateEntryRequest(int id);
        void AddId(int id);
    }
}