#if !defined(PROGRAM_EXPORT)
#define PROGRAM_EXPORT /* NOTHING */

#if defined(WIN32) || defined(WIN64)
#undef PROGRAM_EXPORT
#if defined(PROGRAM_EXPORTS)
#define PROGRAM_EXPORT __declspec(dllexport)
#else
#define PROGRAM_EXPORT __declspec(dllimport)
#endif // defined(PROGRAM_EXPORTS)
#endif // defined(WIN32) || defined(WIN64)

#if defined(__GNUC__) || defined(__APPLE__) || defined(LINUX)
#if defined(PROGRAM_EXPORTS)
#undef PROGRAM_EXPORT
#define PROGRAM_EXPORT __attribute__((visibility("default")))
#endif // defined(PROGRAM_EXPORTS)
#endif // defined(__GNUC__) || defined(__APPLE__) || defined(LINUX)

#endif // !defined(PROGRAM_EXPORT)