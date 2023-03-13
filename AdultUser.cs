using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Adults()
        {
            var users = GetUserList();
            var adults = users.Where(user => DateTime.Now.Year - user.DateOfBirth.Year >= 18);
            return View(adults);
        }

        private IQueryable<User> GetUserList()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1) },
                new User { Id = 2, Name = "Jane Doe", DateOfBirth = new DateTime(2005, 1, 1) },
                new User { Id = 3, Name = "Bob Smith", DateOfBirth = new DateTime(1970, 1, 1) },
                new User { Id = 4, Name = "Alice Johnson", DateOfBirth = new DateTime(1995, 1, 1) },
            }.AsQueryable();
            return users;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}