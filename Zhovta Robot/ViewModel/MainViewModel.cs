using Engine;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Zhovta_Robot.Model;
using Zhovta_Robot.View;

namespace Zhovta_Robot.ViewModel
{
    /// <summary>
    /// ViewModel: Класс для Binding с MainView
    /// </summary>
    public class MainViewModel : MVVM
    {
        #region Fields
        private ObservableCollection<PageModel> pages; //Коллекция страниц для главного меню
        private Page pageActive; //Активная страница
        private PageModel model; //Активная модель
        private string title; //Подпись окна программы

        //ViewModel
        private AccountsViewModel accountsViewModel; //Аккаунты
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор для инициализации данных
        /// </summary>
        public MainViewModel()
        {
            Title = "Zhovta Robot";

            accountsViewModel = new AccountsViewModel();

            Pages = new ObservableCollection<PageModel>
            {
                new PageModel() { PageUri = new AccountsView() { DataContext = accountsViewModel }, PageName = "Аккаунты", Enabled = true },
                new PageModel() { PageUri = new ActionsView(), PageName = "Действия робота", Enabled = true },
                new PageModel() { PageUri = new LogsView(), PageName = "Логи", Enabled = true },
                new PageModel() { PageUri = null, PageName = "Отчёты", Enabled = true },
                new PageModel() { PageUri = null, PageName = "Настройки", Enabled = true }
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Коллекция страниц для главного меню
        /// </summary>
        public ObservableCollection<PageModel> Pages
        {
            get => pages;
            set
            {
                pages = value;
                OnPropertyChanged(nameof(pages));
            }
        }

        /// <summary>
        /// Активная страница
        /// </summary>
        public Page PageActive
        {
            get => pageActive;
            set
            {
                pageActive = value;
                OnPropertyChanged(nameof(pageActive));
            }
        }

        /// <summary>
        /// Подпись окна программы
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
        #endregion

        #region Commands
        /// <summary>
        /// Команда переключения страниц
        /// </summary>
        public RelayCommand Menu_Click => new RelayCommand(obj =>
        {
            if (model != null)
                model.Enabled = true;

            Title = $"Zhovta Robot - {(obj as PageModel).PageName}";
            PageActive = (obj as PageModel).PageUri;
            (obj as PageModel).Enabled = false;
            model = (obj as PageModel);
        });
        #endregion
    }
}