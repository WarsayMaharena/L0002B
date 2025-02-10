using System;

class Program
{
	static void Main()
	{
		Console.Write("Ange pris: ");
		if (!int.TryParse(Console.ReadLine(), out int price) || price <= 0)
		{
			Console.WriteLine("Fel: Ange ett giltigt pris.");
			return;
		}

		Console.Write("Betalt: ");
		if (!int.TryParse(Console.ReadLine(), out int paid) || paid < price)
		{
			Console.WriteLine("Fel: Betalt belopp måste vara större än priset.");
			return;
		}

		int change = paid - price;
		Console.WriteLine("\nVäxel tillbaka:");
		Console.WriteLine(CalculateChange(change));
	}

	static string CalculateChange(int change)
	{
		int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
		string[] names = { "femhundralapp", "tvåhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };

		string result = "";
		for (int i = 0; i < denominations.Length; i++)
		{
			int count = change / denominations[i];
			if (count > 0)
			{
				result += $"{count} {names[i]}{(count > 1 ? "ar" : "")}\n";
				change %= denominations[i];
			}
		}
		return result;
	}
}