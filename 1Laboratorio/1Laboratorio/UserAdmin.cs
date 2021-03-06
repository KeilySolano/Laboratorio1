﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace _1Laboratorio
{
    class UserAdmin
    {
        static string rutaadmin = "AdminUser.txt";
        static string rutatraba = "TrabajoUser.txt";
        static StreamReader Leer;
        static StreamWriter Escribir;
        public void iniciarsecion()
        {
            inisecion(Llenar("Usuario"), Llenar("Contraseña")); 
            
        }
        public void CrearUser()
        {
            GUser(Llenar("Nombre"), Llenar("Contraseña"));
        }
        public void Busuario()
        {
            Console.WriteLine("--------------Usuarios ");
            MosUser();
        }

        //ESTRUCTURA//

        static void GUser(string nombre, string apellido)
        {
            char res = 's';
            int x;
            do
            {
                Console.WriteLine("Que tipo de usuario desea crear\n 1.Administrador\n2.Trabajador");
                 x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Escribir = File.AppendText(rutaadmin);
                    Escribir.WriteLine(nombre + "*" + apellido);
                    Escribir.Close();
                }
                else
                {
                    Escribir = File.AppendText(rutatraba);
                    Escribir.WriteLine(nombre + "*" + apellido);
                    Escribir.Close();
                }
                Console.WriteLine("Desea volver a ver otra factura\nIngrese s/n");
                res = char.Parse(Console.ReadLine());
                Console.Clear();
            }
            while (res!='n');
        }
        static string Llenar(string dato)
        {
            Console.Write("Ingrese" + dato + ":");
            return (Console.ReadLine());
        }
        static string inisecion(string nombre, string contraseña)
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
            while (x=='f');
            Leer.Close();
            return linea;
        }
        static string MosUser()
        {
            char res= 's';
            int x;
            do
            {
                string linea = "contacto";
                Console.WriteLine("Desea ver:\n1.Administrador\n2.Trabajador");
                 x = int.Parse(Console.ReadLine());
                if (x == 1)
                {

                    Leer = File.OpenText(rutaadmin);
                    linea = Leer.ReadLine();
                    while (linea != null)
                    {
                        string[] Vec = linea.Split('*');

                        Console.WriteLine(Vec[0] + "-" + Vec[1] + "-");

                        linea = Leer.ReadLine();
                    }
                }
                else
                {

                    Leer = File.OpenText(rutatraba);
                    linea = Leer.ReadLine();
                    while (linea != null)
                    {
                        string[] Vec = linea.Split('*');

                        Console.WriteLine(Vec[0] + "-" + Vec[1] + "-");

                        linea = Leer.ReadLine();
                    }
                }
                Console.WriteLine("Desea volver a ver otra factura\nIngrese s/n");
                res = char.Parse(Console.ReadLine());
                Console.Clear();
                return linea;

            }
            while (res!='n');
        }
    }
}
