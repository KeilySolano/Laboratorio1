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

       
        static void Modificar()
        {
            string linea = "", CantTemp = "";
            Console.Write("ingrese nombre del producto que desea agregar:");
            string producto = Console.ReadLine();
            Console.WriteLine("Cantidad");
            double cantidad = double.Parse(Console.ReadLine());
            Console.Write("Precio o nuevo precio:");
            double precio = double.Parse(Console.ReadLine());
            using (Escribir=new StreamWriter("InventarioTemp.txt"))
            {
                using (Leer = new StreamReader("Inventario.txt"))
                {
                    while ((linea=Leer.ReadLine())!=null)
                    {
                        string[] datos = linea.Split('*');
                        if (datos[0] != producto)
                        {
                            Escribir.WriteLine(linea);
                        }
                        else
                        {
                            CantTemp = datos[1];
                            cantidad += double.Parse(CantTemp);
                        }
                    }
                }
            }
            File.Delete("Invenatario.txt");
            File.Move("InventarioTemp.txt","Inventario.txt");
            Leer.Close();
            Escribir.Close();
            Escribir=File.AppendText("Inventario.txt");
            Escribir.WriteLine(producto+"*"+cantidad+"*"+precio);
            Escribir.Close();                    
        }


    }
}

