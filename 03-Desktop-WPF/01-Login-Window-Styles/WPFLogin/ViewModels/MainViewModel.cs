namespace WPF_LoginForm.ViewModels
{
    public class UserAccountModel
    {
        public string Username { get; set; } = "Admin";
        public string DisplayName { get; set; } = "Welcome, Administrator!";
    }

    public class MainViewModel
    {
        public UserAccountModel CurrentUserAccount { get; set; } = new UserAccountModel();
    }
}
