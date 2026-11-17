# CleanCodeVentas – Demostración de Clean Code en C#

## Objetivo
Demostrar siete técnicas de Clean Code mediante ejemplos pequeños de un sistema de ventas e inventario. El proyecto está desarrollado en C# y .NET 8.

## Requisitos
- .NET 8 SDK
- Visual Studio 2022, Visual Studio Code o terminal

## Cómo ejecutar
Desde la carpeta que contiene `CleanCodeVentas.csproj`:

```bash
dotnet restore
dotnet run
```

## Conceptos demostrados

### 1. Elegancia del operador ternario
**Antes (código sucio o innecesariamente extenso):**
```csharp
string estado;
if (existencia > 0)
{
    estado = "Disponible";
}
else
{
    estado = "Agotado";
}
```
**Después:**
```csharp
public string EstadoInventario =>
    Existencia > 0 ? "Disponible" : "Agotado";
```
El operador ternario permite expresar una asignación basada en una condición sencilla en una sola expresión legible. No debe utilizarse si las ramas contienen lógica extensa o dificultan la lectura.

### 2. Tipado fuerte
**Antes:**
```csharp
object id = "101";
object precio = "850.00";
```
Los valores no expresan claramente su propósito y requieren conversiones.
**Después:**
```csharp
public readonly record struct ProductoId(int Valor);
public decimal Precio { get; }
```
`ProductoId` representa específicamente un identificador y `decimal` es apropiado para importes monetarios. El compilador ayuda a detectar mezclas de tipos incorrectas.

### 3. Números mágicos
**Antes:**
```csharp
var total = subtotal * 1.15m;
```
El `1.15` no explica por qué se multiplica.
**Después:**
```csharp
private const decimal TasaImpuesto = 0.15m;
var total = subtotalConDescuento * (1 + TasaImpuesto);
```
El nombre comunica la regla y facilita cambiarla. En un sistema real, la tasa debe venir de la configuración o de la normativa aplicable.

### 4. Complejidad condicional
**Antes (condicionales anidados):**
```csharp
if (cantidad > 0)
{
    if (cantidad <= producto.Existencia)
    {
        // Se permite agregar el detalle a la venta.
    }
}
```
Al crecer la lógica, los bloques anidados dificultan seguir el flujo.
**Después (condición con intención explícita):**
```csharp
public bool PuedeVender(DetalleVenta detalle)
{
    return detalle.Cantidad > 0 &&
           detalle.Cantidad <= detalle.Producto.Existencia;
}
```
La regla queda aislada en `ValidadorVenta` y se expresa directamente. La complejidad se reduce al evitar anidamientos y dar un nombre a la validación.

### 5. Polimorfismo vs Enum
**Antes (Enum + condicionales):**
```csharp
switch (metodoPago)
{
    case MetodoPago.Efectivo: return ProcesarEfectivo(monto);
    case MetodoPago.Tarjeta: return ProcesarTarjeta(monto);
    case MetodoPago.Transferencia: return ProcesarTransferencia(monto);
    default: throw new ArgumentOutOfRangeException();
}
```
Cada nuevo medio de pago obliga a modificar el `switch`.
**Después (polimorfismo):**
```csharp
public interface IMetodoPago
{
    string Nombre { get; }
    string Procesar(decimal monto);
}
```
Cada clase implementa su propio comportamiento. El programa trabaja con la interfaz y no necesita conocer los detalles internos de cada método de pago. Un enum sigue siendo adecuado cuando solo se necesita representar un conjunto fijo de valores sin comportamientos distintos.

### 6. Ser declarativo
**Antes:**
```csharp
var disponibles = new List<Producto>();
foreach (var producto in productos)
{
    if (producto.Existencia > 0)
        disponibles.Add(producto);
}
```
Se describe paso a paso cómo construir la lista.
**Después:**
```csharp
return productos
    .Where(producto => producto.EstaDisponible)
    .OrderBy(producto => producto.Nombre)
    .ToList();
```
LINQ expresa qué elementos se necesitan y en qué orden.

### 7. Método de tabla
**Antes:**
```csharp
if (categoria == CategoriaProducto.Tecnologia) return 0.10m;
if (categoria == CategoriaProducto.Muebles) return 0.15m;
if (categoria == CategoriaProducto.Papeleria) return 0.05m;
return 0m;
```
**Después:**
```csharp
private readonly Dictionary<CategoriaProducto, decimal> _descuentos =
    new()
    {
        [CategoriaProducto.Tecnologia] = 0.10m,
        [CategoriaProducto.Muebles] = 0.15m,
        [CategoriaProducto.Papeleria] = 0.05m
    };
```
Las reglas se almacenan como datos y se consultan mediante la categoría. Agregar o modificar un porcentaje no exige ampliar una cadena de condicionales.

## Archivos importantes
- `Models/Producto.cs`: entidad y tipado fuerte.
- `Services/CalculadoraVentas.cs`: cálculos y constante de impuesto.
- `Services/PoliticaDescuentos.cs`: método de tabla.
- `Services/ClasificadorProductos.cs`: LINQ y enfoque declarativo.\n- `Services/ValidadorVenta.cs`: simplificación de condiciones.
- `Strategies/`: polimorfismo mediante una interfaz y diferentes clases.
- `Program.cs`: ejecución de la demostración.

## Nota para la defensa
El código “antes” del README es ilustrativo y se presenta para comparar. La aplicación ejecutable contiene la versión refactorizada. No se debe afirmar que toda alternativa es siempre mejor: cada técnica se aplica cuando mejora la claridad, el mantenimiento o la extensibilidad.

## Pruebas unitarias y DIP

El proyecto incluye una interfaz `IPoliticaDescuentos` para que `CalculadoraVentas` dependa de una abstracción y no de una clase concreta. También incluye dos pruebas xUnit en `Tests/`.

Para ejecutarlas:

```bash
dotnet test Tests/CleanCodeVentas.Tests.csproj
```

Consulta `GUIA_PRUEBAS_Y_GIT.md` para conocer las pruebas, AAA y los comandos Git de la demostración.
