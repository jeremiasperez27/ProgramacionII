using Actividad1._5.Entidades;
using Actividad1._5.Servicios;

FacturacionManager serviceManager = new FacturacionManager();

//Mostrar las formas de pago.
Console.WriteLine("Formas de pago disponibles:");
var formasPago = serviceManager.GetAllFormasPago(); 

foreach (var forma in formasPago)
{
    Console.WriteLine($"ID: {forma.Id}, Nombre: {forma.Nombre}");
}

//Mostrar articulos disponibles en el comercio
Console.WriteLine("Articulos Disponibles:");
var articulos = serviceManager.GetAllArticulos();

foreach (var articulo in articulos)
{
    Console.WriteLine($"ID: {articulo.Id}, Nombre: {articulo.Nombre}, Precio: {articulo.PrecioUnitario}");
}

