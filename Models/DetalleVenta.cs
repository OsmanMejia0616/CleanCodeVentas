namespace CleanCodeVentas.Models;

public sealed record DetalleVenta(Producto Producto, int Cantidad)
{
    public decimal Importe => Producto.Precio * Cantidad;
}
