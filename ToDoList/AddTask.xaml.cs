using System.Collections.ObjectModel;

namespace ToDoList;

public partial class AddTask : ContentPage
{
    private ObservableCollection<Task> _Tasks;
    public AddTask(ObservableCollection<Task> Tasks)
	{
		InitializeComponent();
		_Tasks = Tasks;
	}

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var description = EntryOpis.Text;
        var text = EntryTask.Text;
        if (!string.IsNullOrWhiteSpace(text))
        {
            _Tasks.Add(new Task { Name = text, Description = description });
            await Navigation.PopAsync();
        }
    }

}