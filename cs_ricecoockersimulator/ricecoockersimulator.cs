//  RiceCookerSimulator.cs

using System;
using System.Threading;

class Program
{
    static bool isCookerOn = false;
    static int riceQuantity = 0;

    static void Main()
    {
        try
        {
            while (true)
            {
                if (!isCookerOn)
                {
                    Console.WriteLine("Appuyez sur A pour allumer le rice cooker, ou Q pour quitter : ");
                    var answer = Console.ReadLine().ToUpper();

                    if (answer == "A")
                    {
                        isCookerOn = true;
                        Console.WriteLine("Rice cooker allumé.");
                        CookRice();
                    }
                    else if (answer == "Q")
                    {
                        Console.WriteLine("Rice cooker éteint.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Commande non valide.");
                    }
                }
                else
                {
                    if (riceQuantity == 0)
                    {
                        Console.Write("Entrez la quantité de riz (entre 1 et 5 mesurettes) : ");
                        if (int.TryParse(Console.ReadLine(), out riceQuantity) && riceQuantity >= 1 && riceQuantity <= 5)
                        {
                            Console.WriteLine($"Vous allez cuire {riceQuantity} mesurettes de riz.");
                        }
                        else
                        {
                            Console.WriteLine("Quantité de riz invalide. Le programme s'arrête.");
                            break;
                        }
                    }

                    Console.WriteLine("Options :");
                    Console.WriteLine("1. Continuer");
                    Console.WriteLine("2. Ajouter");
                    Console.WriteLine("3. Enlever");
                    Console.WriteLine("4. Annuler (éteindre rice cooker)");

                    Console.Write("Choisissez une option : ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            CookRice();
                            break;
                        case "2":
                            AddRice();
                            break;
                        case "3":
                            RemoveRice();
                            break;
                        case "4":
                            Console.WriteLine("Rice cooker éteint.");
                            isCookerOn = false;
                            break;
                        default:
                            Console.WriteLine("Option non valide.");
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur est survenue : {ex.Message}");
        }
    }

    static void CookRice()
    {
        Console.WriteLine("Cooking...");
        Thread.Sleep(10000); // Attendez 10 secondes
        Console.WriteLine("Bip Bip");
        Console.WriteLine("Warm (le riz est cuit).");
    }

    static void AddRice()
    {
        try
        {
            Console.Write("Entrez la quantité de riz à ajouter (entre 1 et 4 mesurettes) : ");
            if (int.TryParse(Console.ReadLine(), out int amountToAdd) && amountToAdd >= 1 && amountToAdd <= 4 && riceQuantity + amountToAdd <= 5)
            {
                riceQuantity += amountToAdd;
                Console.WriteLine($"Vous allez cuire {riceQuantity} mesurettes de riz.");
            }
            else
            {
                Console.WriteLine("Quantité de riz invalide. Ajout annulé.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'ajout de riz : {ex.Message}");
        }
    }

    static void RemoveRice()
    {
        try
        {
            Console.Write("Entrez la quantité de riz à enlever (supérieure à 0) : ");
            if (int.TryParse(Console.ReadLine(), out int amountToRemove) && amountToRemove > 0 && riceQuantity - amountToRemove >= 0)
            {
                riceQuantity -= amountToRemove;
                Console.WriteLine($"Vous allez cuire {riceQuantity} mesurettes de riz.");
            }
            else
            {
                Console.WriteLine("Quantité de riz invalide. Enlèvement annulé.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'enlèvement de riz : {ex.Message}");
        }
    }
}
