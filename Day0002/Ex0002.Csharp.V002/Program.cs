using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex0002.Csharp.V002
{
	class Program
	{
		static void Main(string[] args)
		{

			ConsoleKeyInfo keyInfo = default(ConsoleKeyInfo);

			do
			{
				var numberLabel = "initial";
				int initialNumber;

				if (!TryReadNumber(numberLabel, out initialNumber))
				{
					return;
				}

				numberLabel = "final";
				int finalNumber;

				if (!TryReadNumber(numberLabel, out finalNumber))
				{
					return;
				}

				if (initialNumber > finalNumber)
				{
					var auxiliaryNumber = initialNumber;
					initialNumber = finalNumber;
					finalNumber = auxiliaryNumber;
				}

				var targetNumbers = Enumerable.Range(initialNumber, finalNumber - initialNumber + 1).ToArray();

				var maxCycleLenght = GetMaxCycleLenght(targetNumbers);

				Console.WriteLine(string.Format("Initial number: {0} | final number: {1} | max cycle lenght: {2}", initialNumber, finalNumber, maxCycleLenght));
				Console.WriteLine();
				Console.WriteLine("Press any key to continue, press Escape to exit");
				Console.WriteLine("***********************************************");
				keyInfo = Console.ReadKey();


			} while (keyInfo.Key != ConsoleKey.Escape);
		}

		private static int GetMaxCycleLenght(int[] targetNumbers)
		{
			var maxCycleLenght = 0;
			var iterationResults = (new long[] { 1 }).ToList();
			var allIterationResults = iterationResults.ToList();

			var resultDictionary = targetNumbers.ToDictionary((number) => { return (long)number; }, (number) => { return false; });

			do
			{
				UpdateResultsDictionary(iterationResults, resultDictionary);
				iterationResults = GetUpdatedIterationResults(iterationResults, allIterationResults).ToList();
				allIterationResults.AddRange(iterationResults);
				maxCycleLenght++;
			} while (resultDictionary.ContainsValue(false));
			return maxCycleLenght;
		}

		private static void UpdateResultsDictionary(List<long> iterationResults, Dictionary<long, bool> resultDictionary)
		{
			foreach (var number in iterationResults)
			{
				if (resultDictionary.ContainsKey(number))
				{
					resultDictionary[number] = true;
				}
			}
		}

		private static IEnumerable<long> GetUpdatedIterationResults(List<long> iterationResults, List<long> allIterationResults)
		{
			foreach (var iterationResult in iterationResults)
			{
				foreach (var nextIterationResult in GetNextIterationResult(iterationResult))
				{
					if (!allIterationResults.Contains(nextIterationResult))
					{
						yield return nextIterationResult;
					}
				}
			}
		}

		private static IEnumerable<long> GetNextIterationResult(long number)
		{
			yield return number * 2;
			if (((number - 1) % 3) == 0)
			{
				yield return (number - 1) / 3;
			}
		}

		private static bool TryReadNumber(string numberLabel, out int number)
		{
			Console.WriteLine(string.Format("Enter the {0} number:", numberLabel));
			var numberString = Console.ReadLine();
			if (!int.TryParse(numberString, out number))
			{
				Console.WriteLine(string.Format("An error occurred trying to parse the {0} number, execution cannot continue", numberLabel));
				Console.WriteLine("Press any key to exit.");
				Console.ReadKey();
				return false;
			}
			return true;
		}
	}
}
