using DevToys.Api;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.ComponentModel.Composition;

namespace HelloWorld;

[Export(typeof(ICommandLineTool))]
[Name("My Tool")]
[CommandName(
    Name = "mytool",
    Alias = "mt",
    DescriptionResourceName = nameof(HelloWorld.Properties.Resources.MyToolDescription))]
internal sealed class MyCommandLineTool : ICommandLineTool
{

    [CommandLineOption(
        Name = "input",
        Alias = "i",
        IsRequired = true,
        DescriptionResourceName = nameof(HelloWorld.Properties.Resources.InputOptionDescription))]
    internal string? Input { get; set; }

    public ValueTask<int> InvokeAsync(ILogger logger, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Input: {Input}");
        return new ValueTask<int>(0); ; // Exit code.
    }
}