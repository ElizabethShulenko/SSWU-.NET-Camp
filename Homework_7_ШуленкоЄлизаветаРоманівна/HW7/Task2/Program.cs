using Task2;

class Program
{
    static public void Main(String[] args)
    {
        //American Express
        var AmericanExpressCardNumber = "378282246310005";

        //MasterCard
        var MasterCardNumber = "5555555555554444";

        //Visa
        var VisaCardNumbe = "4222222222222";

        var americanExpressCard = Card.CheckCard(AmericanExpressCardNumber);
        var masterCard = Card.CheckCard(MasterCardNumber);
        var visaCard = Card.CheckCard(VisaCardNumbe);
    }
}