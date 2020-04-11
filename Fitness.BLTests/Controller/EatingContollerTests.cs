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
    public class EatingContollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var random = new Random();

            //  Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();


            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);

            var food = new Food(foodName,
                                random.Next(50, 500),
                                random.Next(50, 500),
                                random.Next(50, 500),
                                random.Next(50, 500));
            
            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.Last().Key.Name);

        }
    }
}