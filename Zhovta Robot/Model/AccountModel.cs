using Engine;

namespace Zhovta_Robot.Model
{
    /// <summary>
    /// Model: Для работы с аккаунтами
    /// </summary>
    public class AccountModel : MVVM
    {
        #region Fields
        private string email; //E-mail
        private string password; //Пароль
        private string data; //Данные для запроса
        #endregion

        #region Methods
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }
        /// <summary>
        /// Данные для запроса
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
        #endregion
    }
}