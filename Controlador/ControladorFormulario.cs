using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class ControladorFormulario
    {

        public bool ValidarFormulario(Formulario formulario)
        {
            bool esValido = true;

            try
            {
                if (string.IsNullOrEmpty(formulario.Dni) || !int.TryParse(formulario.Dni, out _))
                {
                    esValido = false;
                }

                if (string.IsNullOrEmpty(formulario.Nombre) || !formulario.Nombre.All(char.IsLetter))
                {
                    esValido = false;
                }

                if (string.IsNullOrEmpty(formulario.Apellido) || !formulario.Apellido.All(char.IsLetter))
                {
                    esValido = false;
                }

                if (string.IsNullOrEmpty(formulario.Email) || !formulario.Email.Contains("@"))
                {
                    esValido = false;
                }

                if (string.IsNullOrEmpty(formulario.CP) || formulario.CP.Length != 4 || !int.TryParse(formulario.CP, out _))
                {
                    esValido = false;
                }

                if (!formulario.AceptaTerminos)
                {
                    esValido = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return esValido;
        }

        public Cliente ObtenerClientePorDni(string dni)
        {
            try
            {
                ControladorCliente controladorCliente = new ControladorCliente();
                return controladorCliente.ObtenerPorDni(dni);
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
    }
}
