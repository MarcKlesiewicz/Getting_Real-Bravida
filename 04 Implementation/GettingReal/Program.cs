﻿using System;
using System.ComponentModel;

namespace GettingReal
{
    class Program
    {
        static void Main(string[] args)
        {
            string prisGrundlag;
            Controller controller = new Controller();
            Aftaleseddel valgtaftaleseddel;
            int i = 1;
            try
            {
                foreach (var aftaleseddel in controller.VisEntrepriseOversigt())
                {

                    Console.WriteLine(i + ": " + aftaleseddel.Overskrift);
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            bool ikkeILoop = true;
            while (ikkeILoop)
            {
                
                Console.WriteLine("\n Hvad vil du? \n 1. Oprette Ny AftaleSeddel \n 2. Vælge Aftaleseddel \n 3. Slette Aftaleseddel \n Skriv et tal fra 1-3 for at vælge i menuen");
                int.TryParse(Console.ReadLine(), out int result);
                switch (result)
                {
                    case 1:
                        Console.WriteLine("Hvad er aftalesedlens overskrift??");
                        string aftalesedlensoverskrift = Console.ReadLine();
                        Console.WriteLine("Hvem er modtageren");
                        string modtager = Console.ReadLine();
   
                        Console.WriteLine("Hvad er tidspåvirkningen?");
                        string tid = Console.ReadLine();
                        Console.WriteLine("----\n Hvad er prisgrundlaget? \n 1. bygherreønske \n 2. Efterregning \n 3. projektændring");
                        string valg = Console.ReadLine();
                        if (valg == "1")
                        {
                            prisGrundlag = "bygherreønske";
                        }
                        else if (valg == "2")
                        {
                            prisGrundlag = "efterregning";
                        }
                        else if (valg == "3")
                        {
                            prisGrundlag = "projektændring";
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                        Console.WriteLine("Hvad udføres det i henhold til?");
                        string arbejdsudførelse = Console.ReadLine();
                        controller.OpretAftaleseddel(aftalesedlensoverskrift, modtager, tid, prisGrundlag,
                            arbejdsudførelse);
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Hvilken aftaleseddel ud fra menuen vælger du?");
                        for (int j = 0; j < controller.VisEntrepriseOversigt().Count; j++)
                        {
                            foreach (var item in controller.VisEntrepriseOversigt())
                            {
                                Console.WriteLine(i+": " +item.Overskrift);
                                
                            }
                            if (int.TryParse(Console.ReadLine(), out int temp) == false)
                            {
                                Console.WriteLine("Vælg en korrekt værdi");
                                continue;
                            }

                            if (temp == i)
                            {
                                valgtaftaleseddel =
                                    controller.VælgAftaleseddel(controller.VisEntrepriseOversigt()[0].Overskrift);
                                Console.Clear();
                                Console.WriteLine(" \t ------Aftaleseddel----");
                                Console.WriteLine(
                                    $"Byggeherren: = {valgtaftaleseddel.Bygherre}, ProjektNavn: {valgtaftaleseddel.ProjektNavn}, Sted: {valgtaftaleseddel.Sted}, Modtager: {valgtaftaleseddel.Modtager}, Dato: {DateTime.Now} og  Løbenmr {valgtaftaleseddel.LøbeNr}");
                                Console.WriteLine(
                                    $"\n ProjektNr. {valgtaftaleseddel.ProjektNr} Tidsplanspåvirkning: {valgtaftaleseddel.TidsPåvirkning}, Overskrift {valgtaftaleseddel.Overskrift}, Svar senest:  {valgtaftaleseddel.SvarSenest}, Ref Plan: {valgtaftaleseddel.Reference}");

                                Console.WriteLine(" \n Tryk Enter for at forsætte");
                                Console.ReadLine();
                                Console.WriteLine("Vil du redigere noget i aftalesedlen? \n 1. Rediger Overskriften \n 2. Rediger ProjektModtager \n 3. Redigere i tidsplanen \n 4. Rediger i svar senest \n Redigere i reference planen");
                                Console.WriteLine("Hvad vil du redigere?");
                                string Redigere= Console.ReadLine();
                                Console.WriteLine("Hvad vil du redigere det til?");
                                string RedigerTil = Console.ReadLine();

                                switch (Redigere)
                                {
                                    case "1":
                                        controller.RedigerAftaleseddel("Overskrift", RedigerTil);
                                        break;
                                    case "2":
                                        controller.RedigerAftaleseddel("Modtager", RedigerTil);
                                        break;
                                    case "3":
                                        controller.RedigerAftaleseddel("Tidspåvirkning", RedigerTil);
                                        break;
                                    case "4":
                                        controller.RedigerAftaleseddel("PrisGrundlag", RedigerTil);
                                        break;
                                    case "5":
                                        controller.RedigerAftaleseddel("ArbejdsUdførelse", RedigerTil);
                                        break;
                                    default:
                                        Console.WriteLine("Du kan ikke finde ud af simple instruktioner");
                                        break;
                                }
                            }
                        }

                        break;
                    case 3:
                      
                        for (int j = 0; j < controller.VisEntrepriseOversigt().Count; j++)
                        {
                            foreach (var item in controller.VisEntrepriseOversigt())
                            {
                                Console.WriteLine(i + ": " + item.Overskrift);

                            }
                            Console.WriteLine("Hvilken aftaleseddel ud fra menuen vælger du?");
                            if (int.TryParse(Console.ReadLine(), out int temp) == false)
                            {
                                Console.WriteLine("Vælg en korrekt værdi");
                                continue;
                            }

                            if (temp == i)
                            {
                                controller.SletAftaleseddel(controller.VisEntrepriseOversigt()[i]);
                            }
                        }

                        break;
                    default:
                        ikkeILoop = false;
                        Console.WriteLine("Du har ikke valgt en gyldig valgmulighed");
                        break;


                }
            }

        }
    }
}
