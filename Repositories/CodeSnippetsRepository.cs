using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {
        // clasele de tip repository sunt clase care implementeaza operatiile CRUD pe Baza de date

        private readonly ProgrammingClubDataContext _context;

        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }


        // metoda echivalenta Get
        public DbSet<CodeSnippetModel> GetCodeSnippets()
        {
            return _context.CodeSnippets;
        }

        public void Add(CodeSnippetModel model)
        {
            model.IDCodeSnippet = Guid.NewGuid();  //setam id-ul
            _context.CodeSnippets.Add(model);      // adaugam modelul in layerul ORM
            _context.SaveChanges();                 // commit to database
        }


        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            CodeSnippetModel model = _context.CodeSnippets.FirstOrDefault(a => a.IDCodeSnippet == id);
            return model;
        }


        public void Update(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.CodeSnippets.Remove(GetCodeSnippetById(id));
            _context.SaveChanges();
        }
    }
}

