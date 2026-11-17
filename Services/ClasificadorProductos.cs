using CleanCodeVentas.Models;

namespace CleanCodeVentas.Services;

public sealed class ClasificadorProductos
{
    // Código declarativo con LINQ: expresa qué resultado se necesita.
    public List<Producto> ObtenerDisponibles(IEnumerable<Producto> productos)
    {
        return productos
            .Where(producto => producto.EstaDisponible)
            .OrderBy(producto => producto.Nombre)
            .ToList();
    }
}
