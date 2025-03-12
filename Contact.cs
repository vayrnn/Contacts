using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    public class Contact : INotifyPropertyChanged
    {
        private string name;
        private string phone;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
