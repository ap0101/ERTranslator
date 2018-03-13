using System.ComponentModel;


namespace ERTranslator
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(property);
                PropertyChanged(this, e);
            }
        }

        private string originalText;
        public string OriginalText
        {
            get
            {
                return originalText;
            }
            set
            {
                originalText = value;
                OnPropertyChanged("OriginalText");
            }
        }

        private string translatedText;
        public string TranslatedText
        {
            get
            {
                return translatedText;
            }
            set
            {
                translatedText = value;
                OnPropertyChanged("TranslatedText");
            }
        }

        private bool direction;
        public bool Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                OnPropertyChanged("Direction");
            }
        }

        public Command TranslateCommand { get; private set; }
        TranslatorApi tsapi = new TranslatorApi();
        History history = new History();

        public ViewModel()
        {
            TranslateCommand = new Command();
            TranslateCommand.MyAction = TranslateClick;
        }
        
        private void TranslateClick(object sender)
        {
            TranslatedText = tsapi.Translate(OriginalText, Direction);
            history.DBInsert(OriginalText, TranslatedText);
        }
    }
}
