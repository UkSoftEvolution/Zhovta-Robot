using Engine;
using System.Windows.Controls;

namespace Zhovta_Robot.Model
{
    /// <summary>
    /// Model: Для работы с страницами главного меню
    /// </summary>
    public class PageModel : MVVM
    {
        #region Fields
        private Page pageUri; //Ссылка на страницу
        private string pageName; //Название страници
        private bool enabled; //Активность страници
        #endregion

        #region Methods
        /// <summary>
        /// Ссылка на страницу
        /// </summary>
        public Page PageUri
        {
            get => pageUri;
            set
            {
                pageUri = value;
                OnPropertyChanged(nameof(pageUri));
            }
        }
        /// <summary>
        /// Название страници
        /// </summary>
        public string PageName
        {
            get => pageName;
            set
            {
                pageName = value;
                OnPropertyChanged(nameof(pageName));
            }
        }
        /// <summary>
        /// Активность страници
        /// </summary>
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                OnPropertyChanged(nameof(enabled));
            }
        }
        #endregion
    }
}