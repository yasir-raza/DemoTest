package com.yasir.locationtracker.Entities;

import com.google.gson.annotations.SerializedName;

public class Location {
    @SerializedName("L_Id")
    private int L_Id;
    @SerializedName("Longitude")
    private String Longitude;
    @SerializedName("Latitude")
    private String Latitude;
    @SerializedName("U_Id")
    private int U_Id;

    public int getL_Id() {
        return L_Id;
    }

    public void setL_Id(int l_Id) {
        L_Id = l_Id;
    }

    public String getLongitude() {
        return Longitude;
    }

    public void setLongitude(String longitude) {
        Longitude = longitude;
    }

    public String getLatitude() {
        return Latitude;
    }

    public void setLatitude(String latitude) {
        Latitude = latitude;
    }

    public int getU_Id() {
        return U_Id;
    }

    public void setU_Id(int u_Id) {
        U_Id = u_Id;
    }
}
