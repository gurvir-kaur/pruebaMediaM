namespace pruebaMediaMarkt.Modelo
{
    public class Producto
    {
        //Declaración de las propiedades de la clase Producto
        private string nombre;
        private string descripcion;
        private double precio;
        private string familia;

        // Constructor de la clase
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