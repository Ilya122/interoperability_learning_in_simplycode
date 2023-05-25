import cppyy

# Copy programLib.hpp,programExport.hpp and programLib.dll to the root folder of PyCalculator

cppyy.include('programExport.hpp')
cppyy.include('programLib.hpp')  
cppyy.load_library('programLib.dll')

from cppyy.gbl import Calculator

calc = Calculator()

result = calc.Calculate(2,3)
print(f'Result: {result}')