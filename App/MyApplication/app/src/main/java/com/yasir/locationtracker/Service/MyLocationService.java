package com.yasir.locationtracker.Service;

import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.location.Location;
import android.os.IBinder;
import android.widget.Toast;

import com.google.android.gms.location.LocationResult;
import com.yasir.locationtracker.MainActivity;

public class MyLocationService extends BroadcastReceiver {

    public static final String Action_Process_Update = "com.yasir.locationtracker.Service.UPDATE_LOCATION";
    @Override
    public void onReceive(Context context, Intent intent) {
    if(intent != null)
    {
        final String action = intent.getAction();
        if(Action_Process_Update.equals(action))
        {
            LocationResult result = LocationResult.extractResult(intent);
            if(result != null)
            {
                Location location = result.getLastLocation();
                String locatiion_string = new StringBuilder(""+location.getLatitude())
                        .append("/")
                        .append(location.getLongitude())
                        .toString();
                try {
                    MainActivity.getInstance().UpdateTextView(locatiion_string);
                }
                catch (Exception ex)
                {
                    Toast.makeText(context, locatiion_string, Toast.LENGTH_SHORT).show();
                }

            }
        }
    }
    }
}
