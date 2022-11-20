namespace Task2
{
    public class Card
    {
        public static readonly string[] _americanExpressCodes = { "34", "37" };
        public static readonly int[] _americanExpressLengths = { 15 };

        public static readonly string[] _masterCardCodes = { "51", "52", "53", "54", "55" };
        public static readonly int[] _masterCardLengths = { 16 };

        public static readonly string[] _visaCodes = { "4" };
        public static readonly int[] _visaLengths = { 13, 16 };

        public enum CardTypes
        {
            AmericanExpress,
            MasterCard,
            Visa
        }

        public static CardTypes? CheckCard(string card)
        {
            if (!IsCardValid(card))
            {
                return null;
            }

            var cardCode = card.Substring(0, 2);

            if (IsAmericanExpress(card))
            {
                return CardTypes.AmericanExpress;
            }

            if (IsMasterCard(card))
            {
                return CardTypes.MasterCard;
            }

            if (IsVisa(card))
            {
                return CardTypes.Visa;
            }

            return null;
        }

        public static bool IsCardValid(string card)
        {
            if (!card.All(char.IsDigit))
            {
                return false;
            }

            var arr = card.Select(m => Int32.Parse(m.ToString())).ToArray();

            return LoonaAlgorithm.LoonasCheck(arr);
        }

        private static bool IsAmericanExpress(string card)
        {
            return CheckCardLength(card, _americanExpressLengths) && CheckCardCode(card, _americanExpressCodes);
        }

        private static bool IsMasterCard(string card)
        {
            return CheckCardLength(card, _masterCardLengths) && CheckCardCode(card, _masterCardCodes);
        }

        private static bool IsVisa(string card)
        {
            return CheckCardLength(card, _visaLengths) && CheckCardCode(card, _visaCodes);
        }

        private static bool CheckCardLength(string card, int[] allowableLengths)
        {
            bool isValidLength = false;

            foreach (var cardLength in allowableLengths)
            {
                if (card.Length == cardLength)
                {
                    isValidLength = true;
                }
            }

            return isValidLength;
        }

        private static bool CheckCardCode(string card, string[] allowableCodes)
        {
            bool isValidCode = false;

            foreach (var cardCode in allowableCodes)
            {
                if (card.StartsWith(cardCode))
                {
                    isValidCode = true;
                }
            }

            return isValidCode;
        }
    }
}
