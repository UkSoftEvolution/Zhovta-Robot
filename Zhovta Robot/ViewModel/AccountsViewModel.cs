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

        private LogsViewModel logs; //Логи
        #endregion

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для инициализации
        /// </summary>
        /// <param name="logs">Логи</param>
        public AccountsViewModel(LogsViewModel logs)
        {
            this.logs = logs;

            Accounts = new ObservableCollection<AccountModel>();

            Files files = new Files();
            if (files.Load(Properties.Settings.Default.PathFileAccounts, Accounts))
            {
                Accounts = (ObservableCollection<AccountModel>)files.DataLoad;
                logs.AddLog(LogsViewModel.Data.Load_File, "Аккаунты успешно загружены");
            }
            else
                logs.AddLog(LogsViewModel.Data.Error, "Ошибка загрузки аккаунтов");
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
            account.DataContext = new AccountNavigateViewModel(account, Accounts, logs);
            account.ShowDialog();
        });
        /// <summary>
        /// Редактирование аккаунта
        /// </summary>
        public RelayCommand Edit_Click => new RelayCommand(obj =>
        {
            AccountNavigate account = new AccountNavigate();
            account.DataContext = new AccountNavigateViewModel(account, Accounts, (obj as AccountModel), logs);
            account.ShowDialog();
        });
        /// <summary>
        /// Удаление аккаунта
        /// </summary>
        public RelayCommand Del_Click => new RelayCommand(obj =>
        {
            try
            {
                Accounts.Remove((obj as AccountModel));
                logs.AddLog(LogsViewModel.Data.Delete, $"Аккаунт: {(obj as AccountModel).Email}, успешно удалён");
            }
            catch
            { logs.AddLog(LogsViewModel.Data.Delete_Error, $"Ошибка удаления аккаунта: {(obj as AccountModel).Email}"); }
            
            Files files = new Files();
            if (files.Save(Properties.Settings.Default.PathFileAccounts, accounts))
                logs.AddLog(LogsViewModel.Data.Save_File, "Аккаунты сохранены");
            else
                logs.AddLog(LogsViewModel.Data.Error, "Ошибка сохранения аккаунтов");
        });
        #endregion
    }
}