package com.yasir.locationtracker.Service;

import retrofit2.Call;
import retrofit2.http.GET;

public interface UserService {

    @GET("GetUser")
    Call<String> testUser();
    @GET("test")
    Call<String> test();
}
