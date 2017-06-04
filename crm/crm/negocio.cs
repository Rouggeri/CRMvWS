using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    class negocio : entidades
    {
        public void InsertarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.nombre) || string.IsNullOrWhiteSpace(producto.descripcion) || string.IsNullOrWhiteSpace(Convert.ToString(producto.marca)) || string.IsNullOrWhiteSpace(Convert.ToString(producto.precio)) || string.IsNullOrWhiteSpace(Convert.ToString(producto.categoria)) || string.IsNullOrWhiteSpace(Convert.ToString(producto.porcentaje)))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarproducto(producto.nombre, producto.descripcion, producto.marca, producto.precio, producto.categoria, producto.porcentaje);      //se llama la funcion de DinsertarPersona con los datos del objeto persona
            }
        }

        public void EliminarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.codigo))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarproducto(producto.codigo);
            }

        }

        public void EliminarBodega(Int32 idb)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idb)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarbodega(Convert.ToString(idb));
            }

        }

        public void EliminarCompra(Int32 idc)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idc)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarcompra(Convert.ToString(idc));
            }

        }

        public void EliminarMarca(Int32 idm)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idm)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarmarca(Convert.ToString(idm));
            }

        }

        public void EliminarCategoria(Int32 idcat)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idcat)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarcategoria(Convert.ToString(idcat));
            }

        }

        public void EliminarCatalogo(Int32 idca)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idca)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarcatalogo(Convert.ToString(idca));
            }

        }

        public void EliminarProveedor(Int32 idca)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(idca)))
            {
                MessageBox.Show("No ha seleccionado la fila a eliminar");
            }
            else
            {
                MessageBox.Show("seleccionada fila para eliminar");
                datos edatos = new datos();     //Se crea un objeto de capa de datos
                edatos.eliminarproveedor(Convert.ToString(idca));
            }

        }

        public void InsertarBodega(Bodega bodega)
        {
            if (string.IsNullOrWhiteSpace(bodega.nombre) || string.IsNullOrWhiteSpace(bodega.direccion))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarbodega(bodega.nombre, bodega.direccion);
            }
        }

        public void InsertarProveedor(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.nombre) || string.IsNullOrWhiteSpace(proveedor.nit) || string.IsNullOrWhiteSpace(proveedor.direccion) || string.IsNullOrWhiteSpace(proveedor.telefono))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarproveedor(proveedor.nombre, proveedor.nit, proveedor.direccion, proveedor.telefono);
            }
        }

        public void InsertarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.nombre))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarcategoria(categoria.nombre);
            }
        }

        public void InsertarExistencia(Existencia existencia)
        {
            if (String.IsNullOrWhiteSpace(Convert.ToString(existencia.cantidad)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.producto)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.bodega)) || string.IsNullOrWhiteSpace(existencia.ingreso) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.proveedor)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.marca)))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarexistencia(Convert.ToInt32(existencia.codigo), existencia.cantidad, existencia.producto, existencia.bodega, existencia.ingreso, existencia.proveedor, existencia.marca);
                
            }

        }

        public void InsertarExistenciaBod(Existencia existencia)
        {
            if (String.IsNullOrWhiteSpace(Convert.ToString(existencia.cantidad)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.producto)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.bodega)) || string.IsNullOrWhiteSpace(Convert.ToString(existencia.marca)))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarexistenciabod(existencia.cantidad, existencia.producto, existencia.bodega, existencia.marca);
               
            }

        }

        public void InsertarMarca(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.nombre) || string.IsNullOrWhiteSpace(Convert.ToString(marca.porcentaje)))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarmarca(marca.nombre, marca.porcentaje);
            }
        }

        public void InsertarCompra(Compra compra)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(compra.producto)) || string.IsNullOrWhiteSpace(Convert.ToString(compra.marca)) || string.IsNullOrWhiteSpace(Convert.ToString(compra.proveedor)) || string.IsNullOrWhiteSpace(Convert.ToString(compra.cantidad)) || string.IsNullOrWhiteSpace(compra.fecha))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarcompra(compra.producto, compra.marca, compra.proveedor, compra.cantidad, compra.fecha);
            }
        }

        public void InsertarCatalogo(Tprecio catalogo)
        {
            if (string.IsNullOrWhiteSpace(catalogo.tipo))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarcatalogo(catalogo.tipo);
            }
        }

        public System.Data.DataTable consultar()
        {
            return datos.ObtenerRegistros();        //se llama la funcion ObtenerRegistros
        }

        public System.Data.DataTable consultaprod()
        {
            return datos.ObtenerProductos();        //se llama la funcion ObtenerRegistros
        }

        public System.Data.DataTable consultarbod()
        {
            return datos.ObtenerBod();
        }

        public System.Data.DataTable consultacat()
        {
            return datos.ObtenerCat();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultaex()
        {
            return datos.ObtenerExistencia();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultaprecio()
        {
            return datos.ObtenerPrecio();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultaprov()
        {
            return datos.ObtenerProveedor();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultamarca()
        {
            return datos.ObtenerMarca();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultacomp()
        {
            return datos.ObtenerCompra();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultacatalogo()
        {
            return datos.ObtenerCatalogo();              //se llama la funcion ObtenerCat
        }

        public System.Data.DataTable consultaexistenciabod()
        {
            return datos.ObtenerExistenciaBod();              //se llama la funcion ObtenerCat
        }


        public void InsertarAbono(Abono abono)
        {
            if (string.IsNullOrWhiteSpace(abono.id_factura) || string.IsNullOrWhiteSpace(abono.id_cliente) || string.IsNullOrWhiteSpace(Convert.ToString(abono.forma_pago)) || string.IsNullOrWhiteSpace(Convert.ToString(abono.abono)) || string.IsNullOrWhiteSpace(Convert.ToString(abono.fecha)))
            {
                MessageBox.Show("Hay campos que estan vacios");     //si hace falta algun campo no se realiza la transaccion
            }
            else
            {
                datos cdatos = new datos();     //Se crea un objeto de capa de datos
                cdatos.insertarabono(abono.id_factura, abono.id_cliente, abono.forma_pago, abono.abono, abono.fecha);      //se llama la funcion de DinsertarPersona con los datos del objeto persona
            }
        }
        public void InsertarIncidencia(Cliente cliente)
        {
            datos idatos = new datos(); //Se crea un objeto de capa de datos
                                        //idatos.insertarabono
        }

        public System.Data.DataTable consultar2()
        {
            return datos.ObtenerRegistros2();        //se llama la funcion ObtenerRegistros
        }

        

        /*public System.Data.DataTable consultac()
        {
            //return datos.ObtenerClientes();         //se llama la funcion ObtenerClientes
        }*/

    }
}
