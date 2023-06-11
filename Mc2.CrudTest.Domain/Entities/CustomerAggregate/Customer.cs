
using Core.Domain.ValueObjects;
using Mc2.CrudTest.Domain.Entities.CustomerEvents;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.Entities.CustomerAggregate
{
    public class Customer : BaseEntity<long>, IAggregateRoot
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string BankAccountNumber { get; private set; }
        public bool IsDeleted { get; private set; } = false;


        protected Customer() : base()
        {
        }

        public Customer(string firstname, string lastname, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, string bankAccountNumber) : this()
        {
            Update(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);
        }

        public void Update(string firstname, string lastname, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, string bankAccountNumber)
        {
            // using for concurrency issue
            //if (timeStamp != LastUpdateDate.Ticks)
            //    throw new DomainException("TimeStampIsExpired");

            if (!BankAccountNumberIsValid(bankAccountNumber))
                throw new DomainException("BankAccountNumberIsNotValid");

            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;

            AddDomainEvent(new CustomerRegisteredEvent(Id));

            // if we want to save current user id need a few changes in this section
            //Update(currentUserId);
        }

        public void Delete(Guid currentUserId, long timeStamp)
        {
            // using for concurrency issue
            //if (timeStamp != LastUpdateDate.Ticks)
            //    throw new DomainException("TimeStampIsExpired");

            IsDeleted = true;
            //Update(currentUserId);

            AddDomainEvent(new CustomerDeletedEvent(true));
        }

        private bool BankAccountNumberIsValid(string input)
        {
            // For example 0000-0000-0000-0000
            return Regex.IsMatch(input, "((\\d{4})-){3}\\d{4}");
        }
    }
}
