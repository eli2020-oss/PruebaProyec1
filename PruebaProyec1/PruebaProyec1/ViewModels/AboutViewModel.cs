using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
// parte superior del menu, o menu de la parte superior 
namespace PruebaProyec1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        // llama a clase baseviewmodel en la carpeta viewmodels 
        public AboutViewModel()
        {
            //Title = "Todos";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}