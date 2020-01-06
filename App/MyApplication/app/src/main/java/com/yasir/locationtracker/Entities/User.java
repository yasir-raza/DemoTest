package com.yasir.locationtracker.Entities;

import com.google.gson.annotations.SerializedName;

public class User {
    @SerializedName("U_Id")
    private int U_Id;
    @SerializedName("Name")
    private String Name;
    @SerializedName("Password")
    private String Password;

    public int getId() {
        return U_Id;
    }

    public void setId(int id) {
        U_Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }
}
