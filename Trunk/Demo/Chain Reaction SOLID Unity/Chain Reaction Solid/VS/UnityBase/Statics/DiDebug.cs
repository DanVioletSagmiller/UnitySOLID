using System;

namespace UnityBase.Statics
{
    public class DiDebug : IDebug
    {
        public bool developerConsoleVisible
        {
            get => UnityEngine.Debug.developerConsoleVisible;
            set => UnityEngine.Debug.developerConsoleVisible = value;
        }

        public bool isDebugBuild => UnityEngine.Debug.isDebugBuild;

        public void Assert(bool condition)
        {
            UnityEngine.Debug.Assert(condition);
        }

        public void Assert(bool condition, object message)
        {
            UnityEngine.Debug.Assert(condition, message);
        }

        public void Assert(bool condition, string message)
        {
            UnityEngine.Debug.Assert(condition, message);
        }

        public void AssertFormat(bool condition, string format, object[] args)
        {
            UnityEngine.Debug.AssertFormat(condition, format, args);
        }

        public void Break()
        {
            UnityEngine.Debug.Break();
        }

        public void ClearDeveloperConsole()
        {
            UnityEngine.Debug.ClearDeveloperConsole();
        }

        public void DebugBreak()
        {
            UnityEngine.Debug.DebugBreak();
        }

        public void Log(object message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void LogAssertion(object message)
        {
            UnityEngine.Debug.LogAssertion(message);
        }

        public void LogAssertionFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogAssertionFormat(format, args);
        }

        public void LogError(object message)
        {
            UnityEngine.Debug.LogError(message);
        }

        public void LogErrorFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogErrorFormat(format, args);
        }

        public void LogException(Exception exception)
        {
            UnityEngine.Debug.LogException(exception);
        }

        public void LogFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogFormat(format, args);
        }

        public void LogWarning(object message)
        {
            UnityEngine.Debug.LogWarning(message);
        }

        public void LogWarningFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogWarningFormat(format, args);
        }
    }
}
