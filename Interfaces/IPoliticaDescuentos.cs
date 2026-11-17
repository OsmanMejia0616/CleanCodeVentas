using CleanCodeVentas.Models;

namespace CleanCodeVentas.Interfaces;

public interface IPoliticaDescuentos
{
    decimal ObtenerPorcentaje(CategoriaProducto categoria);
}
