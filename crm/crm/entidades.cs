using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm
{
    public class entidades
    {
        public class Producto
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PRODUCTO
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public Int32 marca { get; set; }
            public double precio { get; set; }
            public Int32 categoria { get; set; }
            public Int32 porcentaje { get; set; }

            public Producto() { }                   //CONSTRUCTOR VACIO

            public Producto(string codigo, string nombre, string descripcion, Int32 marca, double precio, Int32 categoria, Int32 porcentaje)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.marca = marca;
                this.precio = precio;
                this.categoria = categoria;
                this.porcentaje = porcentaje;
            }
        } //class producto

        public class Categoria
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PERSONA
            public string nombre { get; set; }

            public Categoria() { }                   //CONSTRUCTOR VACIO

            public Categoria(string codigo, string nombre)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.nombre = nombre;
            }
        } //class categoria

        public class Marca
        {
            public int codigo { get; set; }       //ATRIBUTOS DEL OBJETO MARCA
            public string nombre { get; set; }
            public int porcentaje { get; set; }

            public Marca() { }                   //CONSTRUCTOR VACIO

            public Marca(int codigo, string nombre, int porcentaje)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.nombre = nombre;
                this.porcentaje = porcentaje;
            }
        } //class marca

        public class Bodega
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO BODEGA
            public string nombre { get; set; }
            public string direccion { get; set; }

            public Bodega() { }                   //CONSTRUCTOR VACIO

            public Bodega(string codigo, string nombre, string direccion)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.nombre = nombre;
                this.direccion = direccion;
            }
        } //class categoria

        public class Existencia
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PERSONA
            public Int32 cantidad { get; set; }
            public Int32 producto { get; set; }
            public Int32 marca { get; set; }
            public Int32 bodega { get; set; }
            public string ingreso { get; set; }
            public Int32 proveedor { get; set; }

            public Existencia() { }                   //CONSTRUCTOR VACIO

            public Existencia(string codigo, Int32 cantidad, Int32 producto, Int32 bodega, string ingreso, Int32 proveedor, Int32 marca)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.cantidad = cantidad;
                this.producto = producto;
                this.bodega = bodega;
                this.ingreso = ingreso;
                this.marca = marca;
            }
        } //class existencia

        public class Abono
        {
            public string id_abono { get; set; }       //ATRIBUTOS DEL OBJETO PERSONA
            public string id_factura { get; set; }
            //public string serie { get; set; }
            public string id_cliente { get; set; }
            public double saldo_factura { get; set; }
            public string forma_pago { get; set; }
            public double abono { get; set; }
            public string fecha { get; set; }

            public Abono() { }                   //CONSTRUCTOR VACIO

            public Abono(string id_abono, string id_factura, string id_cliente, double saldo_factura, string forma_pago, double abono, string fecha)      //CONSTRUCTOR CON PARAMETROS
            {
                this.id_abono = id_abono;
                this.id_factura = id_factura;
                //this.serie = serie;
                this.id_cliente = id_cliente;
                this.saldo_factura = saldo_factura;
                this.forma_pago = forma_pago;
                this.abono = abono;
                this.fecha = fecha;
            }
        } //class abono

        public class Cliente
        {
            public string nombres { get; set; }
            public DateTime fecha { get; set; }
            public string incidencia { get; set; }
            public string apellidos { get; set; }

            public Cliente() { }
            public Cliente(string nombres, string apellidos, string incidencias, DateTime fecha)
            {
                this.nombres = nombres;
                this.apellidos = apellidos;
                this.incidencia = incidencia;
                this.fecha = fecha;
            }
        }
        public class factura
        {
            public int id_factura { get; set; }
            public string nombre_cliente { get; set; }
            public string saldo_factura { get; set; }
            public string forma_pago { get; set; }
            public int id_cliente { get; set; }
            public factura() { }

            public factura(int id_factura, string nombre_cliente, string saldo_factura, string forma_pago, int id_cliente)
            {
                this.id_factura = id_factura;
                this.nombre_cliente = nombre_cliente;
                this.saldo_factura = saldo_factura;
                this.forma_pago = forma_pago;
                this.id_cliente = id_cliente;
            }
        }

        public class Proveedor
        {
            public string nombre { get; set; }
            public string nit { get; set; }
            public string direccion { get; set; }
            public string telefono { get; set; }
           

            public Proveedor() { }
            public Proveedor(string nombre, string nit, string direccion, string telefono)
            {
                this.nombre = nombre;
                this.nit = nit;
                this.direccion = direccion;
                this.telefono = telefono;
            }
        }

        public class Compra
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PRODUCTO
            public Int32 producto { get; set; }
            public Int32 proveedor { get; set; }
            public Int32 marca { get; set; }
            public Int32 cantidad { get; set; }
            public String fecha { get; set; }
            

            public Compra() { }                   //CONSTRUCTOR VACIO

            public Compra(string codigo, Int32 producto, Int32 marca,Int32 proveedor, Int32 cantidad, String fecha)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.producto = producto;
                this.marca = marca;
                this.proveedor = proveedor;
                this.cantidad = cantidad;
                this.fecha = fecha;
            }
        } //class producto

        public class Tprecio
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PRODUCTO
            public String tipo { get; set; }
           

            public Tprecio() { }                   //CONSTRUCTOR VACIO

            public Tprecio(string codigo, string tipo)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.tipo = tipo;
            }
        } //class producto

        public class Orden
        {
            public string codigo { get; set; }       //ATRIBUTOS DEL OBJETO PRODUCTO
            public Int32 producto { get; set; }
            public Int32 marca { get; set; }
            public Int32 proveedor { get; set; }
            public Int32 cantidad { get; set; }
            public string fecha { get; set; }

            public Orden() { }                   //CONSTRUCTOR VACIO

            public Orden(string codigo, Int32 producto, Int32 marca, Int32 proveedor, Int32 cantidad, string fecha)      //CONSTRUCTOR CON PARAMETROS
            {
                this.codigo = codigo;
                this.producto = producto;
                this.marca = marca;
                this.proveedor = proveedor;
                this.cantidad = cantidad;
                this.fecha = fecha;
            }
        } //class producto

      

    }
}
