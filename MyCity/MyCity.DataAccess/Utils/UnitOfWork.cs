using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Repositories;
using MyCity.Core.Domain;

namespace MyCity.DataAccess.Utils
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(
            ApplicationDbContext context, 
            IRepository<Role> rolesRepository, 
            IRepository<User> usersRepository,
            IRepository<MediaFile> mediaFilesRepository,
            IRepository<Review> reviewRepository,
            IRepository<PointOfInterest> pointOfInterestRepository,
            IRepository<Route> routeRepository,
            IRepository<CustomStop> customStopRepository)
        {
            _context = context;
            RolesRepository = rolesRepository;
            UsersRepository = usersRepository;
            MediaFilesRepository = mediaFilesRepository;
            ReviewRepository = reviewRepository;
            RouteRepository = routeRepository;
            CustomStopRepository = customStopRepository;
            PointOfInterestRepository = pointOfInterestRepository;
        }

        public IRepository<Role> RolesRepository { get; }
        public IRepository<User> UsersRepository { get; }
        public IRepository<MediaFile> MediaFilesRepository { get; }
        public IRepository<Review> ReviewRepository { get; }
        public IRepository<PointOfInterest> PointOfInterestRepository { get; }
        public IRepository<CustomStop> CustomStopRepository { get; }
        public IRepository<Route> RouteRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
