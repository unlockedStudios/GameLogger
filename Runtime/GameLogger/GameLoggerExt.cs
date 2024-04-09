using Serilog;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnlockedStudios.GameLogger.Logger
{
    public static class GameLoggerExt
    {
        public static ILogger Here(this ILogger logger,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            string fileNameWithExt = sourceFilePath.Substring(sourceFilePath.LastIndexOf('\\') + 1);
            string[] fileName = fileNameWithExt.Split('.');
            return logger
                .ForContext("MethodName", methodName)
                .ForContext("FileName", fileName[0])
                .ForContext("FilePath", sourceFilePath)
                .ForContext("LineNumber", sourceLineNumber);
        }
    }
}