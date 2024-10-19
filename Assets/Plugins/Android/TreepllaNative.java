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
import com.tree.hybrid.bag.survival.LocalNotificationPublisher;

public class TreepllaNative {
	private static NotificationChannel notificationChannel;
    //get Android Country Code
    public static String nativeGetLanguage(){
        String str = "";
        Locale locale = UnityPlayer.currentActivity.getResources().getConfiguration().locale;
        str = locale.getLanguage();


        Log.d("iso Locale getLanguage", locale.getLanguage());
        Log.d("iso Locale getCountry",locale.getCountry());

        if(str.equals("zh")){
            String country = locale.getCountry();
            if(country.toLowerCase().contains("tw")) return "tw";
        }

        return str;
    }

    public static String nativeGetCountry(){
        String str = "";
        Locale locale = UnityPlayer.currentActivity.getResources().getConfiguration().locale;
        str = locale.getCountry();

        Log.d("iso Locale getCountry",str);

        return str;
    }

    public static void createNotificationChannel()
    {
        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.O){
            NotificationManager notificationManager = (NotificationManager)UnityPlayer.currentActivity.getSystemService(UnityPlayer.currentActivity.NOTIFICATION_SERVICE);
            notificationChannel = new NotificationChannel(
                    "Treeplla Notifi Channel",
                    "Treeplla Channel",
                    NotificationManager.IMPORTANCE_DEFAULT
            );

            notificationChannel.setDescription("Treeplla Push Notification");
            notificationChannel.enableLights(true);
            notificationChannel.setLightColor(Color.GREEN);
            notificationChannel.enableVibration(true);
            notificationChannel.setVibrationPattern(new long[]{100, 200, 100, 200});
            notificationChannel.setLockscreenVisibility(Notification.VISIBILITY_PRIVATE);
            notificationManager.createNotificationChannel(notificationChannel);

        }
    }

    public static void callNotification(int notiId, String notiTitle, String notiDesc, int timeTerm)
    {
    	Log.d("LOCAL_PUSH_TEST", "SendLocalNotifiaction : " + notiId + "- after " + timeTerm);
    	Calendar updateTime = Calendar.getInstance();
        long futureInMillis = updateTime.getTimeInMillis() + (timeTerm * 1000);
        Intent intent = new Intent(UnityPlayer.currentActivity.getApplicationContext(), LocalNotificationPublisher.class);
        intent.putExtra(LocalNotificationPublisher.NOTIFICATION_ID, notiId);
        intent.putExtra(LocalNotificationPublisher.NOTIFICATION_Msg, notiDesc);
        intent.putExtra(LocalNotificationPublisher.NOTIFICATION_Title, notiTitle);
        PendingIntent p1 = PendingIntent.getBroadcast(UnityPlayer.currentActivity.getApplicationContext(), notiId, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager a = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        if(Build.VERSION.SDK_INT >= 23){
            a.setExactAndAllowWhileIdle(AlarmManager.RTC_WAKEUP, futureInMillis, p1);
        } else if (Build.VERSION.SDK_INT >= 19) {
            a.setExact(AlarmManager.RTC_WAKEUP, futureInMillis, p1);
        } else {
            a.set(AlarmManager.RTC_WAKEUP, futureInMillis, p1);
        }
    }

    public static void clearNotification(int[] push_unique_ids)
    {
    	AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        for(int i = 0; i < push_unique_ids.length; ++i){
            PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity.getApplicationContext(), push_unique_ids[i], new Intent(UnityPlayer.currentActivity.getApplicationContext(), LocalNotificationPublisher.class), 0);
            alarmManager.cancel(pendingIntent);
        }
    	NotificationManager nMgr = (NotificationManager) UnityPlayer.currentActivity.getSystemService(Context.NOTIFICATION_SERVICE);
        nMgr.cancelAll();
    }

    public static void Exit()
    {
        UnityPlayer.currentActivity.finishAffinity();
        java.lang.System.exit(0);
    }

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
}
