package com.amazon.aws.customerapi;
import java.util.Optional;

//import to create repository
import org.springframework.data.repository.CrudRepository;

// repository class for Customer with find by id methods
public interface CustomerRepository extends CrudRepository<Customer, Long> {

    Optional<Customer> findById(Long id);

    // CODEWHISPERER COMMENT FOR ADDITIONAL FIND BY METHODS


}