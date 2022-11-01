using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace pruebaMediaMarkt.Pages
{
    public class ProdcutosModel : PageModel
    {
        public List<Producto> listaProductos = new List<Producto>();

        //GET METHOD
        public void OnGet()
        {
            try
            {
                string connectionString = "Server = gurvirkaur; Database = pruebaMediaMarkt; Trusted_Connection = True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Select * from productos";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader() )
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Nombre = reader.GetString(1);
                                producto.Descripcion = reader.GetString(2);
                                producto.Precio = Convert.ToDouble(reader.GetDecimal(3));
                                producto.Familia = reader.GetString(4);

                                //añadir producto en la lista de productos
                                listaProductos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw;
            }
        }
    }

    public class Producto
    {
        //Declaración de las propiedades de la clase Producto
        private string nombre;
        private string descripcion;
        private double precio;
        private string familia;

        // Constructor de la clase
        public Producto()
        {
            //empty constructor
        }

        public Producto(string nombre, string descripcion, double precio, string familia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.familia = familia; //Smartphones, TV, Portátiles...
        }

        //Definiciones de las preopiedades - gets and sets
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public string Familia
        {
            get { return this.familia; }
            set { this.familia = value; }
        }
    }
}
