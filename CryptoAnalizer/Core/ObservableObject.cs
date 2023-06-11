using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoAnalizer.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if(PropertyChanged != null) 
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
