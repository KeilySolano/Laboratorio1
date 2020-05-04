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
            string can = "Cantida:";
            string pre = "Precio";
            string pro = "El producto es:";
            string to = "El total es:";
            string linea = "", CantTemp = "";
            Console.Write(pro);
            string producto = Console.ReadLine();
            Console.WriteLine(can);
            double cantidad = double.Parse(Console.ReadLine());
            Console.Write(pre);
            double precio = double.Parse(Console.ReadLine());
            Console.WriteLine(to);
            double total = cantidad * precio;

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

            File.Move("InventarioTemp.txt","InventarioNuevo.txt");
            Leer.Close();
            Escribir.Close();
            Escribir=File.AppendText("Inventario.txt");
            Escribir.WriteLine(pro+producto+"*"+can+cantidad+"*"+pre+precio+"*"+to+total);
            Escribir.Close();                    
        }
    }
}

