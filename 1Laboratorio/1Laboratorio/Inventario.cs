using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Inventario
    {
        static StreamReader Leer;
        static StreamWriter escribir;
        static Trabajador Traba = new Trabajador();
        static string inventariotemp = "InventarioTemp.txt";

        public void GProducto()
        {

            
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
            string linea = "",Producto = "",CanTemp="";
            double cantidad, precio;
            char res = 's';
            do
            {
                Console.Write("Ingrese el producto");
                Producto = Console.ReadLine();
                Console.Write("Ingrese cantidad:");
                cantidad = double.Parse(Console.ReadLine());
                Console.Write("Ingrese precio:");
                precio = double.Parse(Console.ReadLine());
                using (escribir = new StreamWriter(inventariotemp))
                {
                    using (Leer = new StreamReader("Inventario.txt"))
                    {
                        while ((linea = Leer.ReadLine()) != null)
                        {
                            string[] datos = linea.Split('*');
                            if (datos[0] != Producto)
                            {
                                escribir.WriteLine(linea);
                            }
                            else
                            {
                                CanTemp = datos[1];
                                cantidad += double.Parse(CanTemp);
                            }
                        }
                    }
                }
                File.Delete("Inventario.txt");
                File.Move(inventariotemp, "Inventario.txt");
                Leer.Close();
                escribir.Close();
                escribir = File.AppendText("Inventario.txt");
                escribir.WriteLine(Producto + "*" + cantidad + "*" + precio);
                escribir.Close();
                Console.WriteLine("Inventario cargado");
                Console.WriteLine("Desea volver a cargar inventario");
                res = char.Parse(Console.ReadLine());
                Console.Clear();
                
            }
            while (res != 'n');
        }   
    }
}


