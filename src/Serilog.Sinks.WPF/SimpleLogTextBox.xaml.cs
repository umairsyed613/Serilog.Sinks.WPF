using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Serilog.Sinks.WPF
{
    /// <summary>
    /// Interaction logic for SimpleLogTextBox.xaml
    /// </summary>
    public partial class SimpleLogTextBox : UserControl
    {
        public ScrollBarVisibility ScrollBarVisibility { get; set; }

        public bool IsReadyOnly { get; set; } = false;


        public SimpleLogTextBox()
        {
            InitializeComponent();
        }

        private void SimpleLogTextBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (this.Dispatcher.Thread == Thread.CurrentThread)
            {
                LogTextBox.VerticalScrollBarVisibility = ScrollBarVisibility;
                LogTextBox.IsReadOnly = IsReadyOnly;
                LogTextBox.FontFamily = FontFamily;
                LogTextBox.FontSize = FontSize;
                LogTextBox.FontStyle = FontStyle;
                LogTextBox.FontWeight = FontWeight;
            }
            else
            {
                Dispatcher.BeginInvoke(
                    new Action(
                        delegate
                            {
                                LogTextBox.VerticalScrollBarVisibility = ScrollBarVisibility;
                                LogTextBox.IsReadOnly = IsReadyOnly;
                                LogTextBox.FontFamily = FontFamily;
                                LogTextBox.FontSize = FontSize;
                                LogTextBox.FontStyle = FontStyle;
                                LogTextBox.FontWeight = FontWeight;
                            }));
            }

            WindFormsSink.SimpleTextBoxSink.OnLogReceived += SimpleTextBoxSink_OnLogReceived;
        }

        private void SimpleTextBoxSink_OnLogReceived(string str)
        {
            if (LogTextBox.Dispatcher.Thread == Thread.CurrentThread)
            {
                LogTextBox.Text += str;
                LogTextBox.ScrollToEnd();
            }
            else
            {
                LogTextBox.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(
                        delegate
                            {
                                LogTextBox.Text += str;
                                LogTextBox.ScrollToEnd();
                            }));
            }
        }
    }
}
