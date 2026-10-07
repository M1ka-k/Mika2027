using Mika2027.Models;
using Mika2027.Services;
using System;
using System.Text.RegularExpressions;

namespace Mika2027.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();

        fullName.Text = "";
        userName.Text = "";
        email.Text = "";
        password1.Text = "";
        password2.Text = "";
    }

    private async void Button_Clicked_Register(object sender, EventArgs e)
    {
        errorMsgFullName.Text = "";
        errorMsgName.Text = "";
        errorMsgEmail.Text = "";
        errorMsgPass.Text = "";
        errorMsgConfirm.Text = "";

        bool isValid = true;

        // Full Name
        if (fullName.Text == "")
        {
            errorMsgFullName.Text = "Please enter your full name";
            isValid = false;
        }

        // Username
        if (userName.Text == "")
        {
            errorMsgName.Text = "Please enter a username";
            isValid = false;
        }
        else
        {
            User existingUser = DataRepo.GetUser(userName.Text);

            if (existingUser != null)
            {
                errorMsgName.Text = "Username already exists";
                isValid = false;
            }
        }

        // Email
        string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        bool isValidEmail =
            email.Text != "" &&
            Regex.IsMatch(email.Text, emailRegex);

        if (!isValidEmail)
        {
            errorMsgEmail.Text = "Incorrect email format";
            isValid = false;
        }

        // Password
        string passwordRegex =
            @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";

        bool isValidPassword =
            password1.Text != "" &&
            Regex.IsMatch(password1.Text, passwordRegex);

        if (!isValidPassword)
        {
            errorMsgPass.Text =
                "Password must contain 8 characters, uppercase, lowercase and number";

            isValid = false;
        }

        // Confirm Password
        if (password2.Text == "")
        {
            errorMsgConfirm.Text = "Please confirm your password";
            isValid = false;
        }
        else if (password1.Text != password2.Text)
        {
            errorMsgConfirm.Text = "Passwords are not the same";
            isValid = false;
        }

        // Stop if there is an error
        if (!isValid)
        {
            return;
        }

        // Create new user
        User newUser = new User();

        newUser.FullName = fullName.Text;
        newUser.Email = email.Text;
        newUser.SetUsername(userName.Text);
        newUser.SetPassword(password1.Text);

        // Add user to the list
        DataRepo.users.Add(newUser);

        // Go to Login
        await Navigation.PushModalAsync(new LoginPage());
    }

    private void Show_Password(object sender, EventArgs e)
    {
        password1.IsPassword = false;
    }

    private void Hide_Password(object sender, EventArgs e)
    {
        password1.IsPassword = true;
    }

    private void Show_Confirm_Password(object sender, EventArgs e)
    {
        password2.IsPassword = false;
    }

    private void Hide_Confirm_Password(object sender, EventArgs e)
    {
        password2.IsPassword = true;
    }

    private async void LinkToLogin(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}
