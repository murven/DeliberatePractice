// Ex0001.Cpp.V001.cpp : main project file.

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

using namespace System;



public ref class ThreePlusOneProblem
{
public: 
	static int GetCycleLength(int target)
	{
		int cycleLength = 1;
		while(target > 1)
		{
			if(target % 2 == 0)
			{
				target = target / 2;
			}
			else
			{
				target = (target * 3) + 1;
			}
			cycleLength++;
		}
		return cycleLength;
	}

public:
	static int GetMaxCycleLength(int initialNumber, int finalNumber)
	{
		int maxCycleLength = 1;
		for(int i = initialNumber; i <= finalNumber; i++)
		{
			int currentCycleLength = ThreePlusOneProblem::GetCycleLength(i);
			if(currentCycleLength > maxCycleLength)
			{
				maxCycleLength = currentCycleLength;
			}
		}
		return maxCycleLength;
	}
};

int main(array<System::String ^> ^args)
{
    Console::WriteLine("Enter two numbers, separated by a space:");
	System::String ^ inputString = Console::ReadLine();
	System::String ^ delimStr = " ";
    array<wchar_t>^ delimiter = delimStr->ToCharArray();
    array<String^>^ split = inputString->Split(delimiter);
	String^ initialNumberString = split[0];
	String^ finalNumberString = split[1];
	int initialNumber; 
	int finalNumber;
	if(!Int32::TryParse(initialNumberString, initialNumber))
	{
		Console::WriteLine(System::String::Format("Invalid input, {0} is not a number.", initialNumberString));
		Console::WriteLine("Press any key to exit.");
		Console::ReadKey();
		return -1;
	}
	if(!Int32::TryParse(finalNumberString, finalNumber))
	{
		Console::WriteLine(System::String::Format("Invalid input, {0} is not a number.", finalNumberString));
		Console::WriteLine("Press any key to exit.");
		Console::ReadKey();
		return -1;
	}
	if(initialNumber > finalNumber)
	{
		int auxiliaryNumber = initialNumber;
		initialNumber = finalNumber;
		finalNumber = auxiliaryNumber;
	}
	int maxCycleLength = ThreePlusOneProblem::GetMaxCycleLength(initialNumber, finalNumber);
	Console::WriteLine(System::String::Format("{0} {1} {2}", initialNumber, finalNumber, maxCycleLength));
	Console::WriteLine("Press any key to exit.");
	Console::ReadKey();
    return 0;
}
