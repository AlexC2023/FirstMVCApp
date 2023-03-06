using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }
    }
}
