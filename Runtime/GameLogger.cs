using Serilog;
using Serilog.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnlockedStudios.Logger
{
    public class GameLogger : IGameLogger
    {
        //private 
        private Serilog.ILogger _logRef;
        private string _outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{ThreadId}] [LN:{LineNumber}] ({FileName}.{MethodName}) {Message}{NewLine}{Exception}";
        private bool isFileLoggerEnabled = false;

        private string _fileName = "\\logs\\GameLogger.log";

        public GameLogger()
        {
            CreateFileLogger();
        }

        private void CreateFileLogger()
        {
            string filePath = Directory.GetCurrentDirectory() + _fileName;
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .Enrich.FromLogContext()
                        .WriteTo.File(filePath
                            , rollingInterval: RollingInterval.Day
                            , retainedFileCountLimit: 5
                            , outputTemplate: _outputTemplate
                            , rollOnFileSizeLimit: true)
                        .CreateLogger();

            _logRef = Log.Logger;
        }

        public void EnableFileLogger(bool enable = true)
        {
            isFileLoggerEnabled = enable;
            if (_logRef == null)
            {
                CreateFileLogger();
                _logRef.IsEnabled(Serilog.Events.LogEventLevel.Information);
            }
            else if (!enable)
                _logRef = null;
        }

        public void LogInfo(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if(_logRef != null)
            {
                _logRef.Here(methodName, sourceFilePath, sourceLineNumber)
                    .Information("{Message}", message);
            }
        }

        public void LogDebug(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if(_logRef != null)
            {
                _logRef.Here(methodName, sourceFilePath, sourceLineNumber)
                    .Debug("{Message}", message); ;
            }
        }

        public void LogError(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if(_logRef != null)
            {
                _logRef.Here(methodName, sourceFilePath, sourceLineNumber)
                    .Error("{Message}", message);
            }
        }

        public void LogError(string message, Exception ex,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if(_logRef != null)
            {
                _logRef.Here(methodName, sourceFilePath, sourceLineNumber)
                    .Error("{Exception}: {Message}", ex.Message, message);
            }
        }

        public void LogWarning(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if(_logRef != null)
            {
                _logRef.Here(methodName, sourceFilePath, sourceLineNumber)
                    .Warning("{Message}", message);
            }
        }
    }
}