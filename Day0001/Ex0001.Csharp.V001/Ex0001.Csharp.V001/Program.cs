using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex0001.Csharp.V001
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo keyInfo;
			do
			{
				Console.WriteLine("Enter initial number:");
				var initialNumberString = Console.ReadLine();
				Console.WriteLine("Enter final number:");
				var finalNumberString = Console.ReadLine();

				int initialNumber, finalNumber;
				var parsingSucceeded = int.TryParse(initialNumberString, out initialNumber);
				parsingSucceeded &= int.TryParse(finalNumberString, out finalNumber);

				if (!parsingSucceeded)
				{
					Console.WriteLine("Input is not valid, unable to parse one of the numbers, please make sure the numbers entered as valid integers.");
					return;
				}

				if (initialNumber > finalNumber)
				{
					var auxiliaryNumber = finalNumber;
					finalNumber = initialNumber;
					initialNumber = auxiliaryNumber;
				}

				var maxCycleLenght = GetMaxCycleLenght(initialNumber, finalNumber);

				Console.WriteLine(string.Format("Initial number: {0} | final number: {1} | max cycle lenght: {2}", initialNumber, finalNumber, maxCycleLenght));
				Console.WriteLine("Press Escape to exit, any other key to continue.");
				keyInfo = Console.ReadKey();

			} while (keyInfo.Key != ConsoleKey.Escape);
		}

		static int GetMaxCycleLenght(int minTarget, int maxTarget)
		{
			var maxCycleLenght = 0;
			for (int i = minTarget; i <= maxTarget; i++)
			{
				var currentCycleLenght = GetCycleLenght(i);
				if (currentCycleLenght > maxCycleLenght)
				{
					maxCycleLenght = currentCycleLenght;
				}
			}
			return maxCycleLenght;
		}

		static int GetCycleLenght(long target)
		{
			var originalTarget = target;
			var cycleLenght = 0;
			while (target != 1)
			{
				if (target % 2 == 0)
				{
					target /= 2;
				}
				else
				{
					target = (target * 3) + 1;
				}
				cycleLenght++;
				if (target < 1)
				{
					throw new InvalidOperationException(string.Format("Target number {0} is invalid for this operation, the result of the operation was less than 1", originalTarget));
				}
			}
			return ++cycleLenght;
		}

	}
}
