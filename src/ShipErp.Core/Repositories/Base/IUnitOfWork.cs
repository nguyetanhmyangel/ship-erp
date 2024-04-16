namespace ShipErp.Core.Repositories.Base;
public interface IUnitOfWork
{
    IPostRepository Posts { get; }
    IUserRepository Users { get; }
    Task<int> CompleteAsync();
}
