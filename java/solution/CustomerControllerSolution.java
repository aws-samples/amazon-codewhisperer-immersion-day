package com.amazon.aws.customerapi;
//import to create rest controller
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseStatus;

import java.util.Optional;

import org.springframework.http.HttpStatus;

// Customer rest controller with Get, Create, Delete and Update methods using the Customer repository
// and customer as the path mapping
@RestController
@RequestMapping(path = "/customer")
public class CustomerController {
    private final CustomerRepository customerRepository;

	public CustomerController(CustomerRepository customerRepository) {
		this.customerRepository = customerRepository;
	}

	// Get method to return all customers
	@RequestMapping(method = RequestMethod.GET)
	public @ResponseBody Iterable<Customer> getAllCustomers() {
		return customerRepository.findAll();
	}

	// Get method to return a single customer
	@RequestMapping(value = "/{id}", method = RequestMethod.GET)
	public @ResponseBody Optional<Customer> getCustomer(@PathVariable("id") Long id) {
		return customerRepository.findById(id);
	}

	// Create method to create a new customer
	@RequestMapping(method = RequestMethod.POST)
	@ResponseStatus(HttpStatus.CREATED)
	public @ResponseBody Customer createCustomer(@RequestBody Customer customer) {
		return customerRepository.save(customer);
	}

	// method to delete a customer
	@RequestMapping(value = "/{id}", method = RequestMethod.DELETE)
	@ResponseStatus(HttpStatus.NO_CONTENT)
	public void deleteCustomer(@PathVariable("id") Long id) {
        customerRepository.deleteById(id);
	}

    // method to update a customer
    @RequestMapping(value = "/{id}", method = RequestMethod.PUT)
    @ResponseStatus(HttpStatus.OK)
    public @ResponseBody Customer updateCustomer(@PathVariable("id") Long id, @RequestBody Customer customer) {
        customer.setId(id);
        return customerRepository.save(customer);

    }

}
