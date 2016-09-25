using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Ace = 1,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit suit;
        public Rank rank;

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        private Card()
        {

        }

        public override string ToString()
        {
            return "The " + rank +" of "+ suit +"s";
        }
    }


    public class Deck
    {
        private Card[] m_Cards;

        public Deck()
        {
            m_Cards = new Card[52];

            for (int suitVal = 0;suitVal<4;suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    m_Cards[suitVal*13 +rankVal-1] = new Card((Suit)suitVal,(Rank)rankVal);
                }
            }
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum>=0 && cardNum<=51)
                return m_Cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum",cardNum,"Value must between 0 and 51."));
        }

        public void Shuffle()
        {
            Card[] newDeck = new Card[52];
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();

            for (int i = 0; i < 52;i++ )
            {
                int destCard = 0;
                bool foundCard = false;
                while (!foundCard)
                {
                    destCard = sourceGen.Next(52);
                    if (!assigned[destCard])
                        foundCard = true;
                }
                assigned[destCard] = true;
                newDeck[destCard] = m_Cards[i];
            }
            newDeck.CopyTo(m_Cards,0);
        }
    }



}
