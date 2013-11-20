using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hook.App.Controllers;
using Hook.Data.Contracts;
using Hook.Controllers;
using Hook.Data;
using System.Web.Http;
using NSubstitute;
using Hook.Model;
using System.Linq;
namespace Hook.UnitTest
{
    [TestClass]
    public class UserControllerTest
    {
        IUnitOfWork fakeUow=null;
        public UserControllerTest()
        {
            fakeUow = Substitute.For<IUnitOfWork>();
        }
        
        [TestMethod]
        public void Auth_KnownUser()
        {
            User user = new User();
            user.UserName = "usera";
            user.Password = "aaa";
            UserInfo userInfo = new UserInfo();
            userInfo.FullName = "Full Name A";
            userInfo.Email = "email";
            userInfo.CompanyName = "Company A";
            userInfo.PhoneNumber = "0800 333 4444";
            userInfo.Information = "Something about user";
            user.UserInfo = userInfo;

            // setting up room repository so that it returns a collection of one room
            var fakeUserRepository = Substitute.For<IUserRepository>();
            var fakeUsersQueryable = new[] { user }.AsQueryable();
            fakeUserRepository.GetAll().Returns<IQueryable<User>>(fakeUsersQueryable);

            // connect UOW with room repository
            fakeUow.Users.Returns(fakeUserRepository);

            var fake = Substitute.For<IUnitOfWork>();
            var controller = new UserController(fakeUow);

            var result = controller.Auth("usera", "aaa");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Auth_UnknownUser()
        {
            User user = new User();
            user.UserName = "usera";
            user.Password = "aaa";
            UserInfo userInfo = new UserInfo();
            userInfo.FullName = "Full Name A";
            userInfo.Email = "email";
            userInfo.CompanyName = "Company A";
            userInfo.PhoneNumber = "0800 333 4444";
            userInfo.Information = "Something about user";
            user.UserInfo = userInfo;

            // setting up room repository so that it returns a collection of one room
            var fakeUserRepository = Substitute.For<IUserRepository>();
            var fakeUsersQueryable = new[] { user }.AsQueryable();
            fakeUserRepository.GetAll().Returns<IQueryable<User>>(fakeUsersQueryable);

            // connect UOW with room repository
            fakeUow.Users.Returns(fakeUserRepository);

            var fake = Substitute.For<IUnitOfWork>();
            var controller = new UserController(fakeUow);

            var result = controller.Auth("userb", "bbb");
            Assert.IsNull(result);
        }
    }
}
