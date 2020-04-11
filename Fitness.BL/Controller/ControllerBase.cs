using Fitness.BL.Controller.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        #region ---===   Private   ===---

        private IDataSaver _saver = new SerialazeDataSaver();

        #endregion

        #region ---===   protected Method   ===---

        /// <summary>
        /// 
        /// Сохранение в файл
        /// 
        /// </summary>
        /// 
        /// <param name="fileName">
        /// 
        /// Имя файла 
        /// 
        /// </param>
        /// 
        /// <param name="item">
        /// 
        /// Объект который сохраняем
        /// 
        /// </param>
        protected void Save(string fileName, object item)
        {
            _saver.Save(fileName, item);
        }

        /// <summary>
        /// 
        /// Загрузка файла
        /// 
        /// </summary>
        /// 
        /// <typeparam name="T">        </typeparam>
        /// 
        /// <param name="fileName">
        /// 
        /// Имя файла
        /// 
        /// </param>
        /// <returns></returns>
        protected T Load<T>(string fileName)
        {
            return _saver.Load<T>(fileName);
        }

        #endregion


    }
}
