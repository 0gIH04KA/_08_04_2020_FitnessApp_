using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Resources;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Прием пищи
    /// 
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region ---===   Languages   ===---

        /// <summary>
        /// 
        /// Получение культуры пользователя 
        /// 
        /// </summary>
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        /// <summary>
        /// 
        /// Создание Менеджера ресурсов для отображениея локализированных сообщений
        /// 
        /// </summary>
        private readonly ResourceManager resourceMenager = new ResourceManager("Fitness.BL.Languages.Messages", typeof(Eating).Assembly);

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Время приема пищи
        /// 
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// Съеденная пища + вес порции
        /// 
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        /// <summary>
        /// 
        /// Пользователь который принимает пищу
        /// 
        /// </summary>
        public User User { get; set; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание приема пищи
        /// 
        /// </summary>
        /// 
        /// <param name="user">
        /// 
        /// Пользователь
        /// 
        /// </param>
        public Eating(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(resourceMenager.GetString("UserIsEmpty", culture), nameof(user));
            }

            User = user;
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// Добавление еды в словарь 
        /// 
        /// </summary>
        /// 
        /// <param name="food">
        /// 
        /// Добавляемая еда
        /// 
        /// </param>
        /// 
        /// <param name="weight">
        /// 
        /// Вес порции
        /// 
        /// </param>
        public void Add(Food food, double weight)
        {
            Food product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }

        #endregion

    }
}
