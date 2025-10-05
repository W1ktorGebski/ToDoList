namespace ToDoList
{
    public partial class TaskDetails : ContentPage
    {
        public TaskDetails(Task selectedTask)
        {
            InitializeComponent();
            if (selectedTask != null)
            {
                TaskNameLabel.Text = selectedTask.Name;
                TaskDescriptionLabel.Text = selectedTask.Description;
            }
        }
    }
}
