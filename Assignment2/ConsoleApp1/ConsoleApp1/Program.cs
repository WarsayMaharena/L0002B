using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Salesperson> salespeople = new List<Salesperson>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Säljkårsregister - Lägg till en säljare");
            Console.Write("Namn: ");
            string name = Console.ReadLine();

            Console.Write("Personnummer: ");
            string personalNumber = Console.ReadLine();

            Console.Write("Distrikt: ");
            string district = Console.ReadLine();

            Console.Write("Antal sålda artiklar: ");
            if (!int.TryParse(Console.ReadLine(), out int soldItems))
            {
                Console.WriteLine("Fel: Ange ett giltigt heltal för antal sålda artiklar.");
                Console.ReadLine();
                continue;
            }

            // Add salesperson to list
            salespeople.Add(new Salesperson(name, personalNumber, district, soldItems));

            Console.Write("Vill du lägga till fler säljare? (j/n): ");
            string answer = Console.ReadLine().ToLower();
            if (answer != "j")
                break;
        }

        SortAndDisplaySalespeople();
    }

    static void SortAndDisplaySalespeople()
    {
        // Sort salespeople by number of sold items (descending)
        var sortedList = salespeople.OrderByDescending(sp => sp.SoldItems).ToList();

        // Count sellers per level
        int level1 = sortedList.Count(sp => sp.SoldItems < 50);
        int level2 = sortedList.Count(sp => sp.SoldItems >= 50 && sp.SoldItems <= 99);
        int level3 = sortedList.Count(sp => sp.SoldItems >= 100 && sp.SoldItems <= 199);
        int level4 = sortedList.Count(sp => sp.SoldItems >= 200);

        string fileName = "SalesReport.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            Console.WriteLine("\nNamn        Persnr        Distrikt    Antal");
            writer.WriteLine("\nNamn        Persnr        Distrikt    Antal");

            Console.WriteLine();
            writer.WriteLine();
            foreach (var sp in sortedList)
            {
                if(sp.SoldItems < 50) { 
                string output = $"{sp.Name,-12} {sp.PersonalNumber,-12} {sp.District,-10} {sp.SoldItems}";
                Console.WriteLine(output);
                writer.WriteLine(output);
                }
            }
            if (level1 > 0) PrintAndWrite(writer, $"{level1} säljare har nått nivå 1: under 50 artiklar");
            foreach (var sp in sortedList)
            {
                if (50 <= sp.SoldItems && sp.SoldItems < 100)
                {
                    string output = $"{sp.Name,-12} {sp.PersonalNumber,-12} {sp.District,-10} {sp.SoldItems}";
                    Console.WriteLine(output);
                    writer.WriteLine(output);
                }
            }
            if (level2 > 0) PrintAndWrite(writer, $"{level2} säljare har nått nivå 2: 50-99 artiklar");
            foreach (var sp in sortedList)
            {
                if (100 <= sp.SoldItems && sp.SoldItems < 200)
                {
                    string output = $"{sp.Name,-12} {sp.PersonalNumber,-12} {sp.District,-10} {sp.SoldItems}";
                    Console.WriteLine(output);
                    writer.WriteLine(output);
                }
            }
            if (level3 > 0) PrintAndWrite(writer, $"{level3} säljare har nått nivå 3: 100-199 artiklar");
            foreach (var sp in sortedList)
            {
                if (200 <= sp.SoldItems)
                {
                    string output = $"{sp.Name,-12} {sp.PersonalNumber,-12} {sp.District,-10} {sp.SoldItems}";
                    Console.WriteLine(output);
                    writer.WriteLine(output);
                }
            }
            if (level4 > 0) PrintAndWrite(writer, $"{level4} säljare har nått nivå 4: över 199 artiklar");
        }

        
        Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
        Console.ReadKey();
    }

    static void PrintAndWrite(StreamWriter writer, string text)
    {
        Console.WriteLine(text);
        writer.WriteLine(text);
    }
}

class Salesperson
{
    public string Name { get; set; }
    public string PersonalNumber { get; set; }
    public string District { get; set; }
    public int SoldItems { get; set; }

    public Salesperson(string name, string personalNumber, string district, int soldItems)
    {
        Name = name;
        PersonalNumber = personalNumber;
        District = district;
        SoldItems = soldItems;
    }
}
