using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace programme_fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = "out";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            

            string filename = "monfichier.txt";
            string filename2 = "monfichier2.txt";

            string pathAndFile = Path.Combine(path, filename);
            string pathAndFile2 = Path.Combine(path, filename2);

            if (File.Exists(pathAndFile))
            {
                Console.WriteLine("Le fichier existe déjà, on va l'écraser son contenu");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas, on va le créer");
            }

            Console.WriteLine("FICHIER : " + pathAndFile);

            /*var noms = new List<string>()
            {
                "Jean",
                "Paul",
                "Martin"
            };*/

            StringBuilder texte = new StringBuilder();
            int nbLignes = 20000000;

            // immutable
            //texte = "toto";
            //texte += "o"; //totoo

            // mutable
            // StringBuilder

            //------------------------------------------------------
            /*DateTime t1 = DateTime.Now;

            Console.WriteLine("Préparation des données...");
            for (int i = 1; i <= nbLignes; i++)
            {
                texte.Append( "Ligne " + i + "\n");
            }
            Console.WriteLine("Ok");

            Console.WriteLine("Ecriture des données...");
            File.WriteAllText(pathAndFile, texte.ToString());
            Console.WriteLine("Ok");

            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1).TotalMilliseconds);
            Console.WriteLine("Durée (ms) : " + diff);*/
            //------------------------------------------------------

            // Stream : flux
            DateTime t1 = DateTime.Now;

            Console.WriteLine("Ecriture des données...");
            using (var writeStream = File.CreateText(pathAndFile))
            {
                for (int i = 1; i <= nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + "\n");
                }
            }

            Console.WriteLine("Ok");

            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1).TotalMilliseconds);
            Console.WriteLine("Durée (ms) : " + diff);

            //Lecture avec un stream
            using (var readStream = File.OpenText(pathAndFile))
            {
                while(true)
                {
                    var line = readStream.ReadLine();
                    if(line == null)
                    {
                        break;
                    }
                    Console.WriteLine(line);
                }
            }

            //File.AppendAllText(filename, "Je rajoute ce texte");
            //File.WriteAllLines(filename, noms);

            /*try
            {
                //string resultat = File.ReadAllText("monfichier.txt");
                var lignes = File.ReadAllLines(filename);

                foreach(var ligne in lignes)
                {
                    Console.WriteLine(lignes);
                }
                
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("ERREUR : Ce fichier n'existe pas (" + ex.Message + ")");
            }
            catch
            {
                Console.WriteLine("Une erreur inconnue est arrivée");
            }*/

            //File.Copy(pathAndFile, pathAndFile2);
            //File.Delete(pathAndFile2);
            //File.Move(pathAndFile, pathAndFile2);
        }
    }
}
