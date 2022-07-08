using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Mobile { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        public long RoleId { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
