using PruebaProyec1.Models;
using PruebaProyec1.Services;
using PruebaProyec1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaProyec1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
      
       public Command AddItemCommand { get; }
        public String notasId { get; set; }
        public String NotasDescrip { get; set; }
        FirebaseHelpere services;
     //   private Command AddItemCommand { get; }
        private ObservableCollection<Item> _item = new ObservableCollection<Item>();

        public ObservableCollection<Item> Items
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel()
        {

            // Title = "Notas";
            // Conseguir sacar info
            services = new FirebaseHelpere();
            Items = services.getItem();
            AddItemCommand = new Command(async () => await addItemAsync(notasId, NotasDescrip));

            // intento dos
            /*Items = new ObservableCollection<Item>
               {
                   new Item
                   {
                       notasId ="1",
                       NotasDescrip="hola"

                   },
                   new Item
                   {
                       notasId ="2",
                       NotasDescrip="hola"
                   }
               };*/

        }
        public async Task addItemAsync(string notasId, string NotasDescrip)
        {
            await services.AddItem(notasId, NotasDescrip);
        }
       

      
    }
   
}