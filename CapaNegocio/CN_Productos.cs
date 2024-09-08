using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Producto objCapaDato = new CD_Producto();
        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "Le nom du produit ne peut pas être vide";
            }
            else
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La description du produit ne peut pas être vide";
            }
            else
            if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Vous devez choisir une marque";
            }
            else
            if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Vous devez choisir une catégorie";
            }
            else
            if (obj.Precio == 0)
            {
                Mensaje = "Vous devez saisir le prix du produit";
            }
            else
            if (obj.Stock == 0)
            {
                Mensaje = "Vous devez saisir le stock\r\n";
            }
          

            if (string.IsNullOrEmpty(Mensaje))
            {
                    return objCapaDato.Registrar(obj, out Mensaje);              
            }
            else
            {
                return 0;
            }

        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
             
                if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
                {
                    Mensaje = "Le nom du produit ne peut pas être vide";
                }
                else
                if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
                {
                    Mensaje = "La description du produit ne peut pas être vide";
                }
                else
                if (obj.oMarca.IdMarca == 0)
                {
                    Mensaje = "Vous devez choisir une marque";
                }
                else
                if (obj.oCategoria.IdCategoria == 0)
                {
                    Mensaje = "Vous devez choisir une catégorie";
                }
                else
                if (obj.Precio == 0)
                {
                    Mensaje = "Vous devez saisir le prix du produit";
                }
                else
                if (obj.Stock == 0)
                {
                    Mensaje = "Vous devez saisir le stock\r\n";
                }





            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
                return false;
        }


        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje); ;
        }

        public bool Eliminar(int IdProducto, out string Mensaje)
        {
            return objCapaDato.Eliminar(IdProducto,out Mensaje);
        }
    }
}
