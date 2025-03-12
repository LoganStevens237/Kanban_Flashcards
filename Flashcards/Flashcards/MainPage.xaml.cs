using GameplayKit;

namespace Flashcards
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public Dictionary<string, string> FlashCards = new Dictionary<string, string>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private IEnumerable<string> ShuffleCards() 
        {
            IEnumerable<string> cards = FlashCards.Keys;
            Random random = new Random();
            return cards;
        } 
    }

}
