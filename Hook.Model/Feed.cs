using System;

namespace Hook.Model
{
    public class Feed
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime MessageDateTime { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
