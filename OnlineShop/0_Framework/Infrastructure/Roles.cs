namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "3";


        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";
                case 3:
                    return "محتوا گذار";
                default:
                    return "";
            }
        }
    }
}
