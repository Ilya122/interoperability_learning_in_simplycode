cmake_minimum_required (VERSION 3.25.1)

project (CppChaiScript)

if (MSVC)
  add_compile_options(/bigobj)
else ()
  add_compile_options(-Wa,-mbig-obj)
endif ()

add_executable (CppChaiScript main.cpp)

target_include_directories(CppChaiScript PRIVATE chaiscript)
