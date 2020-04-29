using System;
using System.IO;

namespace _1Laboratorio
{
    class Program
    {
        static Administrador Admin = new Administrador();
        static void Main(string[] args)
        {
            Console.WriteLine("LOS PATOS");
            Console.WriteLine("Que desea tipo de Usuatrio es:");
            int c = int.Parse(Console.ReadLine());
            Console.Clear();
            if (c==1)
            {
                Admin.iniciarsecion();
                Admin.Menu();
            }
            else 
            {
                Console.WriteLine("EN PROCESO");
            }
            
        }
    }
}
