using System;
using System.Collections.Generic;

namespace Core.QuestionBase
{
    [Serializable]
    public class QuestionData
    {
        public string Question = "Default question";

        public List<AnswerData> Answers = new();

        public int CorrectAnswerIndex;
    }
}