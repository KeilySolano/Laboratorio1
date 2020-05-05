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


        public void Modificar()
        {
            string linea = "contacto";
            Leer = File.OpenText("Inventario.txt");
            linea = Leer.ReadLine();
            while (linea != null)
            {
                Console.WriteLine("Ingrese el producto");
                string produc = Console.ReadLine();
                string[] Vec = linea.Split('*');
                if (Vec[1] == produc)
                {
                    int cantidad;
                    int precio;
                    string producto;
                    string can = "Cantida:";
                    string pre = "Precio";
                    string pro = "El Producto es:";
                    string to = "El total es:";

                    Console.WriteLine("Ingrese el producto");
                    producto = Console.ReadLine();
                    Console.WriteLine("Ingrese la cantidad");
                    cantidad = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el precio");
                    precio = int.Parse(Console.ReadLine());
                    int total = cantidad * precio;
                    Console.WriteLine("El total es:" + total);
                    Escribir.WriteLine(pro + "*" + producto + "*" + can + cantidad + "*" + pre + precio + "*" + to + total);
                    Escribir.Close();


                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
        }   
    }
}


