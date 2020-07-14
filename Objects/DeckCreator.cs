using System;
using System.Collections.Generic;
using System.Linq;

namespace War.Objects
{
    public static class DeckCreator
    { 
        public static Deck<Card> CreateCards(int seed = 0)
        {
            var  cards = new List<Card>(52);
            for(int i = 2; i <= 14; i++)
            {
                foreach(Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = GetDisplayName(i, suit)
                    });
                }
            }
            return Shuffle(cards, seed);
        }

        private static Random _rnd;

        public static Deck<Card> Shuffle(IEnumerable<Card> cards, int seed = 0)
        {
            if (seed == 0)
                seed = DateTime.Now.Millisecond;
            List<Card> transformedCards = cards.ToList();
            //First, shuffle the existing cards using Fisher-Yates

            if (_rnd == null)
                    _rnd = new Random(seed);

            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick an item which has not been shuffled
                int k = _rnd.Next(n + 1);

                //Step 3: Swap the selected item with the last "unstruck" letter in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            return new Deck<Card>(transformedCards);
            }




        private static string GetDisplayName(int value, Suit suit)
        {
            string valueDisplay = "";

            if(value >=2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if(value == 11)
            {
                valueDisplay = "Jack";
            }
            else if(value == 12)
            {
                valueDisplay = "Queen";
            }
            else if(value == 13)
            {
                valueDisplay = "King";
            }
            else if(value == 14)
            {
                valueDisplay = "Ace";
            }

            return valueDisplay + " of " + Enum.GetName(typeof(Suit), suit);
        }
    }
}
