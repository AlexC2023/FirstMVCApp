using FirstMVCApp.DataContext;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipsRepository(ProgrammingClubDataContext context) => _context = context;
        
    }
}
