using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        #region ---===   Constant   ===---

        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITYS_FILE_NAME = "activitys.dat";

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Пользователь
        /// 
        /// </summary>
        private readonly User _user;

        /// <summary>
        /// 
        /// Упражнения
        /// 
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// 
        /// Активность
        /// 
        /// </summary>
        public List<Activity> Activities { get; }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание контроллера упражнений
        /// 
        /// </summary>
        /// 
        /// <param name="user">
        /// 
        /// Пользователь
        /// 
        /// </param>
        public ExerciseController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            }

            _user = user;

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// Добавление упражнений
        /// 
        /// </summary>
        /// 
        /// <param name="activity">
        /// 
        /// Активность
        /// 
        /// </param>
        /// 
        /// <param name="begin">
        /// 
        /// Время начала
        /// 
        /// </param>
        /// 
        /// <param name="end">
        /// 
        /// Время окончания
        /// 
        /// </param>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exersise = new Exercise(begin, end, activity, _user);
                Exercises.Add(exersise);
            }
            else
            {
                var exersise = new Exercise(begin, end, act, _user);
                Exercises.Add(exersise);
            }

            Save();
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// Полечение списка всех упражнений
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetAllExercises()
        {
            return base.Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }


        /// <summary>
        /// 
        /// Получение списка всех активностей
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return base.Load<List<Activity>>(ACTIVITYS_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// 
        /// Сохранение в файл
        /// 
        /// </summary>
        private void Save()
        {
            base.Save(EXERCISES_FILE_NAME, Exercises);
            base.Save(ACTIVITYS_FILE_NAME, Activities);
        }

        #endregion

    }
}
