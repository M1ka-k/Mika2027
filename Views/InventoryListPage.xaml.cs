using Mika2027.Models;
using Microsoft.Maui.Controls.Shapes;

namespace Mika2027.Views;

public partial class InventoryListPage : ContentPage
{
    private List<Yarn> _yarns = new List<Yarn>();

    public InventoryListPage()
    {
        InitializeComponent();
        //LoadYarnData();
        //PopulateYarnList();
    }

    private void LoadYarnData()
    {
        _yarns.Add(new Yarn
        {
            Name = "Beach Ball",
            Brand = "Lily Sugar N'cream",
            Weight = 4,
            Grams = 57.0,
            Yards = 95,
            Materials = new List<Material>
            {
                new Material { FiberName = "Cotton", Percent = 100 }
            },
            Colors = new List<string> { "Blue", "White", "Purple", "Green" },
            Skeins = 3,
            ColorLot = null,
            IsNaturalFibers = true,
            IsMachineWashable = true,
            IsVarigated = true,
            Image = "beach_ball.png"
        });

        _yarns.Add(new Yarn
        {
            Name = "Sugar Jewels",
            Brand = "Lily Sugar N'cream",
            Weight = 4,
            Grams = 57.0,
            Yards = 95,
            Materials = new List<Material>
            {
                new Material { FiberName = "Cotton", Percent = 100 }
            },
            Colors = new List<string> { "Blue", "Purple", "Pink" },
            Skeins = 3,
            ColorLot = null,
            IsNaturalFibers = true,
            IsMachineWashable = true,
            IsVarigated = true,
            Image = "sugar_jewels.png"
        });

        _yarns.Add(new Yarn
        {
            Name = "Plush",
            Brand = "BIG TWIST",
            Weight = 6,
            Grams = 300,
            Yards = 153,
            Materials = new List<Material>
            {
                new Material { FiberName = "Polyester", Percent = 100 }
            },
            Colors = new List<string> { "Pink" },
            Skeins = 1,
            ColorLot = null,
            IsNaturalFibers = false,
            IsMachineWashable = true,
            IsVarigated = false,
            Image = "plush_pink.png"
        });

        _yarns.Add(new Yarn
        {
            Name = "Heartland-Frosted Ember",
            Brand = "Lion Brand",
            Weight = 4,
            Grams = 142,
            Yards = 251,
            Materials = new List<Material>
            {
                new Material { FiberName = "Acrylic", Percent = 80 },
                new Material { FiberName = "Wool",    Percent = 20 }
            },
            Colors = new List<string> { "Orange" },
            Skeins = 2,
            ColorLot = null,
            IsNaturalFibers = false,
            IsMachineWashable = true,
            IsVarigated = false,
            Image = "heartland_frosted_amber.png"
        });

        _yarns.Add(new Yarn
        {
            Name = "Wool-Ease Thick & Quick",
            Brand = "Lion Brand",
            Weight = 6,
            Grams = 170,
            Yards = 106,
            Materials = new List<Material>
            {
                new Material { FiberName = "Acrylic", Percent = 80 },
                new Material { FiberName = "Wool",    Percent = 20 }
            },
            Colors = new List<string> { "Blue" },
            Skeins = 4,
            ColorLot = null,
            IsNaturalFibers = false,
            IsMachineWashable = true,
            IsVarigated = false,
            Image = "thick_and_quick_blue.png"
        });

        _yarns.Add(new Yarn
        {
            Name = "Cotton Fair Multi",
            Brand = "Premier Yarns",
            Weight = 4,
            Grams = 100,
            Yards = 317,
            Materials = new List<Material>
            {
                new Material { FiberName = "Cotton",  Percent = 50 },
                new Material { FiberName = "Acrylic", Percent = 50 }
            },
            Colors = new List<string> { "Turquoise", "Coral", "Lime", "Grey" },
            Skeins = 3,
            ColorLot = null,
            IsNaturalFibers = false,
            IsMachineWashable = true,
            IsVarigated = true,
            Image = "cotton_fair_turquoise.png"
        });
    }

    private void PopulateYarnList()
    {
        YarnFlexLayout.Children.Clear();

        foreach (var yarn in _yarns)
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