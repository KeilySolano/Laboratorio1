using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace _1Laboratorio
{
    class UserAdmin
    {
        static string rutaadmin = "AdminUser.txt";
        static StreamReader Leer;
        static StreamWriter Escribir;
        public void iniciarsecion()
        {
            BContacto(Llenar("Usuario"), Llenar("Contraseña")); ;
            Console.ReadKey();
        }
        public void GuardarUser()
        {
            GContacto(Llenar("Nombre"), Llenar("Contraseña"));
        }

                             //ESTRUCTURA//

        static void GContacto(string nombre, string apellido)
        {
            Escribir = File.AppendText(rutaadmin);
            Escribir.WriteLine(nombre + "*" + apellido);
            Escribir.Close();
        }
        static string Llenar(string dato)
        {
            Console.Write("Ingrese" + dato + ":");
            return (Console.ReadLine());
        }
        static string BContacto(string nombre, string contraseña)
        {
            string linea = "contacto";
            Leer = File.OpenText(rutaadmin);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] Vec = linea.Split('*');
                int X = 0;
                if (X == 1)
                {
                    Console.WriteLine("ok");
                }
                else
                {
                    if (Vec[0] == nombre)
                    {
                        if (Vec[1] == contraseña)
                        {
                            Console.WriteLine("Datos correctos");
                            X = X + 1;
                        }
                    }
                   
                }
                linea = Leer.ReadLine();
            }
            Console.WriteLine("Datos incorrectos");

            Leer.Close();
            return linea;
        }
    }
}
