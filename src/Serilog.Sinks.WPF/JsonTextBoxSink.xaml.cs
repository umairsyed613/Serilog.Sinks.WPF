using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Serilog.Sinks.WPF
{
    /// <summary>
    /// Interaction logic for JsonTextBoxSink.xaml
    /// </summary>
    public partial class JsonTextBoxSink : UserControl
    {
        public ScrollBarVisibility ScrollBarVisibility { get; set; }

        public bool IsReadyOnly { get; set; } = false;

        public JsonTextBoxSink()
        {
            InitializeComponent();
        }

        private void JsonTextBoxSink_OnLoaded(object sender, RoutedEventArgs e)
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

            WindFormsSink.JsonTextBoxSink.OnLogReceived += JsonTextBoxSink_OnLogReceived;
        }

        private void JsonTextBoxSink_OnLogReceived(string str)
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

        private void JsonTextBoxSink_OnUnloaded(object sender, RoutedEventArgs e)
        {
            WindFormsSink.JsonTextBoxSink.OnLogReceived -= JsonTextBoxSink_OnLogReceived;
        }
    }
}
