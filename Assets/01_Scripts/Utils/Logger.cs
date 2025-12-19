

//define in unity engine = edit > project settings > player > other settings > scripting define symbols


using System.Diagnostics;

public class Logger {   //create wrapping class

    //normal log
    [Conditional("DEV_VER")]
    public static void Log(string msg)
    {
        //log generate time, log massage
        UnityEngine.Debug.LogFormat($"[{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] {msg}");
    }

    //warning log
    [Conditional("DEV_VER")]
    public static void LogWarning(string msg)
    {
        //log generate time, log massage
        UnityEngine.Debug.LogFormat($"[{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] {msg}");
    }

    //error log
    [Conditional("DEV_VER")]
    public static void LogError(string msg)
    {
        //log generate time, log massage
        UnityEngine.Debug.LogFormat($"[{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] {msg}");
    }

}
