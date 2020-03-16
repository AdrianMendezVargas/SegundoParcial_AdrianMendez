﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SegundoParcial_AdrianMendez {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_DispatcherUnhandledException(object sender , System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show("Ah ocurrido un error inesperado: \n\n" + e.Exception.Message);
            e.Handled = true;
        }
    }
}
