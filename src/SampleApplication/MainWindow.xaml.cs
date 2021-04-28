using System.Windows;

using Serilog;
using Serilog.Sinks.WPF;

namespace SampleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                        .WriteToSimpleAndRichTextBox()
                        .CreateLogger();

            Log.Information("Logger has been created");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(inputTxt.Text);
            inputTxt.Text = string.Empty;
        }
    }
}
