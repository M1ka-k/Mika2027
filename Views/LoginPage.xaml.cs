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

        if (string.IsNullOrEmpty(userName.Text))
        {
            errorMsgName.Text = "Please enter your username";
        }

        if (string.IsNullOrEmpty(password.Text))
        {
            errorMsgPass.Text = "Please enter your password";
        }

        if (string.IsNullOrEmpty(userName.Text) ||
            string.IsNullOrEmpty(password.Text))
        {
            return;
        }

        // Email format validation
        string regExpStrName = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        bool isValidName = Regex.IsMatch(userName.Text, regExpStrName);

        // Password format validation
        string regExpStrPass =@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
        bool isValidPass = Regex.IsMatch(password.Text, regExpStrPass);

        if (!isValidName)
        {
            errorMsgName.Text = "incorrect Email Format";
        }

        if (!isValidPass)
        {
            errorMsgPass.Text = "incorrect Password Format";
        }

        // If the format is incorrect, stop
        if (!isValidName || !isValidPass)
        {
            return;
        }

        // Find the user in DataRepo
        User user = DataRepo.GetUser(userName.Text);

        // Username does not exist
        if (user == null)
        {
            errorMsgName.Text = "Username incorrect";
            return;
        }

        // Password is incorrect
        if (user.GetPassword() != password.Text)
        {
            errorMsgPass.Text = "Password incorrect";
            return;
        }

        // Login successful
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

