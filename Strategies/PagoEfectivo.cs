namespace CleanCodeVentas.Strategies;

public sealed class PagoEfectivo : IMetodoPago
{
    public string Nombre => "Efectivo";

    public string Procesar(decimal monto)
    {
        return $"Pago de {monto:C} recibido en efectivo.";
    }
}
