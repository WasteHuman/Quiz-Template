using Core.QuestionBase;

namespace Core.Loop
{
    public interface IQuestionProvider
    {
        QuestionData GetNext();
    }
}