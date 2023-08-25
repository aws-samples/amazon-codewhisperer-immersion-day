package com.amazon.aws.customerapi;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class CustomerapiApplicationTests {
	
	@Autowired
	CustomerRepository repository;
	
	// test create and save new customer to repository and then retreive it and validate name
	@Test
	void testCreateAndSaveCustomer() {
		Customer customer = new Customer();
		customer.setFirstName("XXXX");
		customer.setLastName("XXX");
		customer.setEmail("XXXXXXXXXXXXXXXXXX");
		repository.save(customer);
		Customer customerRetrieved = repository.findById(customer.getId()).get();
		assert(customerRetrieved.getFirstName().equals("XXXX"));
	}

}

