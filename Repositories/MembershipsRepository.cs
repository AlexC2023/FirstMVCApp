using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {
        // clasele de tip repository sunt clase care implementeaza operatiile CRUD pe Baza de date

        private readonly ProgrammingClubDataContext _context;

        public MembershipsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<MembershipModel> GetMemberships()
        {
            return _context.Memberships;
        }

        public void Add(MembershipModel model)
        {
            model.IDMembership = Guid.NewGuid();
            _context.Memberships.Add(model);
            _context.SaveChanges();
        }

        public MembershipModel GetMembershipById(Guid id)
        {
            MembershipModel model = _context.Memberships.FirstOrDefault(a => a.IDMembership == id);
            return model;
        }

        public void Update(MembershipModel member)
        {
            _context.Memberships.Update(member);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var member = _context.Memberships.FirstOrDefault(a => a.IDMembership == id);
            _context.Memberships.Remove(member);
            _context.SaveChanges();
        }
    }
}
