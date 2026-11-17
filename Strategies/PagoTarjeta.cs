namespace CleanCodeVentas.Strategies;

public sealed class PagoTarjeta : IMetodoPago
{
    private const decimal Comision = 0.025m;

    public string Nombre => "Tarjeta";

    public string Procesar(decimal monto)
    {
        var totalConComision = monto * (1 + Comision);
        return $"Pago de {totalConComision:C} procesado con tarjeta.";
    }
}
