using System;
using System.Collections.Generic;
using System.Text;

namespace _1Laboratorio
{
    class Administrador:UserAdmin
    {
        public void Menu()
        {
            Console.WriteLine("Ingrese el numero de lo que desea realizar");
            Console.WriteLine("1.Observar Inventario\n2.Crear usuario\n3.Ver Factura");
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Inventario");
                
            }
            else if (x == 2)
            {
                Console.WriteLine("Usuario");
            }
            else
            {
                Console.WriteLine("Factura");
            }
        }
    }
}
