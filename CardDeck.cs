using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAP_Assignment1_FilterCards
{
    internal class CardDeck
    {
        private List<Card> _deck;

        // Using ReadOnlyCollection to prevent manipulation from outside
        // since using get with a List still allows using List methods.
        public ReadOnlyCollection<Card> Deck
        {
            get { return _deck.AsReadOnly(); }
        }

        public CardDeck()
        {
            _deck = new List<Card>();
        }

        public void AddCard(CardSuit cardSuit, CardValue cardValue)
        {
            Card card = new Card(cardSuit, cardValue);
            _deck.Add(card);
        }

        /// <summary>
        /// Filter Cards with specified predicate.
        /// </summary>
        /// <param name="filter">The predicate filter to use.</param>
        /// <returns>A filtered ReadOnlyCollection of Cards.</returns>
        public ReadOnlyCollection<Card> FilterCardGame(Predicate<Card> filter)
        {
            List<Card> filteredDeck = new();
            foreach (Card card in _deck)
            {
                if (filter(card)) filteredDeck.Add(card);
            }
            return filteredDeck.AsReadOnly();
        }
    }
}
