using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Класс который описывает активность
    /// 
    /// </summary>
    [Serializable]
    public class Activity
    {
        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Название
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// Каллории за минуту
        /// 
        /// </summary>
        public double CaloriesPerMinute { get; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание новой активности 
        /// 
        /// </summary>
        /// 
        /// <param name="name"> 
        /// 
        /// Название
        /// 
        /// </param>
        /// 
        /// <param name="caloriesPerMinute">
        /// 
        /// Каллории за минуту
        /// 
        /// </param>
        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
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
