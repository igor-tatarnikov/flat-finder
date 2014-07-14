using FlatFinder.Core.Domain.Ad;
using FlatFinder.Core.Domain.User;

namespace FlatFinder.Contracts
{
    public interface IFlatFinderUow
    {
        // Save pending changes to the data store
        void Commit();

        // Repositories
        IFlatAdRepository FlatAdRepository { get; }
        IRepository<FlatInfo> FlatInfos { get; }
        IRepository<ContactInfo> ContactInfos { get; }
        IRepository<District> Districts { get; }
        IRepository<Address> Addresses { get; }
    }
}
