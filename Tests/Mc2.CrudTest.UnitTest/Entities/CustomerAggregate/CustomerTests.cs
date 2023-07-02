using Core.Domain.ValueObjects;
using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Mc2.CrudTest.UnitTest.SeedWork;

namespace Mc2.CrudTest.UnitTest.Entities.CustomerAggregate
{
    public class CustomerTests
    {
        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string firstname = "firstname";
            string lastname = "lastname";
            DateTime dateOfBirth = default;
            MobileNumber phoneNumber = "0123456789";
            Email email = "abc@abc.com";
            string bankAccountNumber = "0000-0000-0000-0000";

            // for check Customer is unique
            //var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            //customerUniquenessChecker.IsUnique(email).Returns(true);

            var customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);

            // Act
            customer.Update(
                firstname,
                lastname,
                dateOfBirth,
                phoneNumber,
                email,
                bankAccountNumber);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string firstname = "firstname";
            string lastname = "lastname";
            DateTime dateOfBirth = default;
            MobileNumber phoneNumber = "09191234567";
            Email email = "abc@abc.com";
            string bankAccountNumber = "0000-0000-0000-0000";
            var customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);
            Guid currentUserId = default;
            long timeStamp = 0;

            // Act
            customer.Delete(
                currentUserId,
                timeStamp);

            // Assert
            Assert.True(false);
        }


        [Fact]
        public void Validate_PhoneNumber_Should_Return_True()
        {
            // Arrange
            string firstname = "firstname";
            string lastname = "lastname";
            DateTime dateOfBirth = default;
            string phoneNumber = "+989121234567";
            Email email = "abc@abc.com";
            string bankAccountNumber = "0000-0000-0000-0000";
            var customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);


            // Assert
            Assert.Equal(phoneNumber, customer.PhoneNumber);
        }
    }
}
