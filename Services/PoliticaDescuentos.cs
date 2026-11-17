using CleanCodeVentas.Models;
using CleanCodeVentas.Interfaces;

namespace CleanCodeVentas.Services;

public sealed class PoliticaDescuentos : IPoliticaDescuentos
{
    // Método de tabla: las reglas se consultan en una estructura de datos,
    // en lugar de mantener una cadena extensa de if/else.
    private readonly Dictionary<CategoriaProducto, decimal> _descuentos =
        new()
        {
            [CategoriaProducto.Tecnologia] = 0.10m,
            [CategoriaProducto.Muebles] = 0.15m,
            [CategoriaProducto.Papeleria] = 0.05m
        };

    public decimal ObtenerPorcentaje(CategoriaProducto categoria)
    {
        return _descuentos.TryGetValue(categoria, out var porcentaje)
            ? porcentaje
            : 0m;
    }
}
