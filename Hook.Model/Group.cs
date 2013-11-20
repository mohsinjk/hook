using System;

namespace Hook.Model
{
    public class Group
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
        public string GroupName { get; set; }
    }
}
