using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// 
    /// Контроллер пользователя
    /// 
    /// </summary>
    public class UserController : ControllerBase
    {
        #region ---===   Constant   ===---

        private const string USER_FILE_NAME = "user.dat";

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Пользователь приложения
        /// 
        /// </summary>
        private List<User> Users { get; }

        /// <summary>
        /// 
        /// 
        /// 
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание контроллера пользователя
        /// 
        /// </summary>
        /// 
        /// <param name="user">
        /// 
        /// Пользователь приложения
        /// 
        /// </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsertsData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;

                Save();
            }
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// Создание нового пользователя
        /// 
        /// </summary>
        /// 
        /// <param name="genderName">
        /// 
        /// Пол
        /// 
        /// </param>
        /// 
        /// <param name="birthDate">
        /// 
        /// Дата рождения
        /// 
        /// </param>
        /// 
        /// <param name="weight">
        /// 
        /// Вес 
        /// 
        /// </param>
        /// 
        /// <param name="height">
        /// 
        /// Рост
        /// 
        /// </param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// Получить сохраненный список пользователей 
        /// 
        /// </summary>
        private List<User> GetUsertsData()
        {
            return base.Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// 
        /// Сохранение в файл
        /// 
        /// </summary>
        private void Save()
        {
            base.Save(USER_FILE_NAME, Users);
        }

        #endregion

    }
}
