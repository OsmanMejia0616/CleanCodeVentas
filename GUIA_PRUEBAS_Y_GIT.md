# Guía mínima para la defensa: pruebas y Git

## Ejecutar la aplicación
Desde la carpeta que contiene `CleanCodeVentas.csproj`:

```bash
dotnet run
```

## Ejecutar las pruebas
Desde esa misma carpeta:

```bash
dotnet test Tests/CleanCodeVentas.Tests.csproj
```

Las pruebas usan xUnit y siguen AAA:
- Arrange: preparar los objetos y datos.
- Act: ejecutar el método que se quiere comprobar.
- Assert: verificar el resultado esperado.

Pruebas incluidas:
1. Un total de L207 para dos productos de L100, con 10% de descuento y 15% de impuesto.
2. Rechazar una venta de tres unidades cuando solo existen dos en inventario.

## DIP demostrado
`CalculadoraVentas` ahora depende de `IPoliticaDescuentos`, no de la clase concreta `PoliticaDescuentos`. Esto permite sustituir la implementación sin modificar la calculadora.

## Flujo Git para mostrar en el video
Ejecutar desde la carpeta raíz del proyecto (si Git aún no está inicializado):

```bash
git init
git add .
git commit -m "chore: guardar versión inicial del proyecto"
git switch -c feature/pruebas-unitarias
git add .
git commit -m "test: agregar pruebas de cálculo y validación"
git switch -c feature/inversion-dependencias
git add .
git commit -m "refactor: depender de interfaz para descuentos"
```

Para la defensa, mostrar `git log --oneline --graph --all` y `git branch`.

Nota: crear ramas y commits localmente demuestra el uso básico de Git, pero un Pull Request real requiere publicar el repositorio en GitHub y abrir allí la solicitud de revisión.
