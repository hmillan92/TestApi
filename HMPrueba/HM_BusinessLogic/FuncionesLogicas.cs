using HM_Entities;
using PJ.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HM_BusinessLogic
{
    public class FuncionesLogicas
    {
        DBTrasaccion transaccion = new DBTrasaccion();

        public bool ValidaConexionSQL()
        {
            bool Exitosa = transaccion.ValidaConexionSQL();

            return Exitosa;
        }

        public Customer ValidarCliente(string Rif)
        {

            var queryCustomers = from cust in transaccion.ListarCustomers(Rif)
                                 where cust.Rif == Rif
                                 select cust;

            return queryCustomers.FirstOrDefault();
        }

        public string CreateCustomer(Customer ObjCustomer)
        {

            Customer Cliente = new Customer();
            string Mensaje;

            Cliente = ValidarCliente(ObjCustomer.Rif);

            if (Cliente == null)
            {
                Mensaje = transaccion.CreateCustomer(ObjCustomer);
            }

            else
            {
                Mensaje = transaccion.ModifyCustomer(ObjCustomer);
            }

            return Mensaje;
        }

        public List<Customer> ListarCustomers([Optional] string Rif)
        {
            List<Customer> ListaClientes = transaccion.ListarCustomers(Rif);

            return ListaClientes;
        }

        public string DeleteCustomer(string Rif)
        {
            Customer Cliente = new Customer();
            string BorrarCliente;
            Cliente = ValidarCliente(Rif);

            if (Cliente != null)
            {
                BorrarCliente = transaccion.DeleteCustomer(Cliente);
            }

            else
            {
                BorrarCliente = "Error cliente no existe";
            }

            return BorrarCliente;

        }

        public Item ValidarItem(string Codigo)
        {

            var queryItems = from itm in transaccion.ListarItems(Codigo)
                             where itm.Codigo == Codigo
                             select itm;

            return queryItems.FirstOrDefault();
        }

        public string CreateItem(Item objItem)
        {
            Item Articulo = new Item();
            string Mensaje;          

            Articulo = ValidarItem(objItem.Codigo);

            if (Articulo == null)
            {
                Mensaje = transaccion.CreateItem(objItem);
            }

            else
            {
                Mensaje = transaccion.ModifyItem(objItem);
            }

            return Mensaje;
        }

        public List<Item> ListarItems([Optional] string Codigo)
        {
            List<Item> ListaArticulos = transaccion.ListarItems(Codigo);

            return ListaArticulos;
        }

        public string DeleteItem(string Codigo)
        {
            Item Articulo = new Item();
            string BorrarItem;
            Articulo = ValidarItem(Codigo);

            if (Articulo != null)
            {
                BorrarItem = transaccion.DeleteItem(Articulo);
            }

            else
            {
                BorrarItem = "Error cliente no existe";
            }

            return BorrarItem;

        }

        public string CreateSale(Sales objVentas, List<SalesDetail> ListaItem)
        {
            string Mensaje;
            bool sw = false;
            Customer Cliente = ValidarCliente(objVentas.Rif);

            if (Cliente != null)
            {
                foreach (var item in ListaItem)
                {                   
                    Item Articulo = ValidarItem(item.Codigo);
                    if (Articulo == null)
                    {
                        sw = true;
                    }
                }

                if (sw == true)
                {
                    Mensaje = "Al menos un articulo no existe";
                }

                else
                {
                    Mensaje = transaccion.CreateSale(objVentas, ListaItem);
                }                
            }
            else
            {
                Mensaje = "Registro no existe";
            }

            return Mensaje;
        }

        private Sales ValidarVenta(int SaleId)
        {
            var queryVentas = from itm in transaccion.ListarSales(SaleId)
                             where itm.SaleId == SaleId
                             select itm;

            return queryVentas.FirstOrDefault();
        }

        public List<Sales> ListarSales(int SaleId)
        {
            List<Sales> ListaSales = transaccion.ListarSales(SaleId);

            return ListaSales;
        }

        public int Numer (List<Numeros> Num)
        {
            int Sum = 0;
            foreach (var item in Num)
            {
                Sum = Sum + item.Num;
            }
            return Sum;
        }
    }    
}
