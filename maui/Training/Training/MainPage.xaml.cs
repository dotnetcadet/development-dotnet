using System.ComponentModel;

namespace Training;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    


    public partial class Model : INotifyPropertyChanged
    {
        private string firstName;


        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                OnPropertyChange(nameof(FirstName));
            }
        }

        public void OnPropertyChange(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}