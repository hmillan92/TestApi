using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HM_BusinessLogic;
using HM_Entities;
using PJ.DataLayer;

namespace WcfServiceHM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HMService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HMService.svc or HMService.svc.cs at the Solution Explorer and start debugging.
    public class HMService : IHMService
    {
        FuncionesLogicas Funciones = new FuncionesLogicas();

        public bool ValidaConexionSQL()
        {
            bool Exitosa = Funciones.ValidaConexionSQL();

            return Exitosa;
        }

        public string CreateCustomer(string CustomerName, string Contact, string Email, string Rif)
        {
            string Mensaje;

            Customer ObjeCustomer = new Customer()
            {
                CustomerName = CustomerName,
                Contact = Contact,
                Email = Email,
                Rif = Rif
            };

            Mensaje = Funciones.CreateCustomer(ObjeCustomer);

            return Mensaje;
        }

        public List<Customer> ListarCustomer([Optional] string Rif)
        {
            List<Customer> ListaClientes = Funciones.ListarCustomers(Rif);

            return ListaClientes;
        }

        public string DeleteCustomer(string Rif)
        {
            string Mensaje;

            Mensaje = Funciones.DeleteCustomer(Rif);
            return Mensaje;
        }

        public Customer ValidarCustomerByRif(string Rif)
        {
            Customer customer = new Customer();

            customer = Funciones.ValidarCliente(Rif);

            return customer;
        }

        public string CreateItem(string Codigo, string Description, decimal Price)
        {
            string Respuesta;
            Item objItem = new Item();
            {
                objItem.Codigo = Codigo;
                objItem.Description = Description;
                objItem.Price = Price;
            }

            Respuesta = Funciones.CreateItem(objItem);
            return Respuesta;
        }

        public List<Item> ListarItem([Optional] string Codigo)
        {
            List<Item> ListaArticulos = Funciones.ListarItems(Codigo);
            return ListaArticulos;
        }

        public string DeleteItem(string Codigo)
        {
            string Respuesta;
            Respuesta = Funciones.DeleteItem(Codigo);
            return Respuesta;
        }

        public Item ValidarItemByCod(string Codigo)
        {
            Item Articulos = Funciones.ValidarItem(Codigo);
            return Articulos;
        }

        public List<Sales> ListarSales(int SaleId)
        {
            List<Sales> ListaVentas = Funciones.ListarSales(SaleId);
            return ListaVentas;
        }

        public int SumarLista(List<Numeros> N)
        {
           int Suma = Funciones.Numer(N);
            return Suma;
        }

        public string CreateSale(Sales objVentas, List<SalesDetail> ListaItem)
        {
            string Respuesta;

            Respuesta = Funciones.CreateSale(objVentas, ListaItem);
            return Respuesta;
        }
    }
}
