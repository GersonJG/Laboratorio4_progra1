/// Programa de Stark

using System;
using System.Globalization;
class Program
{
    static int Rango(int n1, int x, int y)
    {
        int comprobar(int n1)
        {
            // Comprueba que el valor ingresado sea un numero y que este dentro del rango
            while (!int.TryParse(Console.ReadLine(), out n1))
            {
                Console.WriteLine("Ingrese un numero valido.");
                Console.Write("Seleccione: ");
            }
            return n1;

        }

        n1=comprobar(n1);
        while (n1 < x || n1 > y)
        {
            Console.WriteLine("Ingrese un valor valido.");
            Console.Write("Seleccione: ");
            n1 =comprobar(n1);
        }

        return n1;
    }

    static void VerificacionArchivo(string path, Action<string> funcion)
    {
        // Verifica si el archivo existe
        if (!File.Exists((path)))
        {
            Console.WriteLine("El archivo no existe. ¡¡ULTRON LO HA BORRADO!! >:c");
            return;
        }

        try
        {
            funcion(path);

        } catch (DirectoryNotFoundException err)
        {
            Console.WriteLine($"No se ha encontado el directorio: {path}, DEBE SER CULPA DE ULTRON");
        } catch (FileNotFoundException err)
        {
            Console.WriteLine($"No se ha encontado el archivo: {path}, DEBE SER CULPA DE ULTRON");
        }
        catch (Exception err)
        {
            Console.WriteLine($" Este es otro error: {err}. IGUAL SIGUE SIENDO CULPA DE ULTRON");
        }

    }

    static void Menu()
    {
        Console.WriteLine(" BIENVENIDO TONY STARK");
        Console.Write("1. Crear Archivo \n2. Agregar Invento \n3. Leer Inventos por linea \n4. Leer Inventos Completos \n5. Copiar un archivo" +
            "\n6. Mover un archivo \n7. Eliminar un archivo \n8. Listar Archivos \n9. Crear Carpeta.\n10. Salir\nSeleccion: ");

    }

    static void CrearArchivo(string path)
    {
        // Crea un archivo 
        Console.Write("Ingrese el invento: ");
        string contenido = Console.ReadLine();
        File.WriteAllText(path, contenido);
        Console.WriteLine("Archivo creado con exito");
    }

    static void AgregarInvento(string path)
    {
        //Agrega un invento sin borrar el contenido anterior
        Console.Write("Ingrese el nuevo invento: ");
        string invento = Console.ReadLine();
        File.AppendAllText(path, "\n" + invento );
        Console.WriteLine("Invento agregado con exito");
    }

    static void LeerInventosporLinea(string path)
    {
        //Lee los inventos por linea y les asigna un numero
        int contador = 0;
        string[] lineas = File.ReadAllLines(path);
        Console.WriteLine("Lista de inventos de Tony: ");
        foreach (string linea in lineas)
        {
            contador++;
            Console.WriteLine($"Invento No.{contador}: {linea} ");
        }
    }

    static void LeerInventosTodos(string path)
    {
        //Lee todos los inventos
        string contenido = File.ReadAllText(path);
        Console.Write("Invetos de Tony: ");
        Console.WriteLine("\n"+contenido);
    }

    static void CopiarArchivo(string path)
    {
        //Copia el archivo al backup
        string backup = "C:/Programa Tony/Backup/inventos.txt";
        File.Copy(path, backup);
        Console.WriteLine("Archivo copiado con exito");
    }

    static void MoverArchivo(string path)
    {
        //Mueve el archivo a otra carpeta
        string destino = "C:/Programa Tony/ArchivosClasificados/inventos.txt";
        File.Move(path, destino);
        Console.WriteLine("Archivo movido con exito");
    }

    static void EliminarArchivo(string path)
    {
        //Elimina el archivo
        File.Delete(path);
        Console.WriteLine("Archivo eliminado con exito");
    }

    static void ListarArchivos(string carpeta)
    {
        /// Lee todos los archivos dentro de la carpeta y filtra en los archivos planos tipo .txt
        /// Lo hice con la opcion Directory porque en FILE no existe ninguna opcion que me permita hacer una lista de archivos de un carpeta

        string[] archivos = Directory.GetFiles(carpeta, "*.txt");
        Console.WriteLine("Archivos en la carpeta: ");
        foreach (string archivo in archivos)
        {
            Console.WriteLine(archivo);
        }
    }

    static void CrearCarpeta()
    {
        //Crea un carpeta 
        string carpeta = "C:/Programa Tony/ProyectosSecretos";
        Directory.CreateDirectory(carpeta);
        Console.WriteLine("Carpeta creada con exito");

        if (Directory.Exists(carpeta))
        {
            Console.WriteLine("La carpeta ya existe");
        }

    }

        static void Main()
    {
        string path = "C:/Programa Tony/LaboratorioAvengers/inventos.txt";
        int menu = 1;
        do
        {
            int eleccion = 0;
            Menu();
            eleccion = Rango(eleccion, 1, 10);
            switch (eleccion)
            {
                case 1:
                    CrearArchivo(path);
                    break;

                case 2:
                    VerificacionArchivo(path, AgregarInvento);
                    break;

                case 3:
                    VerificacionArchivo(path, LeerInventosporLinea);
                    break;

                case 4:
                    VerificacionArchivo(path, LeerInventosTodos);
                    break;

                case 5:
                    VerificacionArchivo(path, CopiarArchivo);
                    break;

                case 6:
                    VerificacionArchivo(path, MoverArchivo);
                    break;

                case 7:
                    VerificacionArchivo(path, EliminarArchivo);
                    break;

                case 8:
                    string carpeta = "C:/Programa Tony/LaboratorioAvengers";
                    ListarArchivos(carpeta);
                    break;

                case 9:
                    CrearCarpeta();
                    break;

                case 10: 
                    Console.WriteLine("Saliendo del programa...");
                    Console.WriteLine("Adios Tony Stark");
                    return;

                default:
                    Console.WriteLine("Opcion no valida");
                    break;

            }

            Console.Write("Desea hacer otra operacion: 1.SI  2.NO\nSeleccione: ");
            menu = Rango(menu, 1, 2);
            if (menu == 2)
            {
                Console.WriteLine("Saliendo del programa...");
                Console.WriteLine("Adios Tony Stark");
            }

        } while (menu == 1);


    }
}
    
