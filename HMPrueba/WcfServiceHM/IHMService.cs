using HM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceHM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHMService" in both code and config file together.
    [ServiceContract]
    public interface IHMService
    {
        [OperationContract]
        bool ValidaConexionSQL();

        [OperationContract]
        string CreateCustomer(String CustomerName, String Contact, String Email, string Rif);

        [OperationContract]
        List<Customer> ListarCustomer([Optional]string Rif);

        [OperationContract]
        string DeleteCustomer(string Rif);

        [OperationContract]
        Customer ValidarCustomerByRif(string Rif);

        [OperationContract]
        string CreateItem(string Codigo, string Description, decimal Price);

        [OperationContract]
        List<Item> ListarItem(string Codigo);

        [OperationContract]
        string DeleteItem(string Codigo);

        [OperationContract]
        Item ValidarItemByCod(string Codigo);

        [OperationContract]
        string CreateSale(Sales objVentas, List<SalesDetail> ListaItem);

        [OperationContract]
        List<Sales> ListarSales(int SaleId);

        [OperationContract]
        int SumarLista(List<Numeros> N);
    }
}
