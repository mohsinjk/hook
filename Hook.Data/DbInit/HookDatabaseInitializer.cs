using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Hook.Model;
using Hook.Data;

namespace Hook.Data.DbInit
{
    public class HookDatabaseInitializer : DropCreateDatabaseIfModelChanges<HookDbContext>
    {
        protected override void Seed(HookDbContext context)
        {
            // Seed code here
            AddUsers(context);
            AddGroups(context);
            AddFollows(context);
            AddFeeds(context);
            AddFavorites(context);
        }

        private void AddUsers(HookDbContext context)
        {
            User user = new User();
            user.UserName = "conny";
            user.Password = "conny";
            UserInfo userInfo = new UserInfo();
            userInfo.FullName = "Conny Sandstrom";
            userInfo.Email = "conny.s@comaround.se";
            userInfo.CompanyName = "ComAround Scandinavia AB";
            userInfo.PhoneNumber = "+46 85 80 886 40";
            userInfo.Information = "I am a CTO";
            user.UserInfo = userInfo;
            context.Users.Add(user);

            user = new User();
            user.UserName = "erik";
            user.Password = "erik";
            userInfo = new UserInfo();
            userInfo.FullName = "Erik";
            userInfo.Email = "erik@comaround.se";
            userInfo.CompanyName = "ComAround Scandinavia AB";
            userInfo.PhoneNumber = "+46 85 80 886 40";
            userInfo.Information = "I am a TPM";
            user.UserInfo = userInfo;
            context.Users.Add(user);

            user = new User();
            user.UserName = "peter";
            user.Password = "peter";
            userInfo = new UserInfo();
            userInfo.FullName = "Peter";
            userInfo.Email = "peter@comaround.se";
            userInfo.CompanyName = "ComAround Scandinavia AB";
            userInfo.PhoneNumber = "+46 85 80 886 40";
            userInfo.Information = "I am a CEO";
            user.UserInfo = userInfo;
            context.Users.Add(user);

            user = new User();
            user.UserName = "mohsinjk";
            user.Password = "mohsinjk";
            userInfo = new UserInfo();
            userInfo.FullName = "Mohsin JK";
            userInfo.Email = "mohsin.j@comaround.se";
            userInfo.CompanyName = "ComAround Scandinavia AB";
            userInfo.PhoneNumber = "+46 85 80 886 40";
            userInfo.Information = "I am a System Developer";
            user.UserInfo = userInfo;
            context.Users.Add(user);

            context.SaveChanges();
        }

        private void AddFollows(HookDbContext context)
        {
            Follow follow = new Follow();
            follow.UserId = 1;
            follow.FollowUserId = 2;
            follow.GroupId = 1;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 1;
            follow.FollowUserId = 3;
            follow.GroupId = 1;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 2;
            follow.FollowUserId = 1;
            follow.GroupId = 2;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 2;
            follow.FollowUserId = 3;
            follow.GroupId = 2;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 2;
            follow.FollowUserId = 4;
            follow.GroupId = 2;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 3;
            follow.FollowUserId = 2;
            follow.GroupId = 3;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 3;
            follow.FollowUserId = 4;
            follow.GroupId = 3;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 4;
            follow.FollowUserId = 1;
            follow.GroupId = 4;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 4;
            follow.FollowUserId = 2;
            follow.GroupId = 4;
            context.Follows.Add(follow);

            follow = new Follow();
            follow.UserId = 4;
            follow.FollowUserId = 3;
            follow.GroupId = 4;
            context.Follows.Add(follow);

            context.SaveChanges();
        }

        private void AddFeeds(HookDbContext context)
        {
            Feed feed = new Feed();
            feed.Message = "Message 1";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 1;
            feed.GroupId = 1;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 2";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 1;
            feed.GroupId = 1;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 3";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 2;
            feed.GroupId = 2;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 4";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 2;
            feed.GroupId = 2;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 5";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 3;
            feed.GroupId = 3;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 6";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 3;
            feed.GroupId = 3;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 7";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 4;
            feed.GroupId = 4;
            context.Feeds.Add(feed);

            feed = new Feed();
            feed.Message = "Message 8";
            feed.MessageDateTime = DateTime.Now;
            feed.UserId = 4;
            feed.GroupId = 4;
            context.Feeds.Add(feed);

            context.SaveChanges();
        }

        private void AddFavorites(HookDbContext context)
        {
            Favorite favorits = new Favorite();
            favorits.UserId = 1;
            favorits.FeedId = 3;
            context.Favorites.Add(favorits);

            context.SaveChanges();
        }

        private void AddGroups(HookDbContext context)
        {
            Group groups = new Group();
            groups.UserId = 1;
            groups.GroupName = "Default";
            context.Groups.Add(groups);

            groups = new Group();
            groups.UserId = 2;
            groups.GroupName = "Default";
            context.Groups.Add(groups);

            groups = new Group();
            groups.UserId = 3;
            groups.GroupName = "Default";
            context.Groups.Add(groups);

            groups = new Group();
            groups.UserId = 4;
            groups.GroupName = "Default";
            context.Groups.Add(groups);

            context.SaveChanges();

        }
    }
}
