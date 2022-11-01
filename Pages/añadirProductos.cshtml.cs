using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace pruebaMediaMarkt.Pages
{
    public class añadirProdcutosModel : PageModel
    {
        public Producto productInfo = new Producto();
        public string message = "";

        public void OnGet()
        {
        }

        //POST METHOD
        public void onPost()
        {
            productInfo.Nombre = Request.Form["nombre"];
            productInfo.Descripcion = Request.Form["descripcion"];
            productInfo.Precio = Convert.ToDouble(Request.Form["precio"]);
            productInfo.Familia = Request.Form["familia"];

            //SAVING DATA TO DATABASE
            try
            {
                string connectionString = "Server = gurvirkaur; Database = pruebaMediaMarkt; Trusted_Connection = True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int id = 0;
                    string sql = "Insert INTO productos (id, nombre, descripcion, precio, familia) Values (@id, @nombre, @descripcion, @precio, @familia)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", productInfo.Nombre);
                        command.Parameters.AddWithValue("@descripcion", productInfo.Descripcion);
                        command.Parameters.AddWithValue("@precio", productInfo.Precio);
                        command.Parameters.AddWithValue("@familia", productInfo.Familia);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }

            Response.Redirect("/Productos");
        }
    }
}
