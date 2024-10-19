package com.unity3d.player;
import com.unity3d.player.UnityPlayer;
import android.util.Log;
import android.content.Intent;
import android.content.Context;
import java.util.Locale;
import android.app.AlarmManager;
import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import java.util.Calendar;
import android.os.Build;
import android.os.Vibrator;
import android.os.VibrationEffect;
import android.graphics.Color;

public class TreepllaNative {

    public static void vibrate(int milliseconds)
    {
        Vibrator v = (Vibrator) UnityPlayer.currentActivity.getSystemService(Context.VIBRATOR_SERVICE);
        if(v == null)
            return;
        
        v.cancel();
        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q)
        {
            VibrationEffect vibrationEffect = VibrationEffect.createPredefined(VibrationEffect.EFFECT_TICK);
            v.vibrate(vibrationEffect);
        }
        else if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) 
        {
            v.vibrate(VibrationEffect.createOneShot(milliseconds, VibrationEffect.DEFAULT_AMPLITUDE));
        } 
        else 
        {
            //deprecated in API 26 
            v.vibrate(milliseconds);
        }
    }


    
    public static String nativeGetCountry(){
        String str = "";
        Locale locale = UnityPlayer.currentActivity.getResources().getConfiguration().locale;
        str = locale.getCountry();

        Log.d("iso Locale getCountry",str);

        return str;
    }
}
