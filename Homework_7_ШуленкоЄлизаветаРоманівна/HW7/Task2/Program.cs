using Task2;

class Program
{
    static public void Main(String[] args)
    {
        //American Express
        var AmericanExpressCardNumber = 378282246310005;

        //MasterCard
        var MasterCardNumber = 5555555555554444;

        //Visa
        var VisaCardNumbe = 4222222222222;

        var AmericanExpressCardIsValid = LoonaAlgorithm.IsValid(AmericanExpressCardNumber);
        var MasterCardIsValid = LoonaAlgorithm.IsValid(MasterCardNumber);
        var VisaCardIsValid = LoonaAlgorithm.IsValid(VisaCardNumbe);

    }
}