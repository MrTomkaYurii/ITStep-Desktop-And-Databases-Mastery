using MVP.Views;

namespace MVP.Views;

public partial class MainView : Form, IMainView
{
    public MainView()
    {
        InitializeComponent();
        btnPets.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };
    }

    public event EventHandler ShowPetView;
    public event EventHandler ShowOwnerView;
    public event EventHandler ShowVetsView;
}
