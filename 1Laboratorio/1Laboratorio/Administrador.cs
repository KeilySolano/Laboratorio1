using System;
using System.Collections.Generic;
using System.Text;

namespace _1Laboratorio
{
    class Administrador:UserAdmin
    {
        
        public void Menu()
        {
            char c = 's';
            do
            {
                Console.WriteLine("Ingrese el numero de lo que desea realizar");
                Console.WriteLine("1.Observar Inventario\n2.Crear usuario\n3.Ver Usuario\n4.Ver Factura");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Inventario");

                }
                else if (x == 2)
                {
                    GuardarUser();
                }
                else if (x == 3)
                {
                    Busuario();
                }
                else
                {
                    Console.WriteLine("Ver Facturas");
                }

                Console.WriteLine("Desea Regresar al Menu s/n");
                c = char.Parse(Console.ReadLine());
            }
            while (c != 'n');          
        }
    }
}
