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

    private void Button_Clicked_Login(object sender, EventArgs e)
    {
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

        string regExpStrPass =@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";

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

        User user = DataRepo.GetUserByEmail(userName.Text);

        if (user == null)
        {
            errorMsgName.Text = "Email incorrect";
            return;
        }

        if (user.Password != password.Text)
        {
            errorMsgPass.Text = "Password incorrect";
            return;
        }

        errorMsgName.Text = "Get in";
        errorMsgPass.Text = "Get in";
    }

    private void Show_Password(object sender, EventArgs e)
    {
        password.IsPassword = false;
    }

    private void Hide_Password(object sender, EventArgs e)
    {
        password.IsPassword = true;
    }

    private async void LinkToReg(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
}

