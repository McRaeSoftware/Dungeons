using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeons.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons.Models;
using Dungeons.Data;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Dungeons.Controllers.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private List<User> GetTestUsers()
        {
            List<User> output = new List<User>
            {
                new User
                {
                    User_ID = 1,
                    Username = "TestSubject",
                    Email = "TestMail@gmail.com",
                    Password = "Super_Secure_Password_1"
                },
                new User
                {
                    User_ID = 2,
                    Username = "SecondTestSubject",
                    Email = "TestingAgain@gmail.com",
                    Password = "Super_Secure_Password_2"
                },
                new User
                {
                    User_ID = 3,
                    Username = "ThirdTestSubject",
                    Email = "TestingThirdTime@gmail.com",
                    Password = "Super_Secure_Password_3"
                }
            };
            return output;
        }

        public User NewTestUser()
        {
            var user = new User();

            user.User_ID = 4;
            user.Username = "NewTestUser";
            user.Email = "NewTestEmail@mail.com";
            user.Password = "Super_secure_Password_4";

            return user;
        }

        [TestMethod]
        public async Task IndexTest_GetUsersListAsync_Pass()
        {
            var database = new Mock<IUserDataAccess>();

            database.Setup(user => user.GetUserListAsync()).Returns(Task.FromResult<List<User>>(GetTestUsers()));

            var userController = new UserController(database.Object);

            await userController.Index();

            database.Verify(m => m.GetUserListAsync(), Times.Once);
        }

        [TestMethod]
        public void GetUserByIDTest_Pass()
        {
            var database = new Mock<IUserDataAccess>();
            var existingId = 2;

            database.Setup(user => user.GetUserByID(existingId)).Returns(Task.FromResult<User>(GetTestUsers()[1]));

            var userController = new UserController(database.Object);

            var expected = GetTestUsers()[1];
            var result = (ViewResult)userController.DisplayUser(existingId).Result;
            var actual = (User)result.Model;

            Assert.AreEqual(expected.User_ID, actual.User_ID);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
        }

        [TestMethod]
        public async Task CreateUserTest_CalledMethodOnce_Pass()
        {
            var database = new Mock<IUserDataAccess>();
            var newUser = NewTestUser();

            database.Setup(user => user.CreateUser(newUser)).Returns(Task.FromResult<bool>(true));

            var userController = new UserController(database.Object);

            await userController.CreateUser(newUser);

            database.Verify(m => m.CreateUser(newUser), Times.Once);
        }

        [TestMethod]
        public async Task UpdateUserTest_CalledMethodOnce_Pass()
        {
            var database = new Mock<IUserDataAccess>();
            var existingUser = GetTestUsers()[1];
            var existingId = 2;

            database.Setup(user => user.UpdateUser(existingUser)).Returns(Task.FromResult<bool>(true));

            var userController = new UserController(database.Object);

            await userController.UpdateUser(existingId, existingUser);

            database.Verify(m => m.UpdateUser(existingUser), Times.Once);
        }

        [TestMethod]
        public async Task DeleteUserByIDConfirmedTest_CalledMethodOnce_Pass()
        {
            var database = new Mock<IUserDataAccess>();
            var existingId = 2;

            database.Setup(user => user.DeleteUserByID(existingId)).Returns(Task.FromResult<bool>(true));

            var userController = new UserController(database.Object);

            await userController.DeleteUserByIDConfirmed(existingId);

            database.Verify(m => m.DeleteUserByID(existingId), Times.Once);
        }
    }
}
