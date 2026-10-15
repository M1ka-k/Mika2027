using Mika2027.Models;
using Mika2027.Services;
using System.Text.RegularExpressions;

namespace Mika2027.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();

        fullName.Text = "";
        email.Text = "";
        password1.Text = "";
        password2.Text = "";
    }

    private async void ButtonClickedRegister(object sender, EventArgs e)
    {
        errorMsgFullName.Text = "";
        errorMsgEmail.Text = "";
        errorMsgPass.Text = "";
        errorMsgConfirm.Text = "";

        bool isValid = true;

        if (fullName.Text == "")
        {
            errorMsgFullName.Text = "Please enter your full name";
            isValid = false;
        }

        string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        if (email.Text == "")
        {
            errorMsgEmail.Text = "Please enter your email";
            isValid = false;
        }
        else if (!Regex.IsMatch(email.Text, emailRegex))
        {
            errorMsgEmail.Text = "Incorrect email format";
            isValid = false;
        }
        else
        {
            var user = DataRepo.users.Find(infoUser => infoUser.Email.ToLower() == email.Text.ToLower());

            if (user != null)
            {
                errorMsgEmail.Text = "Email already exists";
                isValid = false;
            }
        }

        // Password
        string passwordRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";

        if (password1.Text == "")
        {
            errorMsgPass.Text = "Please enter a password";
            isValid = false;
        }
        else if (!Regex.IsMatch(password1.Text, passwordRegex))
        {
            errorMsgPass.Text = "Password must contain at least 8 characters, uppercase, lowercase and number";
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

        if (!isValid)
        {
            return;
        }

        User newUser = new User();

        newUser.FullName = fullName.Text;
        newUser.Email = email.Text;
        newUser.Password = password1.Text;

        DataRepo.users.Add(newUser);
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void ShowPassword(object sender, EventArgs e)
    {
        password1.IsPassword = false;
        togglePassBtn.Text = Helper.IconFont.Visibility;
    }

    private void HidePassword(object sender, EventArgs e)
    {
        password1.IsPassword = true;
        togglePassBtn.Text = Helper.IconFont.Visibility_off;
    }

    private async void LinkToLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}