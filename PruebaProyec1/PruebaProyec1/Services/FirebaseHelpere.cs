using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PruebaProyec1.Models;
using PruebaProyec1.Views;

namespace PruebaProyec1.Services
{
    class FirebaseHelpere
    {
        FirebaseClient firebase = new FirebaseClient("https://apis-movil-2-default-rtdb.firebaseio.com/Notas");
       //FirebaseClient firebase = new FirebaseClient("https://email-9625d-default-rtdb.firebaseio.com/");


        public async Task AddPerson(String personId, string name)
        {

            await firebase
              .Child("Notas")
              .PostAsync(new Item() { notasId = personId, NotasDescrip = name });
        }
        public ObservableCollection<Item> getItem()
        {
            var itemData = firebase.Child("Notas").AsObservable<Item>()
                .AsObservableCollection();
            return itemData;
        }
        public async Task AddItem(string notasId, string NotasDescrip)
        {
            Item i = new Item() { notasId = notasId, NotasDescrip = NotasDescrip };
            await firebase.Child("Notas")
                .PostAsync(i); 
        }
        /*public async Task DeleteUbicacion(string latitud, string longitud)
        {
            var toDeleteUbicacion = (await firebase.Child("ExamenBD")
                .OnceAsync<Item>()).FirstOrDefault(a => a.Object.latitud == latitud
                || a.Object.longitud == longitud || a.Object.descripcion == descripcion);
            await firebase.Child("ExamenBD").Child(toDeleteUbicacion.Key).DeleteAsync();
        }
        public async Task UpdateUbicaciones(string latitud, string longitud, string descripcion)
        {
            var toUpdateUbicaciones = (await firebase.
                Child("ExamenBD").OnceAsync<Ubicaciones>()).FirstOrDefault
                (a => a.Object.latitud == latitud
                || a.Object.longitud == longitud || a.Object.descripcion == descripcion);
            Ubicaciones u = new Ubicaciones() { latitud = latitud, longitud = longitud, descripcion = descripcion };
            await firebase.Child("ExamenBD").Child(toUpdateUbicaciones.Key).PutAsync(u);
        }*/
    }
}
