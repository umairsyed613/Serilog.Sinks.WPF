# Serilog.Sinks.WPF

[![NuGet version](https://badge.fury.io/nu/Serilog.Sinks.WPF.png)](https://badge.fury.io/nu/Serilog.Sinks.WPF) ![Build Status](https://travis-ci.org/umairsyed613/Serilog.Sinks.WPF.svg?branch=master) [![Nuget](https://img.shields.io/nuget/dt/Serilog.Sinks.WPF)](https://www.nuget.org/packages/Serilog.Sinks.WPF)

Writes [Serilog](https://serilog.net) events to WPF TextBox control from anywhere in your application.

### Getting started

Install the [Serilog.Sinks.WPF](https://www.nuget.org/packages/Serilog.Sinks.WPF/) package from NuGet:

```powershell
Install-Package Serilog.Sinks.WPF
```

To configure the sink in C# code, call `WriteToSimpleTextBox()` or `WriteToJsonTextBox()` during logger configuration:

##### Simple Text Formatted Log

SimpleLogTextBox can be used from visual studio toolbox once the package is added to the project.

```csharp
Log.Logger = new LoggerConfiguration()
                        .WriteToSimpleTextBox()
                        .CreateLogger();
```

##### Json Formatted Log

JsonLogTextBox can be used from visual studio toolbox once the package is added to the project.

```csharp
Log.Logger = new LoggerConfiguration()
                        .WriteToJsonTextBox()
                        .CreateLogger();
```

### Sample Code

Find the sample running application [here](https://github.com/umairsyed613/Serilog.Sinks.WPF/SampleApplication/)
