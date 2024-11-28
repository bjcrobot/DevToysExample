using DevToys.Api;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Composition;
using static DevToys.Api.GUI;

namespace HelloWorld;

[Export(typeof(IGuiTool))]
[Name("DevToys Example")]
[ToolDisplayInformation(
    IconFontName = "FluentSystemIcons",
    IconGlyph = '\uE670',
    ResourceManagerAssemblyIdentifier = nameof(MyResourceAssemblyIdentifier),
    ResourceManagerBaseName = "HelloWorld.Properties.Resources",
    ShortDisplayTitleResourceName = nameof(Properties.Resources.ShortDisplayTitle),
    LongDisplayTitleResourceName = nameof(Properties.Resources.LongDisplayTitle),
    DescriptionResourceName = nameof(Properties.Resources.Description),
    AccessibleNameResourceName = nameof(Properties.Resources.AccessibleName),
    SearchKeywordsResourceName = nameof(Properties.Resources.SearchKeywords),
    GroupName = "My Group")]
[TargetPlatform(Platform.Windows)]
[TargetPlatform(Platform.MacOS)]
//[Order(Before = "My Other Tool")]
[NoCompactOverlaySupport]
internal sealed class MyGuiTool : IGuiTool
{
    private readonly IUIButton _button = Button();

    private IUISingleLineTextInput _singleLineTextInput = SingleLineTextInput();

    private ILogger logging = LoggingExtensions.Log(HelloWorld.Properties.Resources.Description);


    public UIToolView View
        => new UIToolView(
            Stack()
                .Vertical()
                .WithChildren(
                    _button
                        .Text("Click me")
                        .OnClick(OnButtonClick),
                    _singleLineTextInput
                        .Title("Single Line Text Input")
                        .OnTextChanged(OnSingleLineTextInputTextChanged)
                ));

    public void OnDataReceived(string dataTypeName, object? parsedData)
    {
        // Handle Smart Detection.
    }

    private void OnButtonClick()
    {
        _button.Text("Clicked !");
    }


    private void OnSingleLineTextInputTextChanged(string text)
    {
        // %LocalAppData%\DevToys-preview\Logs
        logging.Log(LogLevel.Information, text);

        Console.WriteLine(text);
    }
}
