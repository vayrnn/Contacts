using System.Collections.ObjectModel;
using System.Windows;

namespace WpfContactsApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>();
            ContactsListBox.ItemsSource = Contacts;
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                Contacts.Add(new Contact { Name = NameTextBox.Text, Phone = PhoneTextBox.Text });
                NameTextBox.Clear();
                PhoneTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите имя и номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
