using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class TreepllaNative
{
#if UNITY_ANDROID
    private static AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.TreepllaNative");
    static AndroidJavaClass versionInfo = new AndroidJavaClass("android.os.Build$VERSION");
#elif UNITY_IOS
    [DllImport("__Internal")]
    public static extern string getDeviceLanguage();

    [DllImport("__Internal")]
    public static extern string getDeviceCountry();

    [DllImport("__Internal")]
    public static extern void vibrate();
#endif


    public static string getLocaleCode()
    {
        string locale = string.Empty;
#if UNITY_ANDROID && !UNITY_EDITOR
        locale = javaClass.CallStatic<string>("nativeGetLanguage");
#elif UNITY_IOS && !UNITY_EDITOR
        locale = getDeviceLanguage();
#else
        locale = "ko";
#endif
        Debug.Log($"cur Locale is {locale}");
        return locale;
    }

    public static bool IsLow()
    {
        var low = false;
#if UNITY_ANDROID && !UNITY_EDITOR
        var str = versionInfo.GetStatic<int>("SDK_INT");
        low = str < 30; // 30이 android 11        
#endif
        if (!low)
        {
            var ramSize = (float)SystemInfo.systemMemorySize / 1000f;
            if (ramSize <= 2f)
            {
                low = true;
            }
        }
        return low;
    }

    public static string getLocaleCountry()
    {
        string locale = string.Empty;
#if UNITY_ANDROID && !UNITY_EDITOR
        locale = javaClass.CallStatic<string>("nativeGetCountry");
#elif UNITY_IOS && !UNITY_EDITOR
        locale = getDeviceCountry();
#else
        locale = "KR";
#endif
        Debug.Log($"cur Country is {locale}");
        return locale;
    }

    public static void AndroidNotificationChannelCreate()
    {
#if UNITY_ANDROID
        javaClass.CallStatic("createNotificationChannel");
#endif
    }

    public static void ClearNotification(int[] pushIDs)
    {
#if UNITY_ANDROID
        javaClass.CallStatic("clearNotification", pushIDs);
#endif
    }

    public static void AndroidLocalNotification(int notiId, double remainTime, string title, string context)
    {
#if UNITY_ANDROID
        javaClass.CallStatic("callNotification", notiId, title, context, (int)remainTime);
#endif
    }

    public static void Vibrate()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            javaClass.CallStatic("vibrate", 1);
#elif UNITY_IOS && !UNITY_EDITOR
            vibrate();
#else
        //Handheld.Vibrate();
#endif
    }

    public static void Exit()
    {
#if UNITY_ANDROID
        javaClass.CallStatic("Exit");
#endif
    }
}


public class AndroidVersion
{
    static AndroidJavaClass versionInfo;

    static AndroidVersion()
    {
        versionInfo = new AndroidJavaClass("android.os.Build$VERSION");
    }

    public static string BASE_OS
    {
        get
        {
            return versionInfo.GetStatic<string>("BASE_OS");
        }
    }

    public static string CODENAME
    {
        get
        {
            return versionInfo.GetStatic<string>("CODENAME");
        }
    }

    public static string INCREMENTAL
    {
        get
        {
            return versionInfo.GetStatic<string>("INCREMENTAL");
        }
    }

    public static int PREVIEW_SDK_INT
    {
        get
        {
            return versionInfo.GetStatic<int>("PREVIEW_SDK_INT");
        }
    }

    public static string RELEASE
    {
        get
        {
            return versionInfo.GetStatic<string>("RELEASE");
        }
    }

    public static string SDK
    {
        get
        {
            return versionInfo.GetStatic<string>("SDK");
        }
    }

    public static int SDK_INT
    {
        get
        {
            return versionInfo.GetStatic<int>("SDK_INT");
        }
    }

    public static string SECURITY_PATCH
    {
        get
        {
            return versionInfo.GetStatic<string>("SECURITY_PATCH");
        }
    }

    public static string ALL_VERSION
    {
        get
        {
            string version = "BASE_OS: " + BASE_OS + "\n";
            version += "CODENAME: " + CODENAME + "\n";
            version += "INCREMENTAL: " + INCREMENTAL + "\n";
            version += "PREVIEW_SDK_INT: " + PREVIEW_SDK_INT + "\n";
            version += "RELEASE: " + RELEASE + "\n";
            version += "SDK: " + SDK + "\n";
            version += "SDK_INT: " + SDK_INT + "\n";
            version += "SECURITY_PATCH: " + SECURITY_PATCH;

            return version;
        }
    }
}