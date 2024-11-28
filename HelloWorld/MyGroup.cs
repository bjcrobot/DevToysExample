using DevToys.Api;
using System.ComponentModel.Composition;

namespace HelloWorld;

[Export(typeof(GuiToolGroup))]
[Name("My Group")]
[Order(After = PredefinedCommonToolGroupNames.Converters)]
internal class MyGroup : GuiToolGroup   
{
    [ImportingConstructor]
    internal MyGroup()
    {
        IconFontName = "FluentSystemIcons";
        IconGlyph = '\uE670';
        DisplayTitle = HelloWorld.Properties.Resources.MyGroupDisplayTitle;
        AccessibleName = HelloWorld.Properties.Resources.MyGroupAccessibleName;
    }
}