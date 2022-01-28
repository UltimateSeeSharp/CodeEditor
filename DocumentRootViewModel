public class DocumentRootViewModel : ViewModelBase
{
    private string _FilePath;

    private TextDocument _Document;
    private bool _IsDirty;
    private bool _IsReadOnly;
    private string _IsReadOnlyReason = string.Empty;

    private ICommand _HighlightingChangeCommand;
    private IHighlightingDefinition _HighlightingDefinition;

    public DocumentRootViewModel()
    {
        Document = new TextDocument();
    }

    public TextDocument Document
    {
        get { return _Document; }
        set
        {
            if (_Document != value)
            {
                _Document = value;
                RaisePropertyChanged(() => Document);
            }
        }
    }

    public bool IsDirty
    {
        get { return _IsDirty; }
        set
        {
            if (_IsDirty != value)
            {
                _IsDirty = value;
                RaisePropertyChanged(() => IsDirty);
            }
        }
    }

    public string FilePath
    {
        get { return _FilePath; }
        set
        {
            if (_FilePath != value)
            {
                _FilePath = value;

                RaisePropertyChanged(() => FilePath);
            }
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return _IsReadOnly;
        }

        protected set
        {
            if (_IsReadOnly != value)
            {
                _IsReadOnly = value;
                RaisePropertyChanged(() => IsReadOnly);
            }
        }
    }

    public string IsReadOnlyReason
    {
        get
        {
            return _IsReadOnlyReason;
        }

        protected set
        {
            if (_IsReadOnlyReason != value)
            {
                _IsReadOnlyReason = value;
                RaisePropertyChanged(() => IsReadOnlyReason);
            }
        }
    }

    public ReadOnlyCollection<IHighlightingDefinition> HighlightingDefinitions
    {
        get
        {
            var hlManager = HighlightingManager.Instance;

            if (hlManager != null)
                return hlManager.HighlightingDefinitions;

            return null;
        }
    }

    public IHighlightingDefinition HighlightingDefinition
    {
        get
        {
            return _HighlightingDefinition;
        }

        set
        {
            if (_HighlightingDefinition != value)
            {
                _HighlightingDefinition = value;
                RaisePropertyChanged(() => HighlightingDefinition);
            }
        }
    }

    public ICommand HighlightingChangeCommand
    {
        get
        {
            if (_HighlightingChangeCommand == null)
            {
                _HighlightingChangeCommand = new RelayCommand<object>((p) =>
                {
                    var parames = p as object[];

                    if (parames == null)
                        return;

                    if (parames.Length != 1)
                        return;

                    var param = parames[0] as IHighlightingDefinition;
                    if (param == null)
                        return;

                    HighlightingDefinition = param;
                });
            }

            return _HighlightingChangeCommand;
        }
    }

    public bool LoadDocument(string paramFilePath)
    {
        if (File.Exists(paramFilePath))
        {
            Document = new TextDocument();

            using (FileStream fs = new FileStream(paramFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader reader = FileReader.OpenStream(fs, Encoding.UTF8))
                {
                    Document = new TextDocument(reader.ReadToEnd());
                }
            }

            FilePath = paramFilePath;

            return true;
        }

        return false;
    }
}
