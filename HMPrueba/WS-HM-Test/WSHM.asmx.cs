using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WS_HM_Test.Clases;

namespace WS_HM_Test
{
    /// <summary>
    /// Summary description for WSHM
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSHM : System.Web.Services.WebService
    {

        [WebMethod]
        public Animales obtenerAnimal(string subgrupo, string tipo, string nombre, string color, string genero)
        {
            Animales Animal = new Animales();
            {
                Animal.Subgrupo = subgrupo;
                Animal.Tipo = tipo;
                Animal.Nombre = nombre;
                Animal.Color = color;
                Animal.Genero = "caracas";
            }
            return Animal;
        }
    }
}
