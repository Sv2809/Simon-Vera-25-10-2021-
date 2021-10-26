using TodoList.Views;
using Xamarin.Forms;

namespace TodoList
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoItemPage), typeof(TodoItemPage));
            Routing.RegisterRoute(nameof(TodoListPage), typeof(TodoListPage));
        }
    }
}
