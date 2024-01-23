class RainfallData
{
	static void Main()
	{
		// Define the number of days and times of measurement
		int days = 7;
		int timesPerDay = 3;

		// Initialize a 2D array to store rainfall data
		double[,] rainfall = new double[days, timesPerDay];

		// Populate the array with random rainfall data
		Random random = new Random();
		for (int day = 0; day < days; day++)
		{
			for (int time = 0; time < timesPerDay; time++)
			{
				rainfall[day, time] = Math.Round(random.NextDouble() * 3 + 2, 2); // Generate random values between 2 and 5
			}
		}

		// Display the measured data
		Console.WriteLine("Measured Rainfall Data:");
		Console.WriteLine("Day\t6 AM\t2 PM\t10 PM");
		for (int day = 0; day < days; day++)
		{
			Console.Write($"{day + 1}\t");
			for (int time = 0; time < timesPerDay; time++)
			{
				Console.Write($"{rainfall[day, time]:F2}\t");
			}
			Console.WriteLine();
		}

		// Calculate and display daily average precipitation in ascending order
		Console.WriteLine("\nDaily Average Precipitation (Ascending Order):");

		// Create an array to store daily average precipitation
		double[] dailyAverages = new double[days];

		for (int day = 0; day < days; day++)
		{
			// Calculate the daily average precipitation
			dailyAverages[day] = (rainfall[day, 0] + rainfall[day, 1] + rainfall[day, 2]) / timesPerDay;
		}

		// Sort the array in ascending order
		Array.Sort(dailyAverages);

		// Display the daily average precipitation in ascending order
		for (int day = 0; day < days; day++)
		{
			Console.WriteLine($"Day {Array.IndexOf(dailyAverages, (rainfall[day, 0] + rainfall[day, 1] + rainfall[day, 2]) / timesPerDay) + 1}: {dailyAverages[day]:F2} l/m^2");
		}

		// Find the day with the least and most precipitation
		double minPrecipitation = double.MaxValue;
		double maxPrecipitation = double.MinValue;
		int dayWithLeast = 0;
		int dayWithMost = 0;

		for (int day = 0; day < days; day++)
		{
			double totalPrecipitation = rainfall[day, 0] + rainfall[day, 1] + rainfall[day, 2];

			if (totalPrecipitation < minPrecipitation)
			{
				minPrecipitation = totalPrecipitation;
				dayWithLeast = day;
			}

			if (totalPrecipitation > maxPrecipitation)
			{
				maxPrecipitation = totalPrecipitation;
				dayWithMost = day;
			}
		}

		// Display the day with the least and most precipitation
		Console.WriteLine($"\nDay with least precipitation: Day {dayWithLeast + 1}");
		Console.WriteLine($"Day with most precipitation: Day {dayWithMost + 1}");

		// Find the day with the most precipitation in the morning (6 AM)
		double maxMorningPrecipitation = double.MinValue;
		int dayWithMaxMorningPrecipitation = 0;

		for (int day = 0; day < days; day++)
		{
			if (rainfall[day, 0] > maxMorningPrecipitation)
			{
				maxMorningPrecipitation = rainfall[day, 0];
				dayWithMaxMorningPrecipitation = day;
			}
		}

		// Display the day with the most precipitation in the morning
		Console.WriteLine($"\nDay with most precipitation in the morning (6 AM): Day {dayWithMaxMorningPrecipitation + 1}");

		// Find the day with the most precipitation between 6 AM and 10 PM
		double maxTotalPrecipitation = double.MinValue;
		int dayWithMaxTotalPrecipitation = 0;

		for (int day = 0; day < days; day++)
		{
			double totalPrecipitation = rainfall[day, 0] + rainfall[day, 1] + rainfall[day, 2];

			if (totalPrecipitation > maxTotalPrecipitation)
			{
				maxTotalPrecipitation = totalPrecipitation;
				dayWithMaxTotalPrecipitation = day;
			}
		}

		// Display the day with the most precipitation between 6 AM and 10 PM
		Console.WriteLine($"\nDay with most precipitation between 6 AM and 10 PM: Day {dayWithMaxTotalPrecipitation + 1}");
	}
}
