using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionSoftware.Domain;

namespace EncryptionSoftware.Persistence.Data
{
    public class SeedData
    {
        public static List<Productos> Products = new List<Productos>()
        {
            new Productos
            {
                Codigo = 1,
                Descripcion = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                Imagen = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>()
            },new Productos
            {
                Codigo = 2,
                Descripcion = "Mens Casual Premium Slim Fit T-Shirts",
                Imagen = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>()
            },new Productos
            {
                Codigo = 3,
                Descripcion = "Mens Cotton Jacket",
                Imagen = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){5000}
            },new Productos
            {
                Codigo = 4,
                Descripcion = "Mens Casual Slim Fit",
                Imagen = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){50000}
            },new Productos
            {
                Codigo = 5,
                Descripcion = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
                Imagen = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){50400}
            },new Productos
            {
                Codigo = 6,
                Descripcion = "Solid Gold Petite Micropave",
                Imagen = "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){4500}
            },new Productos
            {
                Codigo = 7,
                Descripcion = "White Gold Plated Princess",
                Imagen = "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){95000}
            },new Productos
            {
                Codigo = 8,
                Descripcion = "Pierced Owl Rose Gold Plated Stainless Steel Double",
                Imagen = "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){36800}
            },new Productos
            {
                Codigo = 9,
                Descripcion = "WD 2TB Elements Portable External Hard Drive - USB 3.0",
                Imagen = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg",
                ProductoParaLaVenta = true,
                Iva = 19,
                ListaDePrecios = new List<int>(){89000}
            },
        };
    }
}