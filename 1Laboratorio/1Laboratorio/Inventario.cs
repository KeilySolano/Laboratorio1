using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Inventario
    {
        static StreamReader Leer;
        static StreamWriter Escribir;

        public void GProducto()
        {
            StreamWriter inventario = File.AppendText("Inventario.txt");
            int cantidad;
            Console.WriteLine("Ingrese la cantidad");
            cantidad = int.Parse(Console.ReadLine());
            inventario.WriteLine(cantidad);
            int precio;
            Console.WriteLine("Ingrese el precio");
            precio = int.Parse(Console.ReadLine());
            inventario.WriteLine(precio);
            string producto;
            Console.WriteLine("Ingrese producto");
            producto = Console.ReadLine();
            inventario.WriteLine(producto);
            int total=cantidad*precio;
            Console.WriteLine("El total es:"+total);
            inventario.WriteLine(total);
            inventario.Close();
            
        }
        
    }
}
