using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.GetMemberships();
            return View("Index", model);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection members)
        {
            MembershipModel model = new MembershipModel();
            TryUpdateModelAsync(model);
            _repository.Add(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View("Edit", _repository.GetMembershipById(id));
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            MembershipModel model = new MembershipModel();
            TryUpdateModelAsync(model);
            _repository.Update(model);


            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetMembershipById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View("Delete", _repository.GetMembershipById(id));
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            var model = _repository.GetMembershipById(id);
            return View("Delete", model);
        }
    }
}
