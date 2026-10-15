using System;
using System.Text.RegularExpressions;
using Mika2027.Models;
using Mika2027.Services;

namespace Mika2027.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        userName.Text = "";
        password.Text = "";
    }

    private async void ButtonClickedLogin(object sender, EventArgs e)
    {
        errorMsgGenral.Text = "";
        errorMsgName.Text = "";
        errorMsgPass.Text = "";

        if (userName.Text == "")
        {
            errorMsgName.Text = "Please enter your email";
        }

        if (password.Text == "")
        {
            errorMsgPass.Text = "Please enter your password";
        }

        if (userName.Text == "" || password.Text == "")
        {
            return;
        }

        string regExpStrEmail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        bool isValidEmail = Regex.IsMatch(userName.Text, regExpStrEmail);

        string regExpStrPass = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
        bool isValidPass = Regex.IsMatch(password.Text, regExpStrPass);

        if (!isValidEmail)
        {
            errorMsgName.Text = "Incorrect Email Format";
        }

        if (!isValidPass)
        {
            errorMsgPass.Text = "Incorrect Password Format";
        }

        if (!isValidEmail || !isValidPass)
        {
            return;
        }

        bool isAuthenticated = DataRepo.CheckUserAuth(userName.Text, password.Text);

        if (!isAuthenticated)
        {
            errorMsgGenral.Text = "Username or password is wrong";
            return;
        }

        await Shell.Current.GoToAsync("//MainPage");
    }

    private void ShowPassword(object sender, EventArgs e)
    {
        password.IsPassword = false;
        togglePassBtn.Text = Helper.IconFont.Visibility;
    }

    private void HidePassword(object sender, EventArgs e)
    {
        password.IsPassword = true;
        togglePassBtn.Text = Helper.IconFont.Visibility_off;
    }

    private async void LinkToReg(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RegisterPage");
    }
}