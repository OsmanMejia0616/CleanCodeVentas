namespace CleanCodeVentas.Models;

public enum CategoriaProducto
{
    Tecnologia,
    Muebles,
    Papeleria
}

// Tipado fuerte: un identificador de producto no se confunde
// accidentalmente con cualquier otro número entero.
public readonly record struct ProductoId(int Valor);

public sealed class Producto
{
    public ProductoId Id { get; }
    public string Nombre { get; }
    public CategoriaProducto Categoria { get; }
    public decimal Precio { get; }
    public int Existencia { get; }

    // Operador ternario: devuelve una etiqueta según una condición sencilla.
    public string EstadoInventario => Existencia > 0 ? "Disponible" : "Agotado";
    public bool EstaDisponible => Existencia > 0;

    public Producto(
        ProductoId id,
        string nombre,
        CategoriaProducto categoria,
        decimal precio,
        int existencia)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
        if (precio < 0)
            throw new ArgumentOutOfRangeException(nameof(precio));
        if (existencia < 0)
            throw new ArgumentOutOfRangeException(nameof(existencia));

        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Existencia = existencia;
    }
}
