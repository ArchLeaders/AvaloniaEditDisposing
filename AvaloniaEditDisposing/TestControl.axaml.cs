using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace AvaloniaEditDisposing;

public partial class TestControl : UserControl
{
    private readonly TextMate.Installation _installation;

    public TestControl()
    {
        InitializeComponent();
        
        _installation = Editor.InstallTextMate(new RegistryOptions(ThemeName.DarkPlus));

        // TODO: Comment this out
        _installation.SetGrammar("source.yaml");
    }

    public void Cleanup()
    {
        _installation.Dispose();
    }

    ~TestControl()
    {
        Console.WriteLine("Collect View");
    }
}