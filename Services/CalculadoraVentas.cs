using CleanCodeVentas.Models;
using CleanCodeVentas.Interfaces;

namespace CleanCodeVentas.Services;

public sealed class CalculadoraVentas
{
    // Números mágicos eliminados: los valores tienen nombre y significado.
    private const decimal TasaImpuesto = 0.15m;

    private readonly IPoliticaDescuentos _politicaDescuentos;

    public CalculadoraVentas(IPoliticaDescuentos politicaDescuentos)
    {
        _politicaDescuentos = politicaDescuentos;
    }

    public decimal CalcularSubtotal(IEnumerable<DetalleVenta> detalles)
    {
        return detalles.Sum(detalle => detalle.Importe);
    }

    public decimal CalcularDescuento(IEnumerable<DetalleVenta> detalles)
    {
        return detalles.Sum(detalle =>
            detalle.Importe *
            _politicaDescuentos.ObtenerPorcentaje(detalle.Producto.Categoria));
    }

    public decimal CalcularTotal(IEnumerable<DetalleVenta> detalles)
    {
        var subtotal = CalcularSubtotal(detalles);
        var descuento = CalcularDescuento(detalles);
        var subtotalConDescuento = subtotal - descuento;

        return subtotalConDescuento * (1 + TasaImpuesto);
    }
}
