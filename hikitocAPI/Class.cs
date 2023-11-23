//using System;
//using System.ComponentModel.DataAnnotations;

//public class ChosenCreditCardAttribute : ValidationAttribute
//{
//    private readonly string _chosenCreditCard;

//    public ChosenCreditCardAttribute(string chosenCreditCard)
//    {
//        _chosenCreditCard = chosenCreditCard;
//    }

//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        if (value is string creditCard && !string.Equals(creditCard, _chosenCreditCard, StringComparison.OrdinalIgnoreCase))
//        {
//            return new ValidationResult("Invalid credit card. Please use the chosen credit card for this offer.");
//        }

//        return ValidationResult.Success;
//    }
//}

//public class LimitedCreditAmountAttribute : ValidationAttribute
//{
//    private const decimal MaxCreditAmount = 1000;

//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        if (value is decimal creditAmount && creditAmount > MaxCreditAmount)
//        {
//            return new ValidationResult($"Credit amount must be limited to ${MaxCreditAmount} for this offer.");
//        }

//        return ValidationResult.Success;
//    }
//}

//public class LimitedTimeOfferAttribute : ValidationAttribute
//{
//    private readonly DateTime _expirationDate;

//    public LimitedTimeOfferAttribute(int offerDurationInMonths)
//    {
//        _expirationDate = DateTime.Now.AddMonths(offerDurationInMonths);
//    }

//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        if (DateTime.Now > _expirationDate)
//        {
//            return new ValidationResult("This limited-time offer has expired.");
//        }

//        return ValidationResult.Success;
//    }
//}

//public class CreditCardTransaction
//{
//    [ChosenCreditCard("MyPreferredCard")]
//    public string CreditCardUsed { get; set; }

//    [LimitedCreditAmount]
//    public decimal CreditAmount { get; set; }

//    [LimitedTimeOffer(1)]
//    public DateTime TransactionDate { get; set; }
//}
