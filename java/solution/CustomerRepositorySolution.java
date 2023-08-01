package com.amazon.aws.customerapi;
import java.util.Optional;

//import to create repository
import org.springframework.data.repository.CrudRepository;

// repository class for Customer with find by email, first name, last name and id fields
public interface CustomerRepository extends CrudRepository<Customer, Long> {
	
	Customer findByEmail(String email);
	
	Customer findByFirstName(String firstName);
	
	Customer findByLastName(String lastName);
	
	Optional<Customer> findById(Long id);
	
}