namespace CleanCodeVentas.Strategies;

public sealed class PagoTransferencia : IMetodoPago
{
    public string Nombre => "Transferencia";

    public string Procesar(decimal monto)
    {
        return $"Transferencia por {monto:C} registrada.";
    }
}
