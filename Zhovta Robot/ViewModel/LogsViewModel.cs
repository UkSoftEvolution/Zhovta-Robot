using Engine;
using FileManagement;
using System;
using System.Collections.ObjectModel;
using Zhovta_Robot.Model;

namespace Zhovta_Robot.ViewModel
{
    /// <summary>
    /// ViewModel: Для Binding с LogsView
    /// </summary>
    public class LogsViewModel : MVVM
    {
        /// <summary>
        /// Данные для определения типа логов
        /// </summary>
        public enum Data
        {
            /// <summary>
            /// Задача выполнена без ошибок
            /// </summary>
            OK,
            /// <summary>
            /// Ошибка
            /// </summary>
            Error,
            /// <summary>
            /// Сохранение файла
            /// </summary>
            Save_File,
            /// <summary>
            /// Загрузка из файла
            /// </summary>
            Load_File,
            /// <summary>
            /// Удаление
            /// </summary>
            Delete,
            /// <summary>
            /// Ошибка удаления
            /// </summary>
            Delete_Error,
            /// <summary>
            /// Добавлен аккаунт
            /// </summary>
            Account_Add,
            /// <summary>
            /// Отредактирован аккаунт
            /// </summary>
            Account_Edit
        };


        #region Fields
        private ObservableCollection<LogsModel> logs; //Коллекция логов
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор для инициализации данных
        /// </summary>
        public LogsViewModel()
        {
            logs = new ObservableCollection<LogsModel>();
            Files files = new Files();
            if (files.Load(Properties.Settings.Default.PathFileLogs, Logs))
                Logs = (ObservableCollection<LogsModel>)files.DataLoad;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Функция для добавления логов
        /// </summary>
        public void AddLog(Data data, string description)
        {
            var log = new LogsModel()
            {
                Description = description,
                Date = DateTime.Now.ToString()
            };

            switch (data)
            {
                case Data.OK:
                    {
                        log.Data = "M17,3A2,2 0 0,1 19,5V21L12,18L5,21V5C5,3.89 5.9,3 7,3H17M11,14L17.25,7.76L15.84,6.34L11,11.18L8.41,8.59L7,10L11,14Z";
                        break;
                    }
                case Data.Error:
                    {
                        log.Data = "M13,13H11V7H13M13,17H11V15H13M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2Z";
                        break;
                    }
                case Data.Save_File:
                    {
                        log.Data = "M14,2H6A2,2 0 0,0 4,4V20A2,2 0 0,0 6,22H18A2,2 0 0,0 20,20V8L14,2M13.5,16V19H10.5V16H8L12,12L16,16H13.5M13,9V3.5L18.5,9H13Z";
                        break;
                    }
                case Data.Load_File:
                    {
                        log.Data = "M14,2H6C4.89,2 4,2.89 4,4V20C4,21.11 4.89,22 6,22H18C19.11,22 20,21.11 20,20V8L14,2M12,19L8,15H10.5V12H13.5V15H16L12,19M13,9V3.5L18.5,9H13Z";
                        break;
                    }
                case Data.Delete:
                    {
                        log.Data = "M19,4H15.5L14.5,3H9.5L8.5,4H5V6H19M6,19A2,2 0 0,0 8,21H16A2,2 0 0,0 18,19V7H6V19Z";
                        break;
                    }
                case Data.Delete_Error:
                    {
                        log.Data = "";
                        break;
                    }
                case Data.Account_Add:
                    {
                        log.Data = "M2,16H10V14H2M18,14V10H16V14H12V16H16V20H18V16H22V14M14,6H2V8H14M14,10H2V12H14V10Z";
                        break;
                    }
                case Data.Account_Edit:
                    {
                        log.Data = "M2,6V8H14V6H2M2,10V12H14V10H2M20.04,10.13C19.9,10.13 19.76,10.19 19.65,10.3L18.65,11.3L20.7,13.35L21.7,12.35C21.92,12.14 21.92,11.79 21.7,11.58L20.42,10.3C20.31,10.19 20.18,10.13 20.04,10.13M18.07,11.88L12,17.94V20H14.06L20.12,13.93L18.07,11.88M2,14V16H10V14H2Z";
                        break;
                    }
            }

            Logs.Insert(0, log);

            Files files = new Files();
            files.Save(Properties.Settings.Default.PathFileLogs, Logs);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Коллекция логов
        /// </summary>
        public ObservableCollection<LogsModel> Logs
        {
            get => logs;
            set
            {
                logs = value;
                OnPropertyChanged(nameof(logs));
            }
        }
        #endregion
    }
}