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
    public class EatingController : ControllerBase
    {
        #region ---===   Constant   ===---

        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";

        #endregion

        #region ---===   Private   ===---

        private readonly User _user;

        #endregion

        #region ---===   Public   ===---

        /// <summary>
        /// 
        /// Список продуктов
        /// 
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// 
        /// Прием пищи
        /// 
        /// </summary>
        public Eating Eating { get; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание контроллера приема пищи
        /// 
        /// </summary>
        /// 
        /// <param name="user">
        /// 
        /// Пользователь
        /// 
        /// </param>
        public EatingController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            }

            _user = user;

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// Добавление продукта
        /// 
        /// </summary>
        /// 
        /// <param name="food">
        /// 
        /// Продукт
        /// 
        /// </param>
        /// 
        /// <param name="weight">
        /// 
        /// Вес продукта
        /// 
        /// </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// Получение приемов пищи
        /// 
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            return base.Load<Eating>(EATING_FILE_NAME) ?? new Eating(_user);
        }

        /// <summary>
        /// 
        /// Получение всех продуктов
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return base.Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }   

        /// <summary>
        /// 
        /// Сохранение в файл
        /// 
        /// </summary>
        private void Save()
        {
            base.Save(FOODS_FILE_NAME, Foods);
            base.Save(EATING_FILE_NAME, Eating);
        }

        #endregion
    }
}
