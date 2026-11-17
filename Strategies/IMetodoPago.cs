namespace CleanCodeVentas.Strategies;

public interface IMetodoPago
{
    string Nombre { get; }
    string Procesar(decimal monto);
}
