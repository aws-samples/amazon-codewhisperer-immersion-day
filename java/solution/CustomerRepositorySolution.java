package com.amazon.aws.customerapi;
import java.util.Optional;

//import to create repository
import org.springframework.data.repository.CrudRepository;

// repository class for Customer with find by email, first name, last name and id fields
public interface CustomerRepository extends CrudRepository<Customer, Long> {
	
	Optional<Customer> findById(Long id);

	// additional find by methods for email, first name and last name
	Customer findByEmail(String email);
	
	Customer findByFirstName(String firstName);
	
	Customer findByLastName(String lastName);
	
	
	
}