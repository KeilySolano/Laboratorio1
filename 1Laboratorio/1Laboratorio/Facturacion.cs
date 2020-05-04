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
        public void Facturas()
        {
            string CantTem = "", Correlativo = "", Producto = "", Cliente = "", Nit = "", Fecha = "", Detalle = "", MontoTotal = "", continuar = "Si", Precio = "";
            double TotalT = 0;
            int casillasNo=0,x=0,w=0,cant = 0;
            Console.WriteLine("Inventario actual:");
            string linea = "", line = "";
            using (Leer=new StreamReader("Inventario.txt"))
            {
                while ((linea=Leer.ReadLine())!=null)
                {
                    string[] datos = linea.Split('*');
                    Console.WriteLine("producto:" + datos[0] + ""+ "Unidades:" + datos[1] + "" +"Precio actual:" + datos[2]);
                }
            }
            Leer.Close();
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
                        while ((line = Leer.ReadLine()) != null)
                        {
                            string[] datos = line.Split('*');
                            if (datos[0] != Producto)
                            {
                                Escribir.WriteLine(line);
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
                //if (cant>0)
                Escribir.WriteLine("Desea Agregar otro producto");
                continuar = Console.ReadLine();
            }
            while (continuar == "SI" || continuar == "si");
            MontoTotal = ("El total es de:"+ TotalT);

            string linea2 = "";
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
            casillasNo = detalles.Length;
            do
            {
                Escribir.WriteLine(detalles[x]);
                x = x + 1;
            }
            while (casillasNo>x);
            Escribir.WriteLine(MontoTotal);
            Escribir.Close();
               
        }
    }
}
