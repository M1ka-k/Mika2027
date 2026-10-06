using Mika2027.Services;
using System.Text.RegularExpressions;
using Mika2027.Models;

namespace Mika2027.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        userName.Text = "";
        password.Text = "";
    }

    private void Button_Clicked_Login(object sender, EventArgs e)
    {
        string regExpStrName = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        bool isValidName = Regex.IsMatch(userName.Text, regExpStrName);

        string regExpStrPass = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
        bool isValidPass = Regex.IsMatch(password.Text, regExpStrPass);

        if (isValidName && isValidPass)
        {
            errorMsgName.Text = "good";
            errorMsgPass.Text = "good";

            if (DataRepo.user.GetUserName() == userName.Text &&
                DataRepo.user.GetPassword() == password.Text)
            {
                errorMsgName.Text = "Get in";
                errorMsgPass.Text = "Get in";
                // TODO: נווט לעמוד הראשי
            }
            else if (DataRepo.user.GetPassword() == password.Text)
            {
                errorMsgName.Text = "Username incorrect";
            }
            else if (DataRepo.user.GetUserName() == userName.Text)
            {
                errorMsgPass.Text = "Password incorrect";
            }
            else
            {
                errorMsgName.Text = "Username incorrect";
                errorMsgPass.Text = "Password incorrect";
            }
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

    private void Show_Password(object sender, EventArgs e) => password.IsPassword = false;
    private void Hide_Password(object sender, EventArgs e) => password.IsPassword = true;

    private async void LinkToReg(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
}
