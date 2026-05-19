namespace Core.QuestionBase
{
    public class QuizSession
    {
        public int CurrentQuestionIndex { get; private set; }

        public int Lives { get; private set; }

        public int Coins { get; private set; }
    }
}