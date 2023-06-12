using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoAnalizer.Core
{
    public class ObservableObject : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if(PropertyChanged != null) 
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Dispose()
        {
            this.OnDispose();
        }
        protected virtual void OnDispose()
        {

        }
    }
}
