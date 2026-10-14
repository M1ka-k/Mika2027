using Mika2027.Models;
using Microsoft.Maui.Controls.Shapes;
using Mika2027.Services;
namespace Mika2027.Views;

public partial class InventoryListPage : ContentPage
{

    public InventoryListPage()
    {

        InitializeComponent();
        PopulateYarnList();
    }

   

    private void PopulateYarnList()
    {
        YarnFlexLayout.Children.Clear();

        foreach (var yarn in DataRepo.yarns)
        {
            YarnFlexLayout.Children.Add(CreateYarnBorder(yarn));
        }
    }

    private Border CreateYarnBorder(Yarn yarn)
    {
        var image = new Image
        {
            Source = yarn.Image,
            Aspect = Aspect.AspectFill,
            Margin = 5
        };

        var nameLabel = new Label
        {
            Text = yarn.Name,
            FontAttributes = FontAttributes.Bold,
            FontSize = 14,
            LineBreakMode = LineBreakMode.TailTruncation,
            MaxLines = 1
        };

        var brandLabel = new Label
        {
            Text = yarn.Brand,
            FontSize = 12,
            TextColor = Colors.Gray,
            LineBreakMode = LineBreakMode.TailTruncation,
            MaxLines = 1
        };

        var fiberText = string.Join(" • ", yarn.Materials);
        var fiberLabel = new Label
        {
            Text = fiberText,
            FontSize = 11,
            TextColor = Colors.DarkSlateGray,
            LineBreakMode = LineBreakMode.TailTruncation,
            MaxLines = 1
        };

        var detailsLabel = new Label
        {
            Text = $"{yarn.Skeins} skein(s) • {yarn.Grams}g • {yarn.Yards}yds",
            FontSize = 11,
            FontAttributes = FontAttributes.Italic
        };

        var infoStack = new VerticalStackLayout
        {
            Margin= 8,
            Spacing = 1,
            Children = { nameLabel, brandLabel, fiberLabel, detailsLabel }
        };

        var grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(2.2, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1.3, GridUnitType.Star) }
            }
        };
        Grid.SetRow(image, 0);
        Grid.SetRow(infoStack, 1);
        grid.Children.Add(image);
        grid.Children.Add(infoStack);

        var border = new Border
        {
            Background = new SolidColorBrush(Colors.Beige),
            StrokeShape = new RoundRectangle { CornerRadius = 10 },
            StrokeThickness = 0,
            WidthRequest = 200,
            HeightRequest = 235, 
            Margin = 5,
            Content = grid
        };

        return border;
    }
}