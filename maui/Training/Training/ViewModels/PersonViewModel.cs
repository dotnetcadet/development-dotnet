using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCadet.Samples.ViewModels;

public partial class PersonViewModel : INotifyPropertyChanged
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get => this.FirstName;
        set
        {
            this.FirstName = value;
            OnPropertyChange(nameof(FirstName));
        }
    }
    public string LastName
    {
        get => this.LastName;
        set
        {
            this.lastName = value;
            OnPropertyChange(nameof(LastName));
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChange(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
