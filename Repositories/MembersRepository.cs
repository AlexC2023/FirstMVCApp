using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembersRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<MemberModel> GetMembers()
        {
            return _context.Members;
        }

        public void AddMember(MemberModel member) 
        {
            member.IDMember = Guid.NewGuid();
            _context.Members.Add(member);
            _context.SaveChanges(); 
        }

        public MemberModel GetMemberById(Guid id) 
        {
            return _context.Members.FirstOrDefault(a => a.IDMember == id);
        }

        public void UpdateMember(MemberModel member) 
        { 
            _context.Members.Update(member);    
            _context.SaveChanges();
        }

        public void DeleteMemberById(Guid id)
        {
            var member = _context.Members.FirstOrDefault(a=>a.IDMember == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public MemberCodeSnippetViewModel GetMemberCodeSnippet(Guid id)
        {
            MemberCodeSnippetViewModel memberCodeSnippetViewModel = new MemberCodeSnippetViewModel();
            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == id);
            if (member != null)
            {
                memberCodeSnippetViewModel.Name = member.Name;
                memberCodeSnippetViewModel.Position = member.Position;
                memberCodeSnippetViewModel.Title = member.Title;

                IQueryable<CodeSnippetModel> memberCodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == id); //atunci cand dorim sa facem increase
                                                                                                                      //la performanta daca ne e permis

                foreach (CodeSnippetModel dbCodeSnippet in memberCodeSnippets)
                {
                    memberCodeSnippetViewModel.CodeSnippets.Add(dbCodeSnippet);
                }

            }
            return memberCodeSnippetViewModel;
        }
    }
}
