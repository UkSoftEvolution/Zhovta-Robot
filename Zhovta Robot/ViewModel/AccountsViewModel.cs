using Engine;
using System.Collections.ObjectModel;
using Zhovta_Robot.Model;

namespace Zhovta_Robot.ViewModel
{
    /// <summary>
    /// ViewVodel: Класс для Binding с AccountsView
    /// </summary>
    public class AccountsViewModel : MVVM
    {
        #region Fields
        private ObservableCollection<AccountModel> accounts; //Коллекция аккаунтов
        private double opacity;
        #endregion

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для инициализации
        /// </summary>
        public AccountsViewModel()
        {
            Accounts = new ObservableCollection<AccountModel>()
            {
                new AccountModel() { Email = "GreshnikAlexM@gmail.com" },
                new AccountModel() { Email = "uk.soft.evolution@gmail.com" }
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Коллекция аккаунтов
        /// </summary>
        public ObservableCollection<AccountModel> Accounts
        {
            get => accounts;
            set
            {
                accounts = value;
                OnPropertyChanged(nameof(accounts));
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Добавление аккаунта
        /// </summary>
        public RelayCommand Add_Click => new RelayCommand(obj =>
        {
            new AccountNavigate().ShowDialog();
        });
        /// <summary>
        /// Редактирование аккаунта
        /// </summary>
        public RelayCommand Edit_Click => new RelayCommand(obj =>
        {
            
        });
        /// <summary>
        /// Удаление аккаунта
        /// </summary>
        public RelayCommand Del_Click => new RelayCommand(obj =>
        {
            Accounts.Remove((obj as AccountModel));
        });
        #endregion
    }
}