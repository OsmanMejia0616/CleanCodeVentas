using CleanCodeVentas.Models;

namespace CleanCodeVentas.Services;

public sealed class ValidadorVenta
{
    // Una condición con nombre expresa la regla de negocio de forma directa.
    public bool PuedeVender(DetalleVenta detalle)
    {
        return detalle.Cantidad > 0 &&
               detalle.Cantidad <= detalle.Producto.Existencia;
    }
}
