using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerManagerStepDefinitions
    {
        [Given(@"I have a new customer with this details")]
        public void GivenIHaveANewCustomerWithThisDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"create the customer")]
        public void WhenCreateTheCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be saved in the database")]
        public void ThenTheCustomerShouldBeSavedInTheDatabase()
        {
            throw new PendingStepException();
        }

        [Given(@"there is a customer")]
        public void GivenThereIsACustomer(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"update the customer's firstname to ""([^""]*)""")]
        public void WhenUpdateTheCustomersFirstnameTo(string ebi)
        {
            throw new PendingStepException();
        }

        [Then(@"customer's name should be updated in the database")]
        public void ThenCustomersNameShouldBeUpdatedInTheDatabase()
        {
            throw new PendingStepException();
        }

        [When(@"delete the customer")]
        public void WhenDeleteTheCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be deleted from the database")]
        public void ThenTheCustomerShouldBeDeletedFromTheDatabase()
        {
            throw new PendingStepException();
        }

        [Given(@"there is a list of customers")]
        public void GivenThereIsAListOfCustomers()
        {
            throw new PendingStepException();
        }

        [When(@"get all")]
        public void WhenGetAll()
        {
            throw new PendingStepException();
        }

        [Then(@"return list of customers")]
        public void ThenReturnListOfCustomers()
        {
            throw new PendingStepException();
        }
    }
}
