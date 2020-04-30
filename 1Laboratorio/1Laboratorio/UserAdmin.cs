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
            char x = 'f';
            do 
                
            {
                while (linea != null)
                {
                    string[] Vec = linea.Split('*');

                    if (Vec[1] == contraseña)
                    {
                        x = 'v';
                    }
                    else 
                    {
                        x = 'f';
                        int ca = 1;
                    }
                    
                       
                        linea = Leer.ReadLine();
                    
                }
            }
            while (x=='f');
            return linea;
        }
    }
}
