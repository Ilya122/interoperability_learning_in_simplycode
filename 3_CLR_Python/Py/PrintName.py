import sys
import clr
from clr_loader import get_coreclr
from pythonnet import set_runtime

rt = get_coreclr(runtime_config=r'MyLib.runtimeconfig.json')
set_runtime(rt)

result = clr.FindAssembly("MyLib")
#print('FindAssembly returned:', result)
result = clr.AddReference("MyLib")
#print('AddReference returned:', result)

from MyLib import NameGenerator


generate = NameGenerator()

name = generate.GenerateName()

print(f'New name should be {name}')