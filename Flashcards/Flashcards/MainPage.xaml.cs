namespace Flashcards
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool isQuestion = true;
        public Dictionary<string, string> FlashCards = new Dictionary<string, string>();

        string currentQuestion = "Question";
        string currentAnswer = "Answer";

        public MainPage()
        {
            InitializeComponent();

            Flashcard.Text = currentQuestion;
        }

        private void OnFlipClick(object sender, EventArgs e)
        {
            if (isQuestion)
            {
                Flashcard.Text = currentAnswer;
                Flashcard.BackgroundColor = Colors.Turquoise;
            }
            else
            {
                Flashcard.Text = currentQuestion;
                Flashcard.BackgroundColor = Colors.Lavender;
            }

            isQuestion = !isQuestion;
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            string question = QuestionBox.Text;
            string answer = AnswerBox.Text;

            if (!FlashCards.TryGetValue(question, out string ans))
            {
                FlashCards.Add(question, answer);
            }
        }

        private void OnRemoveClick(object sender, EventArgs e)
        {
            string question = QRemoveBox.Text;
            if (FlashCards.TryGetValue(question, out string answer))
            {
                FlashCards.Remove(question);
            }
        }

        private void OnQuestionCompleted(object sender, EventArgs e)
        {
            Entry entry = sender as Entry;

            if (entry != null || !string.IsNullOrWhiteSpace(entry.Text))
            {
                if (FlashCards.TryGetValue(entry.Text, out string answer))
                {
                    currentQuestion = entry.Text;
                    currentAnswer = answer;

                    isQuestion = true;
                    Flashcard.Text = currentQuestion;
                }
            }

        }

        private IEnumerable<string> ShuffleCards()
        {
            IEnumerable<string> cards = FlashCards.Keys;
            Random random = new Random();
            return cards;
        }
    }

}
