using System;
using System.IO;
using System.Xml.Serialization;

namespace FileManagement
{
    /// <summary>
    /// Класс для работы с файлами
    /// </summary>
    public class Files
    {
        private object dataLoad; //Данные загруженные из файла

        /// <summary>
        /// Данные загруженные из файла
        /// </summary>
        public object DataLoad { get => dataLoad; set => dataLoad = value; }

        #region Functions
        /// <summary>
        /// Сохранить в файл
        /// </summary>
        /// <param name="nameFile">Имя файла</param>
        /// <param name="data">Данные которые нужно сохранить</param>
        /// <returns>Результат процесса сохранения в файл</returns>
        public bool Save(string nameFile, object data)
        {
            try
            {
                using (var writer = new StreamWriter(nameFile))
                {
                    var xs = new XmlSerializer(data.GetType());
                    xs.Serialize(writer, data);
                }

                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Загрузить из файла
        /// </summary>
        /// <param name="nameFile">Имя файла</param>
        /// <param name="data">Данные которые нужно сохранить</param>
        /// <returns>Результат процесса загрузки из файла</returns>
        public bool Load(string nameFile, object data)
        {
            try
            {
                DataLoad = data;

                if (File.Exists(nameFile))
                {
                    using (var reader = new StreamReader(nameFile))
                    {
                        var xs = new XmlSerializer(data.GetType());
                        DataLoad = xs.Deserialize(reader);
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            { return false; }
            
        }
        #endregion
    }
}