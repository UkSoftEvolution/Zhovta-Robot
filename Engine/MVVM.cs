﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Engine
{
    /// <summary>
    /// Класс для работы с патерном MVVM
    /// </summary>
    public class MVVM : INotifyPropertyChanged
    {
        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}