using Book_Management.Models.Database;

namespace Book_Management.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
    }
}
