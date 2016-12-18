namespace ShopService.Conventions
{
    public interface IInitializable
    {
        int Order { get; }
        void Initialize();
    }
}