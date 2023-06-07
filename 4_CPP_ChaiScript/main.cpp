#include <iostream>
#include "chaiscript.hpp"

void SayHi(std::string name)
{
	std::cout << "Hello " << name << "\n";
}
void Exit()
{
	std::exit(0);
}

int main(int argc, char** argv)
{
	chaiscript::ChaiScript engine;
	engine.add(chaiscript::fun(&SayHi), "say_hi");
	engine.add(chaiscript::fun(&Exit), "exit");

	while (true)
	{
		std::cout << "Write your code: \n";

		std::string userCode;
		std::cin >> userCode;

		engine.eval(userCode);
		std::cout << "---------\n";
	}

	return 0;
}