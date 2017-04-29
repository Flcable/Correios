using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Correios.Net;

namespace Correios.Controllers
{
    public class CorreiosController : Controller
    {
        // GET: Correios
        public ActionResult Index()
        {
            return View();
        }
        
        public string cep(string id)
        {
            string endereco;
           
           if (!string.IsNullOrWhiteSpace(id))
            {
                string ncep = id.ToString();
                ncep = ncep.Replace("-", "").Replace(",", "").Replace(".", "").Replace(" ", "");
                Address enderecoEncontrado = SearchZip.GetAddress(ncep);
                if (enderecoEncontrado.Zip != null)
                {
                    endereco = enderecoEncontrado.State + " , ";
                    endereco += enderecoEncontrado.City + " , ";
                    endereco += enderecoEncontrado.District + " , ";
                    endereco += enderecoEncontrado.Street + " , ";
                }
                else
                {
                    endereco = "Cep não localizado";
                }
              
            }
            else
            {
                endereco = "Informe um Cep";
            }
            return endereco;
        }
        //fim da busca cep
    }
}