#include <iostream>
#include "chaiscript.hpp"

int IsItGreaterOrSmaller(int number)
{
	std::cout << "PC guessed this number " << number << " ,Is your number greater/smaller/exact? type g/s/e ";
	std::string TF{ "e" };

	std::cin >> TF;
	std::cout << "\n";

	if (TF == "e") return 0;
	if (TF == "g") return 1;
	if (TF == "s") return -1;

	return 0;
}

int MinNumber()
{
	return 1;
}
int MaxNumber()
{
	return 100;
}


int main(int argc, char** argv)
{
	chaiscript::ChaiScript engine;
	engine.add(chaiscript::fun(&IsItGreaterOrSmaller), "greater_or_smaller");
	engine.add(chaiscript::fun(&MinNumber), "get_min_number");
	engine.add(chaiscript::fun(&MaxNumber), "get_max_number");
	engine.add_global(chaiscript::var(-1), "high");
	engine.add_global(chaiscript::var(-1), "low");
	engine.add_global(chaiscript::var(0), "current_guess");
	auto boxedVal = engine.use("guessAIScript.chaiscript");
	
	std::cout << "Think of your number (1-100): Press to continue";

	std::getchar();

	std::cout << "Computer begins to guess: \n";

	while (true)
	{
		try {
			auto runAI = engine.eval<std::function<int()>>("RunAI");
			auto number = runAI();
			if (number == 999)
			{
				std::cout << "Thanks for playing!\n";
				break;
			}
		}
		catch (const chaiscript::exception::eval_error& e) {
			std::cout << "Error\n" << e.pretty_print() << '\n';
		}

	
	}

	return 0;
}