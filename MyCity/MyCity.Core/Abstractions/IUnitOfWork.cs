using MyCity.Core.Abstractions.Repositories;
using MyCity.Core.Domain;

namespace MyCity.Core.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Role> RolesRepository { get; }
        IRepository<User> UsersRepository { get; }
        IRepository<MediaFile> MediaFilesRepository { get; }
        IRepository<Review> ReviewRepository { get; }
        IRepository<PointOfInterest> PointOfInterestRepository { get; }
        IRepository<CustomStop> CustomStopRepository { get; }
        IRepository<Route> RouteRepository { get; }

        Task SaveChangesAsync();
    }
}
