using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Inventario
    {
        static string inventario = "Inventario.txt";
        static StreamReader Leer;

        public void GProducto()
        {

            StreamWriter inventario = File.AppendText("Inventario.txt");
            int cantidad;
            int precio;
            string producto;
            string can = "Cantida:";
            string pre = "Precio";
            string pro = "El producto es:";
            string to = "El total es:";

            Console.WriteLine("Ingrese el producto");
            producto = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad");
            cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el precio");
            precio = int.Parse(Console.ReadLine());
            int total = cantidad * precio;
            Console.WriteLine("El total es:" + total);
            inventario.WriteLine(pro + "*" + producto + "*" + can + cantidad + "*" + pre + precio + "*" + to + total);
            inventario.Close();
        }
        public void MostrarProducto()
        {
            StreamReader Leer;
            Leer = new StreamReader("Inventario.txt");
            Console.WriteLine(Leer.ReadToEnd());
            Leer.Close();
        }

        static string Llenar(string dato)
        {
            Console.Write("Ingrese" + dato + ":");
            return (Console.ReadLine());
        }
        static string BContacto(string produc)
        {
            string linea = "contacto";
            Leer = File.OpenText(inventario);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] Vec = linea.Split('*');
                if (Vec[1] == produc)
                {
                    Console.WriteLine("Producto encontrado:" + Vec[0] + "-" + Vec[1] + "-" + Vec[2] + "-");
                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            return linea;
        }


    }
}
