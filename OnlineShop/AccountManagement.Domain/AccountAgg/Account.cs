using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string ActiveCode { get; private set; }
        public bool IsActive { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }


        public Account(string fullname, string username, string email, string password,
            string mobile, string profilePhoto, string activeCode, long roleId)
        {
            Fullname = fullname;
            Username = username;
            Email = email;
            Password = password;
            Mobile = mobile;
            ProfilePhoto = profilePhoto;
            ActiveCode = activeCode;
            IsActive = false;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 2;
        }

        public void Edit(string fullname, string username, string email, string mobile,
            string profilePhoto, string activeCode, long roleId)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            Email = email;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;

            ActiveCode = activeCode;
            IsActive = false;

            RoleId = roleId;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void Active()
        {
            IsActive = true;
        }
    }
}
