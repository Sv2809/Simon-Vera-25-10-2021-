using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (Item)BindingContext;
            Item_B database = await Item_B.Instance;
            _ = await database.SaveItemAsync(todoItem);
            _ = await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Item)BindingContext;
            Item_B database = await Item_B.Instance;
            _ = await database.DeleteItemAsync(todoItem);
            _ = await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}