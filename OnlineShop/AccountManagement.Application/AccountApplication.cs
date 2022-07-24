using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository,
            IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _emailService = emailService;
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            var accountBy = _accountRepository.GetBy(command.Username);
            if (_accountRepository.Exists(x => x.Email == command.Email || x.Mobile == command.Mobile))
                return operation.Failed("حساب کاربری با این مشخصات وجود دارد . می توانید وارد حساب کاربری خود شوید");


            if (accountBy is {IsActive: true})
                return operation.Succeeded("کاربر گرامی کد فعال سازی حساب کاربری  به ایمیل شما ارسال شده است.");
            //Hashing Password
            var password = _passwordHasher.Hash(command.Password);

            //Picture Path
            var path = $"ProfilePhotos //{command.Username}";

            //Save Picture in Path
            var fileName = _fileUploader.Upload(command.ProfilePhoto, path);

            //Generate Active Code
            var activeCode = AccountCodeGenerator.Generate();

            var account = new Account(command.Fullname, command.Username, command.Email, password, command.Mobile,
                fileName,
                activeCode,
                command.RoleId);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            _emailService.SendEmail(command.Email, "ثبت نام موفق!",
                $"به سایت کالا مارکت خوش آمدید \n از طریق لینک زیر وارد شوید\n{"https://localhost:5001/ActiveAccount/" + activeCode}");
            return operation.Succeeded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            //Picture Path
            var path = $"ProfilePhotos//{command.Username}";
            //Save Picture in Path
            var fileName = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username, command.Email, command.Mobile, fileName,
                command.ActiveCode,
                command.RoleId);

            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordNotMatch);

            //Hashing Password
            var password = _passwordHasher.Hash(command.Password);

            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Email);

            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            //Check for Valid password in Database 
            var result = _passwordHasher.Check(account.Password, command.Password);


            var permission = _roleRepository
                .Get(account.RoleId)
                .Permissions
                .Select(x => x.Code).ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, account.Username,
                account.Mobile, account.Email, permission);
            _authHelper.Signin(authViewModel);
            return operation.Succeeded();
        }

        public OperationResult Active(string activeCode)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetByCode(activeCode);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (account.IsActive)
                return operation.Succeeded();

            account.Active();
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(id);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (account.IsActive)
                return operation.Succeeded();

            account.Active();
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }
    }
}
