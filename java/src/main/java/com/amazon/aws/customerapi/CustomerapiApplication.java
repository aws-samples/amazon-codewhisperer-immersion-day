package com.amazon.aws.customerapi;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

//load values into database
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;


@SpringBootApplication
public class CustomerAPIApplication {

	public static void main(String[] args) {
		SpringApplication.run(CustomerAPIApplication.class, args);
	}

	@Bean
	public CommandLineRunner loadData(CustomerRepository repository) {
		return (args) -> {

		

			//get all customers from database and print to console
			for (Customer customer : repository.findAll()) {
				System.out.println(customer);
			}
		};

	}
}
