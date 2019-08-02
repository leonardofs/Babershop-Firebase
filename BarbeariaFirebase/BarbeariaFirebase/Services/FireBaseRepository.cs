using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using BarbeariaFirebase.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace BarbeariaFirebase.Services
{
    public class FireBaseRepository:Prism.Mvvm.BindableBase
    {

        private readonly string ENDERECO_FIREBASE = "https://barbearia-divi.firebaseio.com/";
        private readonly FirebaseClient _firebaseClient;

        private ObservableCollection<BarberService> _barberServicesList;

        public ObservableCollection<BarberService> BarberServicesList{ get; set;  }

        /// <summary>
        /// Construtor
        /// </summary>
        public FireBaseRepository()
        {
            try
            {
                _firebaseClient = new FirebaseClient(ENDERECO_FIREBASE,null);
                BarberServicesList = new ObservableCollection<BarberService>();
                //AceitarPedidoCmd = new Command(() => AceitarPedido());
                //ListenerPedidos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            _firebaseClient = new FirebaseClient(ENDERECO_FIREBASE);
             BarberServicesList  = new ObservableCollection<BarberService>();
            //AceitarPedidoCmd = new Command(() => AceitarPedido());
            //ListenerPedidos();
        }


        public  ObservableCollection<BarberService>  GetBarberServicesList()
        {
            //ObservableCollection<BarberService> result = new ObservableCollection<BarberService>();
            //PedidoSelecionado.IdVendedor = 1;
            return _firebaseClient
                 .Child("BarberServices")
                 .AsObservable<BarberService>()
                 .AsObservableCollection();
        
        }



        public async Task PostBarberService(BarberService barber) {

           await _firebaseClient.Child("BarberServices")
            .PostAsync(barber);

        }


            //private void ListenerPedidos()
            //{
            //    _firebaseClient
            //        .Child("pedidos")
            //        .AsObservable<Pedido>()
            //        .Subscribe(d =>
            //        {
            //            if (d.EventType == FirebaseEventType.InsertOrUpdate)
            //            {
            //                if (d.Object.IdVendedor == 0)
            //                    AdicionarPedido(d.Key, d.Object);
            //                else
            //                    RemoverPedido(d.Key);
            //            }
            //            else if (d.EventType == FirebaseEventType.Delete)
            //            {
            //                RemoverPedido(d.Key);
            //            }
            //        });
            //}
        }


}
