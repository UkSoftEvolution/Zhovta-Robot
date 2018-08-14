using Engine;
using FileManagement;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Zhovta_Robot.Model;

namespace Zhovta_Robot.ViewModel
{
    /// <summary>
    /// ViewModel: Для Binding с AccountNavigate
    /// </summary>
    public class AccountNavigateViewModel : MVVM
    {
        #region Fields
        private string title; //Подпись окна
        private double opacity; //Прозрачность текста ошибки
        private string textError; //Текст ошибки
        private Window window; //Данное окно
        private AccountModel account; //Экземпляр аккаунта
        private ObservableCollection<AccountModel> accounts; //Коллекция аккаунтов
        private AccountModel accountEdit; //Аккаунт для редактирования
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор для инициализации данных
        /// </summary>
        /// <param name="window">Экземпляр окна</param>
        /// <param name="accounts">Коллекция аккаунтов</param>
        public AccountNavigateViewModel(Window window, ObservableCollection<AccountModel> accounts)
        {
            this.window = window;
            this.accounts = accounts;

            Title = "Добавить новый аккаунт";
            Opacity = 0.0;
            Account = new AccountModel()
            {
                Email = "",
                Password = "",
                Data = ""
            };
        }

        /// <summary>
        /// Конструктор для инициализации данных
        /// </summary>
        /// <param name="window">Экземпляр окна</param>
        /// <param name="accounts">Коллекция аккаунтов</param>
        /// <param name="accountEdit">Экземпляр аккаунта для редактирования</param>
        public AccountNavigateViewModel(Window window, ObservableCollection<AccountModel> accounts, AccountModel accountEdit)
        {
            this.window = window;
            this.accounts = accounts;
            this.accountEdit = accountEdit;

            Title = "Редактировать аккаунт";
            Opacity = 0.0;

            Account = new AccountModel()
            {
                Email = accountEdit.Email,
                Password = accountEdit.Password,
                Data = accountEdit.Data
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Подпись окна
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }

        /// <summary>
        /// Прозрачность текста ошибки
        /// </summary>
        public double Opacity
        {
            get => opacity;
            set
            {
                opacity = value;
                OnPropertyChanged(nameof(opacity));
            }
        }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string TextError
        {
            get => textError;
            set
            {
                textError = value;
                OnPropertyChanged(nameof(textError));
            }
        }

        /// <summary>
        /// Экземпляр аккаунта
        /// </summary>
        public AccountModel Account
        {
            get => account;
            set
            {
                account = value;
                OnPropertyChanged(nameof(account));
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Закрыть окно
        /// </summary>
        public RelayCommand Close_Click => new RelayCommand(obj =>
        {
            window.Close();
        });

        /// <summary>
        /// Добавить/редактировать аккаунт
        /// </summary>
        public RelayCommand Add_Click => new RelayCommand(obj =>
        {
            Opacity = 0.0;

            if (Account.Email.Length == 0 || Account.Password.Length == 0)
            {
                TextError = "Пустое поле";
                Opacity = 1.0;
            }
            else
            {
                if (Account.Email.ToCharArray().Where(i => i == '@').Count() != 1)
                {
                    TextError = "Не правильно записан E-mail";
                    Opacity = 1.0;
                }
                else
                {
                    if (Account.Password.Length < 5)
                    {
                        TextError = "Короткий пароль";
                        Opacity = 1.0;
                    }
                    else
                    {
                        foreach (var acc in accounts)
                        {
                            if (acc.Email == account.Email)
                            {
                                if (accountEdit == null)
                                {
                                    TextError = "Аккаунт уже существует";
                                    Opacity = 1.0;
                                    return;
                                }
                                else
                                {
                                    if (account.Email != accountEdit.Email)
                                    {
                                        TextError = "Аккаунт уже существует";
                                        Opacity = 1.0;
                                        return;
                                    }
                                    else
                                        continue;
                                }
                            }
                            else
                                continue;
                        }

                        if (accountEdit == null)
                            accounts.Insert(0, account);
                        else
                            accounts[accounts.IndexOf(accountEdit)] = account;

                        Files files = new Files();
                        files.Save("Accounts.rbt", accounts);

                        window.Close();
                    }
                }
            }
        });
        #endregion
    }
}