using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
namespace Mockup;

public partial class NewPage1 : ContentPage
{
    private readonly SharedUser sharedUser = new();
    public NewPage1()
    {
        InitializeComponent();
    }

}