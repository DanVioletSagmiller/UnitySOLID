using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityBase.Statics
{
    public interface IDebug
    {
        void Break();
        void DebugBreak();
        void Log(System.Object message);
        void LogFormat(string format, System.Object[] args);
        void LogError(System.Object message);
        void LogErrorFormat(string format, System.Object[] args);
        void ClearDeveloperConsole();
        void LogException(System.Exception exception);
        void LogWarning(System.Object message);
        void LogWarningFormat(string format, System.Object[] args);
        void Assert(bool condition);
        void Assert(bool condition, System.Object message);
        void Assert(bool condition, string message);
        void AssertFormat(bool condition, string format, System.Object[] args);
        void LogAssertion(System.Object message);
        void LogAssertionFormat(string format, System.Object[] args);
        bool developerConsoleVisible { get; set; }
        bool isDebugBuild { get; }
    }
}
