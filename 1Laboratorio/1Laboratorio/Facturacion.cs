using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Facturacion
    {
        static StreamReader Leer;
        static StreamWriter Escribir;
        static StreamReader Lector;
        static Trabajador traba = new Trabajador();
        public void Facturas()
        {
            string CantTem = "", Correlativo = "", Producto = "", Cliente = "", Nit = "", Fecha = "", Detalle = "", MontoTotal = "", Precio = "",  linea2 = "";
            ;
            double TotalT = 0;
            char res = 's';
            int Cn=0,x=0,cant = 0;
            Console.WriteLine("Inventario actual:");
            string linea1 = "",linea3="";
            using (Leer=new StreamReader("Inventario.txt"))
            {
                while ((linea3=Leer.ReadLine())!=null)
                {
                    string[] datos = linea3.Split('*');
                    Console.WriteLine("Producto:"+datos[1]+""+"Cantidad"+datos[3]+""+"Precio actual"+datos[5]+"Precio:"+datos[7]);
                }

            }
                Console.Write("Ingrese el correlativo de la factura:");
            Correlativo = Console.ReadLine();
            Console.Write("Ingrese el nombre del cliente");
            Cliente = Console.ReadLine();
            Console.Write("Ingrese el Nit");
            Nit = Console.ReadLine();
            Console.Write("Ingrese la Fecha");
            Fecha = Console.ReadLine();

            do
            {
                Console.Write("Nombre del Producto");
                Producto = Console.ReadLine();
                Detalle += ("producto:" + Producto + "*");
                Console.Write("Cantidad del producto:");
                cant = int.Parse(Console.ReadLine());
                Detalle += ("Cantidad del producto:" + cant + "*");
                Console.Write("Precio del producto.");
                Precio = Console.ReadLine();
                Detalle += ("Precio del producto" + Precio + "*");
                TotalT += cant * double.Parse(Precio);

                using (Escribir = new StreamWriter("InventarioTemp.txt"))
                {
                    using (Leer = new StreamReader("Inventario.txt"))
                    {
                        while ((linea1 = Leer.ReadLine()) != null)
                        {
                            string[] datos = linea1.Split('*');
                            if (datos[0] != Producto)
                            {
                                Escribir.WriteLine(linea1);
                            }
                            else if (datos[0] == Producto)
                            {
                                CantTem = datos[1];
                                cant = int.Parse(CantTem) - cant;
                            }
                        }
                    }
                }
                File.Delete("Inventario.txt");
                File.Move("InventarioTemp.txt", "Inventario.txt");
                Leer.Close();
                Escribir.Close();
                Escribir = File.AppendText("Inventario.txt");
                Escribir.WriteLine("Desea Agregar otro producto\nIngrese s/n");
                res = char.Parse(Console.ReadLine());
            }
            while (res!='n');
            MontoTotal = ("El total es :"+ TotalT);

            Leer = File.OpenText("Correlativos_Facturas.txt");
            while (linea2 != null)
            {
                linea2 = Leer.ReadLine();
                if (Correlativo == linea2)
                {
                    Console.WriteLine("Este correlativo de factura ya existe");
                    Console.WriteLine("Ingrese el correlativo");
                    Correlativo = Console.ReadLine();
                }                
            }
            Leer.Close();
            Escribir = File.AppendText("Correlativos_Facturas.txt");
            Escribir.WriteLine(Correlativo);
            Escribir.Close();
            Escribir = File.AppendText("Factura"+Correlativo+".txt");
            Escribir.WriteLine("Factura no.:"+Correlativo);
            Escribir.WriteLine("Nombre del cliente"+ Cliente);
            Escribir.WriteLine("Nit:"+Nit);
            Escribir.WriteLine("Detalles:");
            string[] detalles = Detalle.Split("*");
            Cn = detalles.Length;
            do
            {
                Escribir.WriteLine(detalles[x]);
                x = x + 1;
            }
            while (Cn>x);
            Escribir.WriteLine(MontoTotal);
            Escribir.Close();
               
        }

        public void MostrarFactura()
        {
            char res = 's';
            do
            {
                string correlativo = "";
                int encontrado = 1;
                Console.WriteLine("Correlativo de facturas existentes");
                string linea = "", linea2 = "", line = "";
                using (Leer = new StreamReader("Correlativos_Facturas.txt"))
                {
                    while ((linea = Leer.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
                Leer.Close();
                Console.Write("Ingrese el correlativo que desea ver");
                correlativo = Console.ReadLine();
                Leer = File.OpenText("Correlativos_Facturas.txt");
                while ((linea = Leer.ReadLine()) != null)
                {
                    if (line == correlativo)
                    {
                        encontrado++;
                        Console.WriteLine("Factura encontrada");
                        Lector = File.OpenText("Factura" + correlativo + ".txt");
                        while ((linea2 = Lector.ReadLine()) != null)
                        {
                            Console.WriteLine(linea2);
                        }
                    }
                }
                if (encontrado == 1)
                {
                    Console.WriteLine("Esta Factura no existe");
                }
                Leer.Close();
                Console.WriteLine("Desea volver a ver otra factura\nIngrese s/n");
                res = char.Parse(Console.ReadLine());
                Console.Clear();
            }
            while (res!='n');
        }
    }
}
