using System.Collections.ObjectModel;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>();
            BindingContext = this;
        }
        private async void AddNewTask(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask(Tasks));
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var selectedItem = tasklist.SelectedItem as Task;
            if (selectedItem != null)
            {
                Tasks.Remove(selectedItem);
                tasklist.SelectedItem = null;
            }
        }
    }
}
