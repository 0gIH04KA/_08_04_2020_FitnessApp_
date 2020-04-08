using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Класс который описывает Пользователя.
    /// 
    /// </summary>
    class User
    {
        #region ---===   Property   ===---
        
        /// <summary>
        /// 
        /// Имя пользователя.
        /// 
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// 
        /// Пол пользователя.
        /// 
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// 
        /// Дата рождения пользователя.
        /// 
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// 
        /// Вес пользователя.
        /// 
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// 
        /// Рост пользователя.
        /// 
        /// </summary>
        public double Height { get; set; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создать нового пользователя
        /// 
        /// </summary>
        /// 
        /// <param name="name"> 
        /// 
        /// Имя
        /// 
        /// </param>
        /// 
        /// <param name="gender">
        /// 
        /// Пол.
        /// 
        /// </param>
        /// 
        /// <param name="birthDate">
        /// 
        /// Дата рождения.
        /// 
        /// </param>
        /// 
        /// <param name="weight">
        /// 
        /// Вес.
        /// 
        /// </param>
        /// 
        /// <param name="height">
        /// 
        /// Рост.
        /// 
        /// </param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            Validation(name, gender, birthDate, weight, height);

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        #endregion

        #region ---===   Private Method   ===---

        private void Validation(string name,
                                Gender gender,
                                DateTime birthDate,
                                double weight,
                                double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть пустым.", nameof(gender));
            }

            if ((birthDate < DateTime.Parse("01.01.1900")) || (birthDate >= DateTime.Now))
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть равень меньше нуля", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше нуля.", nameof(height));
            }
        }

        #endregion

        #region ---===   Override Method   ===---

        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
