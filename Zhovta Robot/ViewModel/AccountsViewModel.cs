using Engine;
using FileManagement;
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
        #endregion

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для инициализации
        /// </summary>
        public AccountsViewModel()
        {
            Accounts = new ObservableCollection<AccountModel>();

            Files files = new Files();
            if (files.Load("Accounts.rbt", Accounts))
                Accounts = (ObservableCollection<AccountModel>)files.DataLoad;
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
            AccountNavigate account = new AccountNavigate();
            account.DataContext = new AccountNavigateViewModel(account, Accounts);
            account.ShowDialog();
        });
        /// <summary>
        /// Редактирование аккаунта
        /// </summary>
        public RelayCommand Edit_Click => new RelayCommand(obj =>
        {
            AccountNavigate account = new AccountNavigate();
            account.DataContext = new AccountNavigateViewModel(account, Accounts, (obj as AccountModel));
            account.ShowDialog();
        });
        /// <summary>
        /// Удаление аккаунта
        /// </summary>
        public RelayCommand Del_Click => new RelayCommand(obj =>
        {
            Accounts.Remove((obj as AccountModel));
            Files files = new Files();
            files.Save("Accounts.rbt", accounts);
        });
        #endregion
    }
}