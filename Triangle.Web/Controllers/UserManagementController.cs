using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Triangle.UserManagement.Core.Interfaces;
using Triangle.Web.Models.UserManagementModels;

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
    }
}