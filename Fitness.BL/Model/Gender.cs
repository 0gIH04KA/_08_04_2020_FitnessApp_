using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Класс который описывает Пол.
    /// 
    /// </summary>
    class Gender
    {
        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Название
        /// 
        /// </summary>
        public string Name { get; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создать новый пол.
        /// 
        /// </summary>
        /// 
        /// <param name="name">
        /// 
        /// Имя пола.
        /// 
        /// </param>
        public Gender(string name)
        {
            Validation(name);

            Name = name;
        }

        #endregion

        #region ---===   Private Method   ===---

        private void Validation(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым!", nameof(name));  //TODO: создать свое исключение
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
