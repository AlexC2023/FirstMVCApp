using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembershipTypesRepository(ProgrammingClubDataContext context) => _context = context;

        public DbSet<MembershipTypeModel> GetAllMembershipTypes()
        {
            return _context.MembershipTypes;
        }

        public DbSet<MembershipTypeModel> GetAll()
        {
            return _context.MembershipTypes;
        }

        internal void AddMembershipType(MembershipTypeModel model)
        {
            _context.MembershipTypes.Add(model);
            _context.SaveChanges();
        }

        public MembershipTypeModel FindById(Guid id)
        {
            return _context.MembershipTypes.FirstOrDefault(a => a.IDMembershipType == id);
        }

        internal void UpdateMembershipType(Guid id, MembershipTypeModel model)
        {
            _context.MembershipTypes.Update(model);
            _context.SaveChanges();
        }

        public void DeleteMembershipType(MembershipTypeModel model)
        {
            _context.MembershipTypes.Remove(model);
            _context.SaveChanges();
        }
    }
}
