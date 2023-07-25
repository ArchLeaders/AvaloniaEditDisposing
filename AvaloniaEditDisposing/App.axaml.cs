using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Reflection.Metadata;

namespace AvaloniaEditDisposing
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new Window() {
                    Content = new TestControl(),
                    Height = 400,
                    Width = 400,
                };

                ((TestControl)desktop.MainWindow.Content).Cleanup();

                await Task.Delay(1000);

                desktop.MainWindow.Content = null;

                await Task.Delay(1000);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}