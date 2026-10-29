using Mika2027.Models;
using Mika2027.Services;

namespace Mika2027.Views;

public partial class NewInventoryPage : ContentPage
{
    public List<Yarn> Yarns{ get; set; }

    public NewInventoryPage()
    {
        InitializeComponent();

        Yarns = DataRepo.yarns.ToList();
        BindingContext = this;
    }
}