namespace SmallestNumberTrifon.Contracts
{
    public interface ISettings
    {
        bool AddLimit(int id, int limit);
        int GetLimit();
    }
}
