using System;

namespace Hook.Model
{
    public class Favorite
    {
        public int Id { get; set; }
        public int FeedId { get; set; }
        public Feed Feed { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
    }
}
