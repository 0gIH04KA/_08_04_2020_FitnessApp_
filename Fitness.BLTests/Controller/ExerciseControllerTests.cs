using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var random = new Random();

            //  Arrange
            var userName = Guid.NewGuid().ToString();
            var actyvityName = Guid.NewGuid().ToString();


            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            var activity = new Activity(actyvityName,
                                random.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.Last().Name);

        }
    }
}