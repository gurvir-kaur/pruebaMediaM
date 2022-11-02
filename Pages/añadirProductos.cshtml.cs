using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace pruebaMediaMarkt.Pages
{
    public class añadirProductosModel : PageModel
    {
        public Producto productInfo = new Producto();
        public string message = "";
        private string connectionString = "Server = gurvirkaur; Database = pruebaMediaMarkt; Trusted_Connection = True;";

        public void OnGet()
        {
        }

        //POST METHOD
        public void OnPost()
        {
            productInfo.Nombre = Request.Form["nombre"];
            productInfo.Descripcion = Request.Form["descripcion"];
            productInfo.Precio = Convert.ToDouble(Request.Form["precio"]);
            productInfo.Familia = Request.Form["familia"];

            if (productInfo.Nombre.Length == 0 || productInfo.Descripcion.Length == 0 || productInfo.Precio == 0 || productInfo.Familia.Length == 0)
            {
                message = "Error";
                return;
            }


            //SAVING DATA TO DATABASE
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //SELECT max(id) FROM productos
                    int new_id = GetId();
                    string sql = "Insert INTO productos (id, nombre, descripcion, precio, familiaProducto) Values (@id, @nombre, @descripcion, @precio, @familia);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", new_id);
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
                return;
            }

            Response.Redirect("/Productos");
        }

        private int GetId()
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //update id
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(id) FROM productos", con))
                {
                    con.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    con.Close();
                    return id;
                }
            }
        }
    }
}
