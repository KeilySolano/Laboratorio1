using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _1Laboratorio
{
    class Trabajador
    {
        static Inventario Inven = new Inventario();
        static Facturacion Fact = new Facturacion();
        static string rutatraba = "TrabajoUser.txt";
        static StreamReader Leer;

        public void Menu()
        {
            char c = 's';
            do
            {
                Console.WriteLine("Ingrese el numero de lo que desea realizar");
                Console.WriteLine("1. Inventario\n2.Facturacion");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Inven.Modificar();                   
                }
                else
                {
                    Fact.Facturas();
                }
                Console.WriteLine("Desea Regresar al Menu s/n");
                c = char.Parse(Console.ReadLine());
                Console.Clear();
            }
            while (c != 'n');
        }
        public void iniciarsecion()
        {
            inisecion(Llenar("Usuario"), Llenar("Contraseña")); 

        }
        static string Llenar(string dato)
        {
            Console.Write("Ingrese" + dato + ":");
            return (Console.ReadLine());
        }
        static string inisecion(string nombre, string contraseña)
        {
            string linea = "contacto";
            Leer = File.OpenText(rutatraba);
            linea = Leer.ReadLine();
            char x = 'f';
            do

            {
                while (linea != null)
                {
                    string[] Vec = linea.Split('*');

                    if (Vec[0] == nombre && Vec[1] == contraseña)
                    {
                        x = 'v';
                    }
                    else
                    {
                        x = 'f';

                    }
                    linea = Leer.ReadLine();
                }
            }
            while (x == 'f');
            Leer.Close();
            return linea;
        }

    }
}
