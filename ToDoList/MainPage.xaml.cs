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

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var selectedItem = tasklist.SelectedItem as Task;
            if (selectedItem != null)
            {
                bool canDelete = true;

                if (!selectedItem.IsCompleted)
                {
                    bool confirm = await DisplayAlert(
                        "Zadanie nie wykonane",
                        "Zadanie nie jest wykonane, czy na pewno chcesz je usun¹æ?",
                        "Tak", "Nie");

                    canDelete = confirm;
                }

                if (canDelete)
                {
                    Tasks.Remove(selectedItem);
                    tasklist.SelectedItem = null;
                }
            }
            else
            {
                await DisplayAlert("Uwaga", "Najpierw wybierz zadanie do usuniêcia.", "OK");
            }
        }

        private async void ShowDetails_Clicked(object sender, EventArgs e)
        {
            var selectedItem = tasklist.SelectedItem as Task;
            if (selectedItem != null)
            {
                await Navigation.PushAsync(new TaskDetails(selectedItem));
            }
            else
            {
                await DisplayAlert("Uwaga", "Wybierz zadanie z listy, aby zobaczyæ szczegó³y.", "OK");
            }
        }
    }
}
