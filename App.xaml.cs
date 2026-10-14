using Microsoft.Extensions.DependencyInjection;
using Mika2027.Services;

namespace Mika2027
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DataRepo.LoadYarnFakeData();
            DataRepo.LoadUserFakeData();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}