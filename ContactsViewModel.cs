using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new();
        private Contact selectedContact;
        private string newName;
        private string newPhone;

        public Contact SelectedContact
        {
            get => selectedContact;
            set { selectedContact = value; OnPropertyChanged(); }
        }

        public string NewName
        {
            get => newName;
            set { newName = value; OnPropertyChanged(); }
        }

        public string NewPhone
        {
            get => newPhone;
            set { newPhone = value; OnPropertyChanged(); }
        }

        public void AddContact()
        {
            if (!string.IsNullOrWhiteSpace(NewName) && !string.IsNullOrWhiteSpace(NewPhone))
            {
                Contacts.Add(new Contact { Name = NewName, Phone = NewPhone });
                NewName = "";  // Очистка полей после добавления
                NewPhone = "";
            }
        }

        public void RemoveContact()
        {
            if (SelectedContact != null)
                Contacts.Remove(SelectedContact);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
