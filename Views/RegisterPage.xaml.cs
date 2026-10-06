using System.Text.RegularExpressions;
using Mika2027.Services;

namespace Mika2027.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        userName.Text = "";
        password1.Text = "";
        password2.Text = "";
    }

    private async void Button_Clicked_Register(object sender, EventArgs e)
    {
        string regExpStrName = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        bool isValidName = Regex.IsMatch(userName.Text, regExpStrName);

        string regExpStrPass = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
        bool isValidPass = Regex.IsMatch(password1.Text, regExpStrPass);

        if (password1.Text != password2.Text)
        {
            errorMsgPass.Text = "Passwords are not the same";
            return;
        }

        if (isValidName && isValidPass)
        {
            DataRepo.user.SetUsername(userName.Text);
            DataRepo.user.SetPassword(password1.Text);

            await Navigation.PushModalAsync(new LoginPage());
        }
        else if (isValidPass)
        {
            errorMsgName.Text = "Not in Correct Email Format";
            errorMsgPass.Text = "good";
        }
        else if (isValidName)
        {
            errorMsgPass.Text = "Not in Correct Password Format";
            errorMsgName.Text = "good";
        }
        else
        {
            errorMsgPass.Text = "Not in Correct Password Format";
            errorMsgName.Text = "Not in Correct Email Format";
        }
    }

    private void Show_Password(object sender, EventArgs e) => password1.IsPassword = false;
    private void Hide_Password(object sender, EventArgs e) => password1.IsPassword = true;

    private async void LinkToLogin(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}