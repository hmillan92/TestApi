using HM_DataLayer;
using HM_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PJ.DataLayer
{

    public class DBTrasaccion
    {
        public void DACliente()
        {
            DaConnectSQL DASQLConnection = new DaConnectSQL();
        }

        public bool ValidaConexionSQL()
        {
            bool Exitosa = false;
            var ConClass = new DaConnectSQL();

            ConClass.Open();

            if (ConClass.Con.State == ConnectionState.Open)
                Exitosa = true;

            return Exitosa;
        }

        public string CreateCustomer(Customer ObjCustomer)
        {
            string Respuesta;
            var ConClass = new DaConnectSQL();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();             
                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "Insert into Customers (CustomerName, Contact, Email, Rif) " +
                        "Values  ('" + ObjCustomer.CustomerName + "','" + ObjCustomer.Contact + "', '" + ObjCustomer.Email + "', '" + ObjCustomer.Rif + "')";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Respuesta = "Registro creado";
            }

            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Respuesta = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Respuesta;
        }

        public string ModifyCustomer(Customer ObjCustomer)
        {
            string Respuesta;
            var ConClass = new DaConnectSQL();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();
                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "Update Customers SET CustomerName = '" + ObjCustomer.CustomerName + "', Contact = '" + ObjCustomer.Contact + "', Email = '" + ObjCustomer.Email + "' where Rif = '" + ObjCustomer.Rif + "'";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Respuesta = "Registro modificado";
            }

            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Respuesta = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Respuesta;
        }

        public List<Customer> ListarCustomers([Optional] string Rif)
        {
            List<Customer> ListaCliente = new List<Customer>();
            var ConClass = new DaConnectSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.DASQLConnection();
            cmd.CommandType = CommandType.Text;

            ConClass.Open();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cmd.Connection;

            if (string.IsNullOrEmpty(Rif))
            {
                cmd.CommandText = "SELECT * FROM Customers ";
            }

            else
            {
                cmd.CommandText = "SELECT * FROM Customers where RIF =  '" + Rif + "' ";
            }

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        Customer CLiente = new Customer();
                        CLiente.CustomerId = dr.GetInt32(0);
                        CLiente.CustomerName = dr.GetString(1);
                        CLiente.Contact = dr.GetString(2);
                        CLiente.Email = dr.GetString(3);
                        CLiente.Rif = dr.GetString(4);

                        ListaCliente.Add(CLiente);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return ListaCliente;
        }

        public string DeleteCustomer(Customer Cliente)
        {
            var ConClass = new DaConnectSQL();
            string Result;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();
                cmd.Transaction = ConClass.Con.BeginTransaction();    
                
                cmd.CommandText = "DELETE FROM Customers where Rif =  '" + Cliente.Rif + "' ";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Result = "Registro eliminado";
            }
            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Result = ex.Message;
            }

            return Result;
        }

        public List<Item> ListarItems([Optional] string Codigo)
        {
            List<Item> ListaArticulos = new List<Item>();
            var ConClass = new DaConnectSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.DASQLConnection();
            cmd.CommandType = CommandType.Text;

            ConClass.Open();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cmd.Connection;

            if (string.IsNullOrEmpty(Codigo))
            {
                cmd.CommandText = "SELECT * FROM Items ";
            }

            else
            {
                cmd.CommandText = "SELECT * FROM Items where Codigo =  '" + Codigo + "'";
            }

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        Item Articulo = new Item();
                        Articulo.ItemId = dr.GetInt32(0);
                        Articulo.Codigo = dr.GetString(1);
                        Articulo.Description = dr.GetString(2);
                        Articulo.Price = dr.GetDecimal(3);

                        ListaArticulos.Add(Articulo);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return ListaArticulos;
        }

        public string CreateItem(Item objItem)
        {
            string Respuesta;
            var ConClass = new DaConnectSQL();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();
                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "Insert into Items (Codigo, Description, Price) " +
                        "Values  ('" + objItem.Codigo + "','" + objItem.Description + "', " + objItem.Price+ ")";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Respuesta = "Registro creado";
            }

            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Respuesta = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Respuesta;
        }

        public string ModifyItem(Item objItem)
        {
            string Respuesta;
            var ConClass = new DaConnectSQL();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();
                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "Update Items SET Description = '" + objItem.Description + "', Price = " + objItem.Price + " where Codigo = '" + objItem.Codigo + "'";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Respuesta = "Registro modificado";
            }

            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Respuesta = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Respuesta;
        }

        public string DeleteItem(Item objItem)
        {
            var ConClass = new DaConnectSQL();
            string Result;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();
                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "DELETE FROM Items where Codigo = '" + objItem.Codigo + "'";

                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Result = "Registro eliminado";
            }
            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Result = ex.Message;
            }
            return Result;
        }

        public List<Sales> ListarSales(int SaleId)
        {
            List<Sales> ListaVentas = new List<Sales>();
            var ConClass = new DaConnectSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.DASQLConnection();
            cmd.CommandType = CommandType.Text;

            ConClass.Open();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cmd.Connection;

            if (SaleId == 0)
            {
                cmd.CommandText = "SELECT * FROM Sales ";
            }

            else
            {
                cmd.CommandText = "SELECT * FROM Sales where SaleId =  '" + SaleId + "'";
            }

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        Sales Ventas = new Sales();
                        Ventas.SaleId = dr.GetInt32(0);
                        Ventas.Rif = dr.GetString(1);
                        Ventas.Total = dr.GetDecimal(2);

                        ListaVentas.Add(Ventas);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return ListaVentas;
        }

        public string CreateSale(Sales objVentas, List<SalesDetail> objVentasDetail)
        {
            string Respuesta;
            Sales SaleHeader = new Sales();
            var ConClass = new DaConnectSQL();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = ConClass.Tran;
                ConClass.Open();

                cmd.Transaction = ConClass.Con.BeginTransaction();

                cmd.CommandText = "Insert into Sales (Rif, Total) " +
                        "Values  ('" + objVentas.Rif + "', '" + objVentas.Total + "')";
                cmd.ExecuteNonQuery();

                SaleHeader = BuscarIdFactura(cmd);

                foreach (var item in objVentasDetail)
                {
                    cmd.CommandText = "Insert into SalesDetail (SaleId, Codigo, Quantity, Price, Total) " +
                        "Values  ('" + SaleHeader.SaleId + "','" + item.Codigo + "','" + item.Quantity + "', '" + item.Price + "', '" + SaleHeader.Total + "')";
                    cmd.ExecuteNonQuery();
                }
             
                cmd.Transaction.Commit();
                Respuesta = "Registro creado";
            }

            catch (Exception ex)
            {
                ConClass.RollBackTransaction();
                Respuesta = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Respuesta;
        }

        public Sales BuscarIdFactura(SqlCommand CMD)
        {
            Sales Factura = new Sales();

            CMD.CommandType = CommandType.Text;
            CMD.Connection = CMD.Connection;
            CMD.CommandText = "SELECT TOP 1 * FROM Sales ORDER BY SaleId desc";

            SqlDataReader dr = CMD.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        Factura.SaleId = dr.GetInt32(0);
                        Factura.Rif = dr.GetString(1);
                        Factura.Total = dr.GetDecimal(2);
                    }
                }
                dr.Close();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return Factura;
        }
    }
}
