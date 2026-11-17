# Guion para el video de defensa – CleanCodeVentas
Duración sugerida: 7 a 9 minutos.

## 0:00–0:40 | Introducción
“Hola, en este video voy a presentar CleanCodeVentas, una aplicación de consola desarrollada en C# con .NET 8. El objetivo no es crear un sistema comercial complejo, sino demostrar siete técnicas de Clean Code. En cada caso explicaré cómo se veía el código antes, qué cambio apliqué y qué beneficio aporta.”

## 0:40–1:15 | Estructura
“Separé el proyecto en Models, Services y Strategies. Models contiene las entidades y tipos del dominio; Services contiene las reglas y cálculos; Strategies contiene las implementaciones de los métodos de pago. Esta separación evita concentrar toda la lógica en Program.cs y hace más fácil localizar responsabilidades.”

## 1:15–2:00 | Operador ternario
“Primero, la elegancia del operador ternario. En la versión extensa necesitaba un if y un else para asignar verdadero o falso según la existencia. En Producto utilizo una expresión corta para devolver la etiqueta Disponible o Agotado. Es importante aclarar que el ternario no debe usarse por obligación: si la condición o las ramas son complejas, un if tradicional puede ser más legible.”

## 2:00–2:45 | Tipado fuerte
“Segundo, tipado fuerte. En código menos seguro podríamos guardar el identificador o el precio como object o string, y después necesitar conversiones. En la versión limpia uso ProductoId como tipo específico y decimal para el precio. Esto comunica la intención y permite que el compilador detecte errores antes de ejecutar el programa. Para dinero uso decimal y no double por su representación decimal más apropiada para cálculos monetarios.”

## 2:45–3:25 | Números mágicos
“Tercero, números mágicos. Un valor como 1.15 no explica por sí mismo qué representa. Lo reemplacé por una constante llamada TasaImpuesto. El código ahora comunica la regla de negocio y si cambia la tasa, sé exactamente dónde modificarla. En un sistema real esta tasa podría venir de configuración o de una fuente normativa.”

## 3:25–4:10 | Complejidad condicional
“Cuarto, complejidad condicional. En la versión inicial había condiciones anidadas para validar la cantidad solicitada y comprobar el inventario. En ValidadorVenta encapsulé esa regla en PuedeVender y utilicé una condición compuesta clara. Así evito niveles de anidamiento y el nombre del método comunica qué se está comprobando.”

## 4:10–5:10 | Polimorfismo vs Enum
“Quinto, polimorfismo frente a enum. Una solución inicial puede usar un enum y un switch para decidir qué hacer con efectivo, tarjeta o transferencia. El problema aparece cuando cada método tiene lógica propia y hay que seguir ampliando el switch. En esta versión definí la interfaz IMetodoPago y tres implementaciones. Todas exponen Procesar, pero cada clase resuelve el comportamiento a su manera. El programa recorre una lista de la interfaz y no necesita un switch. Un enum no es incorrecto: es útil para valores fijos que no tienen comportamiento propio.”

## 5:10–5:55 | Ser declarativo
“Sexto, programación declarativa. En lugar de crear una lista vacía, recorrer todos los productos y agregar manualmente los disponibles, utilizo LINQ con Where y OrderBy. La instrucción expresa qué datos necesito y el orden, no cada paso para construir el resultado.”

## 5:55–6:40 | Método de tabla
“Séptimo, método de tabla. Los porcentajes de descuento por categoría estaban representados por varios condicionales. Los centralicé en un diccionario. La categoría funciona como clave y el porcentaje como valor. Esto facilita consultar y actualizar las reglas sin agregar más ramas condicionales.”

## 6:40–7:40 | Ejecución y cierre
“Ahora ejecuto la aplicación. Se muestran los productos, su disponibilidad, los descuentos por categoría, el resumen de una venta y la respuesta de cada método de pago. Con esto compruebo que las piezas refactorizadas trabajan juntas. Como conclusión, Clean Code no significa escribir menos líneas a cualquier costo; significa escribir código cuya intención sea clara, que tenga responsabilidades bien definidas y que sea sencillo de modificar y probar. Gracias.”

## Recomendaciones para grabar
1. Abre el proyecto en Visual Studio o VS Code.
2. Muestra primero la estructura de carpetas.
3. Abre cada archivo y señala el fragmento correspondiente.
4. Para cada tema, muestra el ejemplo “Antes” de este README y después el archivo refactorizado.
5. Ejecuta `dotnet run` y muestra la salida.
6. Mantén el video entre 5 y 10 minutos.
7. Sube el video a YouTube con visibilidad **Oculto** y copia el enlace para adjuntarlo a la entrega.
