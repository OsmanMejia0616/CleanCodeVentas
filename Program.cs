using CleanCodeVentas.Models;
using CleanCodeVentas.Services;
using CleanCodeVentas.Strategies;

var productos = new List<Producto>
{
    new(new ProductoId(1), "Teclado mecánico", CategoriaProducto.Tecnologia, 850m, 8),
    new(new ProductoId(2), "Silla ergonómica", CategoriaProducto.Muebles, 3200m, 3),
    new(new ProductoId(3), "Cuaderno", CategoriaProducto.Papeleria, 45m, 25),
    new(new ProductoId(4), "Audífonos", CategoriaProducto.Tecnologia, 620m, 0)
};

var descuentos = new PoliticaDescuentos();
var calculadora = new CalculadoraVentas(descuentos);
var clasificador = new ClasificadorProductos();
var validador = new ValidadorVenta();

Console.WriteLine("=== CLEAN CODE VENTAS ===");
Console.WriteLine("\nInventario:");
foreach (var producto in productos)
{
    Console.WriteLine(
        $"{producto.Nombre,-22} | Precio: {producto.Precio:C} | " +
        $"Stock: {producto.Existencia} | Estado: {producto.EstadoInventario}");
}

Console.WriteLine("\nDescuentos por categoría:");
foreach (var producto in productos)
{
    var porcentaje = descuentos.ObtenerPorcentaje(producto.Categoria);
    Console.WriteLine($"{producto.Nombre}: {porcentaje:P0}");
}

var carrito = new List<DetalleVenta>
{
    new(productos[0], 2),
    new(productos[2], 4)
};

var detallesValidos = carrito.Where(validador.PuedeVender).ToList();
Console.WriteLine($"Detalles de venta válidos: {detallesValidos.Count} de {carrito.Count}");

var subtotal = calculadora.CalcularSubtotal(detallesValidos);
var descuentoTotal = calculadora.CalcularDescuento(detallesValidos);
var total = calculadora.CalcularTotal(detallesValidos);

Console.WriteLine("\nResumen de venta:");
Console.WriteLine($"Subtotal: {subtotal:C}");
Console.WriteLine($"Descuento: {descuentoTotal:C}");
Console.WriteLine($"Total con impuesto: {total:C}");

Console.WriteLine("\nClasificación del inventario:");
var disponibles = clasificador.ObtenerDisponibles(productos);
Console.WriteLine($"Productos disponibles: {disponibles.Count}");

Console.WriteLine("\nMétodos de pago:");
var metodosPago = new List<IMetodoPago>
{
    new PagoEfectivo(),
    new PagoTarjeta(),
    new PagoTransferencia()
};

foreach (var metodo in metodosPago)
{
    Console.WriteLine($"{metodo.Nombre}: {metodo.Procesar(total)}");
}

Console.WriteLine("\nDemostración terminada.");
