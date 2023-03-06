using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;

        private readonly MembersRepository _membersrepository;
        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersrepository)
        {
            _repository = repository;
            _membersrepository = membersrepository;
        }
        public IActionResult Index()
        {
            var model = _repository.GetCodeSnippets();
            return View("Index", model);
        }

        public ActionResult Create()
        {
            var members = _membersrepository.GetMembers();
            ViewBag.data = members;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel model = new CodeSnippetModel();          // se creaza un model nou pentru inserarea in baza de date
            TryUpdateModelAsync(model);                                 // mapeaza datele din colectie - formular - pe modelul creat local
            _repository.Add(model);                                     // se transmite modelul spre ORM


            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var model = _repository.GetCodeSnippetById(id);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            CodeSnippetModel model = new();
            TryUpdateModelAsync(model);
            _repository.Update(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetCodeSnippetById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            var model = _repository.GetCodeSnippetById(id);
            return View("Delete", model);
        }

    }
}

