public class MainWindowsViewModel : ViewModelBase
{
    private readonly DocumentRootViewModel _demo;

    public MainWindowsViewModel()
    {
        _demo = new DocumentRootViewModel();
    }

    public DocumentRootViewModel DocumentRoot
    {
        get
        {
            return _demo;
        }
    }
}
