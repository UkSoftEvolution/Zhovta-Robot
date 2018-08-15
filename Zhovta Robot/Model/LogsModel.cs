using Engine;
using System;

namespace Zhovta_Robot.Model
{
    /// <summary>
    /// Model: Для логов
    /// </summary>
    public class LogsModel : MVVM
    {
        #region Fields
        private string data; //Значок
        private string description; //Описание
        private string date; //Дата и время
        #endregion

        #region Methods
        /// <summary>
        /// Значок
        /// </summary>
        public string Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged(nameof(data));
            } 
        }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(description));
            }
        }
        /// <summary>
        /// Дата и время
        /// </summary>
        public string Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(date));
            }
        }
        #endregion
    }
}