using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw_2_RAD
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(currentPath);
            FileInfo[] filesInfo;

            Console.WriteLine("Niniejszy program pracuje wylacznie na folderze w ktorym sie znajduje. Aby modyfikowac pliki musza one byc zebrane w jednym folderze razem z niniejszym plikiem *.exe.\n\n");

            string cmd;
            Console.WriteLine("Wpisz 'info' aby uzyskac pomoc...");
            for (;;)
            {
                filesInfo = dirInfo.GetFiles();
                Console.WriteLine();
                cmd = Console.ReadLine();
                Console.WriteLine();
                if (cmd == "info")
                {
                    Console.WriteLine("Lista dostepnych polecen: \n");
                    Console.WriteLine("clear\t-\tCzysci konsole");
                    Console.WriteLine("path \t-\tWyswietla biezaca sciezke");
                    Console.WriteLine("count \t-\tWyswietla ilosc plikow dla biezacej sciezki");
                    Console.WriteLine("names \t-\tWyswietla nazwy wszystkich plikow dla biezacej sciezki");
                    Console.WriteLine("cname \t-\tZmienia nazwe wybranego pliku");
                    Console.WriteLine("date \t-\tWyswietla date modyfikacji wybranego pliku");
                    Console.WriteLine("dates \t-\tWyswietla nazwy i daty mod. plikow dla biezacej sciezki");
                    Console.WriteLine("cnamedates \t-\tZmienia nazwy wszystkich plikow na daty uwtorzenia");
                    Console.WriteLine("Search \t-\tListuje wszystkie pliki w biezacej sciezce i wyswietla ich szczegoly");
                    Console.WriteLine("about \t-\tWyswietla informacje o aplikacji");
                    Console.WriteLine("quit \t-\tZamyka aplikacje");
                }
                else if(cmd == "q" || cmd == "quit" || cmd == "exit")
                {
                    return;
                }
                else if(cmd == "clear")
                {
                    Console.Clear();
                    Console.WriteLine("Wpisz 'info' aby uzyskac pomoc...");

                }
                else if(cmd == "path")
                {
                    Console.WriteLine("Biezaca sciezka: ");
                    Console.WriteLine(currentPath);
                }
                else if(cmd == "count")
                {
                    Console.WriteLine("Ilosc plikow dla biezacej sciezki: ");
                    Console.WriteLine(filesInfo.Length);
                }
                else if(cmd == "names")
                {
                    int iterator = 0;
                    foreach (FileInfo plik in filesInfo)
                    {
                        Console.WriteLine("["+iterator+"] "+plik.Name);
                        iterator++;
                    }
                }
                else if( cmd == "cname")
                {
                    int nr = 0;

                    Console.WriteLine("Podaj numer pliku, ktorego nazwe chcesz zmienic w biezacej sciezce: ");
                    cmd = Console.ReadLine();
                    if(int.TryParse(cmd,out nr))
                    {
                        Console.WriteLine("Podaj nowa nazwe: ");
                        cmd = Console.ReadLine();
                        Console.WriteLine("\n");
                        if(filesInfo[nr].Name != AppDomain.CurrentDomain.FriendlyName)
                        { 
                            File.Move(filesInfo[nr].FullName, cmd);
                            
                            Console.WriteLine("Zmieniono nazwe pliku.");
                        }
                        else
                        {
                            Console.WriteLine("Byc moze zmiana nazwy obecnie wykonywanego pliku *.exe to nie najlepszy pomysl, co?");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podana wartosc nie jest liczba...");
                        Console.WriteLine("Wpisz 'info' aby uzyskac pomoc...");
                    }
                }
                else if(cmd == "date")
                {
                    int nr = 0;

                    Console.WriteLine("Podaj numer pliku, ktorego date mod. chcesz odczytac w biezacej sciezce: ");
                    cmd = Console.ReadLine();
                    if (int.TryParse(cmd, out nr))
                    {
                        Console.WriteLine(filesInfo[nr].Name+": "+filesInfo[nr].LastWriteTime);
                    }
                    else
                    {
                        Console.WriteLine("Podana wartosc nie jest liczba...");
                        Console.WriteLine("Wpisz 'info' aby uzyskac pomoc...");
                    }
                }
                else if( cmd == "dates")
                {
                    int iterator = 0;
                    foreach (FileInfo plik in filesInfo)
                    {
                        Console.WriteLine("["+iterator+"] "+plik.Name+": \t"+plik.LastWriteTime);
                        iterator++;
                    }
                }
                else if(cmd == "cnamedates")
                {
                    
                     foreach (FileInfo plik in filesInfo)
                    {
                        if (plik.Name != AppDomain.CurrentDomain.FriendlyName)
                        {
                            
                            File.Move(plik.FullName, plik.CreationTime.ToString().Replace(":","_")+plik.Extension);
                                
                        }
                       

                    }
                    Console.WriteLine("Operacja zakonczona pomyslnie.");
                    
                }
                else if(cmd == "about")
                {
                    Console.WriteLine("Aplikacja stworzona na przedmiot: 'Programowanie w srodowiskach RAD' jako jeden z projktow na zaliczenie.\n\n");
                    Console.WriteLine("Niniejszy program pracuje wylacznie na folderze w ktorym sie znajduje. Aby modyfikowac pliki musza one byc zebrane w jednym folderze razem z niniejszym plikiem *.exe.\n\n");
                }
                else if(cmd == "Search")
                {
                    int n = 0;
                    foreach (FileInfo plik in filesInfo)
                    {
                        Console.WriteLine("["+n+"]"+plik.Name);
                        Console.WriteLine("Utworzony:\t"+plik.CreationTime.ToString().Replace(":","_"));
                        Console.WriteLine("Ostatni dostep:\t" + plik.LastAccessTime.ToString().Replace(":", "_"));
                        Console.WriteLine("Ostatnio mod.:\t" + plik.LastWriteTime.ToString().Replace(":", "_"));
                        Console.WriteLine("Rozmiar [B]:\t" + plik.Length.ToString());
                        Console.WriteLine("Widoczny:\t" + !plik.Attributes.HasFlag(FileAttributes.Hidden));
                        Console.WriteLine("Tymczasowy:\t" + plik.Attributes.HasFlag(FileAttributes.Temporary));
                        Console.WriteLine("\n\n");
                        n++;
                    }
                }
                else
                {
                    Console.WriteLine("Nieznane polecenie - aby uzyskac pomoc wpisz 'info'...");
                }

            }
            
        }
    }
}
