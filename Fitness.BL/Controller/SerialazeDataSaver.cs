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
    /// <summary>
    /// 
    /// Класс который реализует загрузку и сохранение Serialaze файлов
    /// 
    /// </summary>
    class SerialazeDataSaver : IDataSaver
    {
        /// <summary>
        /// 
        /// Загрузка Serializable данных с файла
        /// 
        /// </summary>
        /// 
        /// <typeparam name="T"></typeparam>
        /// 
        /// <param name="fileName">
        /// 
        /// Имя файла
        /// 
        /// </param>
        /// <returns></returns>
        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if ((fileStream.Length > 0)
                 && (formatter.Deserialize(fileStream) is T items))
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// 
        /// Сохранение Serializable данных в файл
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
        public void Save(string fileName, object item)
        {
            var fomatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fileStream, item);
            }
        }

    }
}
