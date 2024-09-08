using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Ubicacion
    {
        private CD_Ubicacion objCapaDato = new CD_Ubicacion();
        public List<Departamento> obtenerDepartamento()
        {
            return objCapaDato.obtenerDepartamento();
        }
        public List<Provincia> obtenerProvincia(string iddepartamento)
        {
            return objCapaDato.obtenerProvincia(iddepartamento);
        }
        public List<Distrito> obtenerDistrito(string iddepartamento, string idprovincia)
        {
            return objCapaDato.obtenerDistrito(iddepartamento, idprovincia);
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "Le nom d'utilisateur ne peut pas être vide";
            }
            else
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "Le nom de famille de l'utilisateur ne peut pas être vide";
            }
            else
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Le mail de l'utilisateur ne peut pas être vide";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = CN_Recursos.generarClave();
                string asunto = "🟢Création du mot de passe";
                string mensaje_correo = "<h3>Votre mot de passe a été créé avec succès</h3></br><p>Votre mot de passe pour y accéder maintenant est: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = CN_Recursos.ConvertirSha256(clave);
                    return objCapaDato.Registrar(obj, out Mensaje);
                }
                else { Mensaje = "Impossible d'envoyer du courrier";
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "Le nom de l'utilisateur ne peut pas être vide";
            }
            else
               if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "Le nom de famille de l'utilisateur ne peut pas être vide";
            }
            else
               if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Le mail de l'utilisateur ne peut pas être vide";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
                return false;
        }

        public bool Eliminar(int IdUsuario, out string Mensaje)
        {
            return objCapaDato.Eliminar(IdUsuario, out Mensaje);
        }
        public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.CambiarClave(idusuario, nuevaclave, out Mensaje);
        }
        public bool RestablecerClave(int idusuario, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave= CN_Recursos.generarClave();
            bool resultado=objCapaDato.Restablecer(idusuario,CN_Recursos.ConvertirSha256(nuevaclave), out Mensaje);

            if (resultado)
            {
                string asunto = "🟢Récuperation du mot de passe !";
                string mensaje_correo = "<h3>Votre mot de passe a été réinitialisé avec succès</h3></br><p>Votre mot de passe pour y accéder maintenant est: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", nuevaclave);

                bool respuesta = CN_Recursos.EnviarCorreo(correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    return true;
                }
                else
                {
                    Mensaje = "Impossible d'envoyer du courrier";
                    return false;
                }
            }
            else
            {
                Mensaje = "Échec de la réinitialisation du mot de passe";
                return false;
            }
             
        }
    }
}
