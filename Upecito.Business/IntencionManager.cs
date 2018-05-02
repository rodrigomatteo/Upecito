using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upecito.Data;
using Upecito.Data.Implementation;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Business
{
    public class IntencionManager : IIntencion
    {
        private SolicitudData test;

        private SolicitudData Test
        {
            get {
                    if (test == null)
                        test = new SolicitudData();
                    return test;
                }
        }

        public Intencion ObtenerCategoria(string intent)
        {
            //Test.Connect();

            string categoria = string.Empty;

            switch (intent)
            {
                case "Asistencia":
                case "Asistencia1":
                case "Asistencia2":
                case "Asistencia3":
                case "Asistencia4":
                    categoria = "ASISTENCIA";
                    break;
                case "Creditos":
                    categoria = "PROMEDIO";
                    break;
                case "Matricula":
                case "Matricula1":
                case "Matricula2":
                case "Matricula3":
                case "Matricula4":
                case "Matricula5":
                case "Matricula6":
                case "Matricula7":
                case "Matricula8":
                case "Matricula9":
                case "Matricula10":
                case "Reserva":
                    categoria = "MATRICULA";
                    break;
                case "Navegador":
                    categoria = "AULAVIRTUAL";
                    break;
                case "PROGRAMACION":
                    categoria = "PROGRAMACION";
                    break;
                case "CALENDARIO":
                    categoria = "CALENDARIO";
                    break;
                case "CREDITOS":
                    categoria = "CREDITOS";
                    break;
                default:
                    categoria = "Default Fallback Intent";
                    break;
            }

            return new Intencion()
            {
                Categoria = categoria,
                Intent = intent
            };
        }
    }
}
