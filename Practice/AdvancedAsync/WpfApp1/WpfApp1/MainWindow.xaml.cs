using System;
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
        CancellationTokenSource cts = new CancellationTokenSource();
        Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
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
            //progress.ProgressChanged += Progress_ProgressChanged;
            var watch = Stopwatch.StartNew();

            PrintToResultWindow(SyncAsyncParall.MethodParallelSync());

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeSyncParallel_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            progress.ProgressChanged += Progress_ProgressChanged;
            var watch = Stopwatch.StartNew();

            try
            {
                List<string> result = await SyncAsyncParall.MethodAsync(progress, cts.Token);
                //PrintToResultWindow(result);
            }
            catch (OperationCanceledException)
            {
                resultsWindow.Text += $"The 'MethodAsync' execution was cancelled. { Environment.NewLine }";                
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeAsync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            dashboardProgress.Value = e.PercentageComplete;
            PrintToResultWindow(e.ReadyProcessNames);
        }

        private async void executeAsyncParallel_Click(object sender, RoutedEventArgs e)
        {
            progress.ProgressChanged += Progress_ProgressChanged;
            var watch = Stopwatch.StartNew();

            List<string> result = await SyncAsyncParall.MethodParallelAsync();
            PrintToResultWindow(result);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeAsync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private async void executeParallelAsyncV2_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();

            progress.ProgressChanged += Progress_ProgressChanged;
            var watch = Stopwatch.StartNew();
            progress.ProgressChanged += Progress_ProgressChanged;

            try
            {
                List<string> result = await SyncAsyncParall.MethodParallelAsyncV2(progress, cts.Token);
                //PrintToResultWindow(result);
            }
            // Because of the parallel executon in 'MethodParallelAsyncV2', multiple exceptions will be thrown
            // AggregateException can catch them.
            catch (AggregateException ex)
            {
                ex.Handle(innerEx =>
                {
                    resultsWindow.Text += $"The 'MethodParallelAsyncV2' execution was cancelled. \"{innerEx.Message}\" was thrown { Environment.NewLine }";
                    return true;
                });                              
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += nameof(executeAsync_Click) + " " + elapsedMs.ToString() + "\n";
        }

        private void cancelOperation_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();            
        }

        private void PrintToResultWindow(List<string> result)
        {
            resultsWindow.Text = "";
            foreach (var item in result)
            {
                resultsWindow.Text += item; 
            }
        }

    }
}
