using Serilog.Formatting;

namespace Serilog.Sinks.WPF
{
    public static class WindFromsSinkExtensions
    {
        /// <summary>
        /// Write the simple formatted text logs directly to textbox. simple and rich textbox control can be used from toolbox
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToSimpleAndRichTextBox(this LoggerConfiguration configuration, ITextFormatter formatter = null)
        {
            return configuration.WriteTo.Sink(WindFormsSink.MakeSimpleTextBoxSink(formatter));
        }

        /// <summary>
        /// Write the compact json formatted text logs directly to textbox. json textbox control can be used from toolbox
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToJsonTextBox(this LoggerConfiguration configuration, ITextFormatter formatter = null)
        {
            return configuration.WriteTo.Sink(WindFormsSink.MakeJsonTextBoxSink(formatter));
        }
    }
}
