using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8
{
    public class NullableIntroduction
    {
        /*
         * You can use these new types to more clearly express your design intent: some variables must always have a value, others may be missing a value.
         * once the feature is turned on, existing reference variable declarations become non-nullable reference types
         */
        public enum QuestionType
        {
            YesNo,
            Number,
            Text
        }

        public class SurveyQuestion
        {
            // Because you haven't initialized QuestionText, the compiler issues a warning that a non-nullable property hasn't been initialized.
            // so you add a constructor to initialize it 
            public string QuestionText { get; }
            public QuestionType TypeOfQuestion { get; }

            public SurveyQuestion(QuestionType questionType, string question)
            {
                QuestionText = question;
                TypeOfQuestion = questionType;
            }
        }

        public class SurveyRun
        {
            private List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();

            public void AddQuestion(QuestionType type, string question) =>
                AddQuestion(new SurveyQuestion(type, question));
            public void AddQuestion(SurveyQuestion surveyQuestion) => surveyQuestions.Add(surveyQuestion);
        }

        public static void Run()
        {
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");

            surveyRun.AddQuestion(QuestionType.Text, null);
        }
    }
}
