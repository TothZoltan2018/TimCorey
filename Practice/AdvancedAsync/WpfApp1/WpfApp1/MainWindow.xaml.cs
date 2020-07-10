﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();
            
            PrintToResultWindow(SyncAsyncParall.MethodSync());
            
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeSync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private void executeSyncParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            PrintToResultWindow(SyncAsyncParall.MethodParallelSync());

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeSyncParallel_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            //It calls the same Synchronous method, but asynchronously by 'Task.Run'
            //List<string> result = await Task.Run(()=> SyncAsyncParall.MethodSync());
            //Alternatively, we can call our asynchronous method like this:
            List<string> result = await SyncAsyncParall.MethodAsync();
            PrintToResultWindow(result);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeAsync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private async void executeAsyncParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            List<string> result = await SyncAsyncParall.MethodParallelAsync();
            PrintToResultWindow(result);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeAsync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private void executeParallelAsync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void executeParallelAsyncV2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelOperation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintToResultWindow(List<string> result)
        {
            foreach (var item in result)
            {
                resultsWindow.Text += item; 
            }
        }

    }
}
