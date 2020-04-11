using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// 
    /// Упражнения 
    /// 
    /// </summary>
    [Serializable]
    public class Exercise
    {
        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Время начала упражнения
        /// 
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// 
        /// Время окончания упражнения
        /// 
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// 
        /// Активность
        /// 
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// 
        /// Пользователь который выполняет упражнение
        /// 
        /// </summary>
        public virtual User User { get; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание упражнения
        /// 
        /// </summary>
        /// 
        /// <param name="start">  
        /// 
        /// Время начала 
        /// 
        /// </param>
        /// 
        /// <param name="finish">
        /// 
        /// Время окончания
        /// 
        /// </param>
        /// 
        /// <param name="activity">
        /// 
        /// Активность  
        /// 
        /// </param>
        /// 
        /// <param name="user">  
        /// 
        /// Пользователь который выполняет упражнение
        /// 
        /// </param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

        #endregion

    }
}
