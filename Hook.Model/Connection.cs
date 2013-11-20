using System;

namespace Hook.Model
{
    public class Connection
    {
        public int Id { get; set; }
        public int UserSenderId { get; set; }
        public UserInfo UserSender { get; set; }
        public int UserReceiverId { get; set; }
        public UserInfo UserReceiver { get; set; }
        public bool Accepted { get; set; }
    }
}
