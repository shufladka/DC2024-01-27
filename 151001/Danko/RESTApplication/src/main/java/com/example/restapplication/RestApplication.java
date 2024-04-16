package com.example.restapplication;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.kafka.annotation.EnableKafka;

@SpringBootApplication
@EnableKafka
public class RestApplication {
    public static void main(String[] args) {
        SpringApplication.run(RestApplication.class, args);
    }
}
