using System;

namespace Hook.Model
{
    public class Follow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
        public int FollowUserId { get; set; }
        public UserInfo FollowUser { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
