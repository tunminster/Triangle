using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Triangle.UserManagement.Core.Interfaces;
using Triangle.Web.Models.UserManagementModels;
using Triangle.UserManagement.Core.Model.UserAggregate;

namespace Triangle.Web.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserManagementController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var result = _userRepository.GetUserList();
            return View(Mapper.Map<List<UserViewModel>>(result));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                model.Added = DateTime.Now;
                model.Updated = DateTime.Now;
                
                _userRepository.AddUser(Mapper.Map<User>(model));
                return RedirectToAction("index");
            }

            return View();
        }

    }
}