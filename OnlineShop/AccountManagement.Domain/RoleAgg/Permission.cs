namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public Permission(int code)
        {
            Code = code;
        }

        public Permission(int code, string name, long roleId)
        {
            Code = code;
            Name = name;
            RoleId = roleId;
        }
    }
}