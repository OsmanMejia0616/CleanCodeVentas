using CleanCodeVentas.Models;
using CleanCodeVentas.Services;
using Xunit;

namespace CleanCodeVentas.Tests;

public class VentasTests
{
    [Fact]
    public void CalcularTotal_AplicaDescuentoEImpuesto()
    {
        // Arrange: producto de tecnología con precio de L100 y descuento del 10%.
        var producto = new Producto(
            new ProductoId(1), "Teclado", CategoriaProducto.Tecnologia, 100m, 5);
        var detalles = new List<DetalleVenta> { new(producto, 2) };
        var calculadora = new CalculadoraVentas(new PoliticaDescuentos());

        // Act: calcula el total de dos unidades.
        var resultado = calculadora.CalcularTotal(detalles);

        // Assert: (L200 - L20 de descuento) + 15% de impuesto = L207.
        Assert.Equal(207m, resultado);
    }

    [Fact]
    public void PuedeVender_CantidadMayorAlStock_RetornaFalso()
    {
        // Arrange: solo hay dos unidades disponibles.
        var producto = new Producto(
            new ProductoId(2), "Mouse", CategoriaProducto.Tecnologia, 250m, 2);
        var detalle = new DetalleVenta(producto, 3);
        var validador = new ValidadorVenta();

        // Act
        var resultado = validador.PuedeVender(detalle);

        // Assert
        Assert.False(resultado);
    }
}
