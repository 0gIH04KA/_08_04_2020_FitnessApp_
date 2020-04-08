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
    public class UserController
    {
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
        public User CurentUser { get; }

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

            CurentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurentUser == null)
            {
                CurentUser = new User(userName);
                Users.Add(CurentUser);
                IsNewUser = true;

                Save();
            }
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
            var fomatter = new BinaryFormatter();

            using (var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (fomatter.Deserialize(fileStream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// 
        /// Сохранить пользователя приложения в файл
        /// 
        /// </summary>
        private void Save()
        {
            var fomatter = new BinaryFormatter();

            using (var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fileStream, Users);
            }
        }

        #endregion

        #region ---===   Public Method   ===---



        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurentUser.Gender = new Gender(genderName);
            CurentUser.BirthDate = birthDate;
            CurentUser.Weight = weight;
            CurentUser.Height = height;

            Save();
        }

        #endregion



    }
}
