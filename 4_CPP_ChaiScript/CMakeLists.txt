cmake_minimum_required (VERSION 3.25.1)

project (CppChaiScript)

if (MSVC)
  add_compile_options(/bigobj)
else ()
  add_compile_options(-Wa,-mbig-obj)
endif ()


add_executable (CppChaiScript guessAIScript.chaiscript main.cpp)

add_custom_command(
        TARGET CppChaiScript POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy
                ${CMAKE_SOURCE_DIR}/guessAIScript.chaiscript
                $<TARGET_FILE_DIR:CppChaiScript>)

target_include_directories(CppChaiScript PRIVATE chaiscript)