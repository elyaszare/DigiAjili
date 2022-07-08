namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();
        void SignOut();
        void Signin(AuthViewModel account);
    }
}
