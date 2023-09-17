using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SLAP_Assignment1_FilterCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CardDeck cardDeck;

        public MainWindow()
        {
            InitializeComponent();
            cardDeck = new();
            CreateDeck();
            RbAll.IsChecked = true;
        }

        private void CreateDeck()
        {
            foreach (CardSuit cardSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    cardDeck.AddCard(cardSuit, cardValue);
                }
            }
        }

        /// <summary>
        /// Event handler for radiobuttons that calls the filter method in CardDeck
        /// and shows a filtered list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "RbAll") DgvCards.ItemsSource = cardDeck.Deck;
            if (rb.Name == "RbClubs") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterClubs);
            if (rb.Name == "RbDiamonds") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterDiamonds);
            if (rb.Name == "RbHearts") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterHearts);
            if (rb.Name == "RbSpades") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterSpades);
            if (rb.Name == "RbPicture") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterPictureCards);
            if (rb.Name == "RbNonpicture") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterNonPictureCards);
            if (rb.Name == "RbRed") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterRedCards);
            if (rb.Name == "RbBlack") DgvCards.ItemsSource = cardDeck.FilterCardGame(FilterBlackCards);
        }

        // Filter methods for use with Predicate
        internal bool FilterClubs(Card card) => card.Suit == CardSuit.Clubs;
        internal bool FilterDiamonds(Card card) => card.Suit == CardSuit.Diamonds;
        internal bool FilterHearts(Card card) => card.Suit == CardSuit.Hearts;
        internal bool FilterSpades(Card card) => card.Suit == CardSuit.Spades;
        internal bool FilterPictureCards(Card card) => (int)card.Value > 9;
        internal bool FilterNonPictureCards(Card card) => (int)card.Value < 10;
        internal bool FilterRedCards(Card card) => card.Suit == CardSuit.Diamonds || card.Suit == CardSuit.Hearts;
        internal bool FilterBlackCards(Card card) => card.Suit == CardSuit.Clubs || card.Suit == CardSuit.Spades;

        /// <summary>
        /// Eventhandler for when selection changes in the DataGrid and displays
        /// the selected Card in a textbox. Mostly to use the required
        /// ToString() method in Card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgvCards.SelectedItem != null)
            {
                // Get the selected item (which corresponds to the clicked row)
                Card selectedCard = (Card)DgvCards.SelectedItem;
                TbSelected.Text = selectedCard.ToString();
            }
        }
    }
}
