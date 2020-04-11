using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Класс который описывает продукты
    /// 
    /// </summary>
    [Serializable]
    public class Food
    {
        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Название продукта
        /// 
        /// </summary>
        public string Name { get; set; }

        public double Callories { get; set; }

        /// <summary>
        /// 
        /// Белки
        /// 
        /// </summary>
        public double Proteins { get; set; }

        public double Carbhydates { get; set; }

        /// <summary>
        /// 
        /// Жиры
        /// 
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// 
        /// Углеводы
        /// 
        /// </summary>
        public double Carbohydates { get; set; }

        /// <summary>
        /// 
        /// Калории
        /// 
        /// </summary>
        public double Calories { get; set; }


        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание продукта
        /// 
        /// </summary>
        /// 
        /// <param name="name">
        /// 
        /// Название продукта
        /// 
        /// </param>
        /// 
        /// <param name="callories"> 
        /// 
        /// Количество каллорий 
        /// 
        /// </param>
        /// 
        /// <param name="proteins"> 
        /// 
        /// Количество белка<
        /// 
        /// /param>
        /// 
        /// <param name="fats">         
        /// 
        /// Количество жиров
        /// 
        /// </param>
        /// 
        /// <param name="carbohydates"> 
        /// 
        /// Количество углеводов
        /// 
        /// </param>
        public Food(string name, double callories, double proteins, double fats, double carbohydates)
        {
            // TODO: проверка

            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydates = carbohydates / 100.0;
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
