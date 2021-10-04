namespace WatchList
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public Type Type { get; protected set; }
    }
}