using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamProject
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }

    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        protected Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answers;
            RightAnswer = rightAnswer;
        }

        public abstract string GetQuestionType();
    }

    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, bool isTrue)
            : base(header, body, mark,
                  new Answer[] { new Answer(1, "True"), new Answer(2, "False") },
                  isTrue ? new Answer(1, "True") : new Answer(2, "False"))
        { }

        public override string GetQuestionType() => "True/False";
    }

    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer) { }

        public override string GetQuestionType() => "MCQ";
    }

    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public void AddQuestion(Question q)
        {
            if (Questions.Count < NumberOfQuestions)
                Questions.Add(q);
        }

        public abstract void RunExam();
    }

    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void RunExam()
        {
            List<Answer> userAnswers = new List<Answer>();
            int totalMarks = 0, obtainedMarks = 0;

            Console.WriteLine("\n========================================");
            Console.WriteLine("FINAL EXAM START");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");

                foreach (var ans in q.AnswerList)
                    Console.WriteLine($"   {ans}");

                Console.Write(" Enter your choice (number): ");
                int choice = int.TryParse(Console.ReadLine(), out int c) ? c : 1;

                var selected = q.AnswerList.FirstOrDefault(a => a.AnswerId == choice);
                if (selected == null) selected = q.AnswerList[0];

                userAnswers.Add(selected);
                Console.WriteLine();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine(" FINAL EXAM RESULTS");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                var userAns = userAnswers[i];
                var rightAns = q.RightAnswer;
                bool isCorrect = userAns.AnswerId == rightAns.AnswerId;

                if (isCorrect)
                    obtainedMarks += q.Mark;

                totalMarks += q.Mark;

                Console.WriteLine($"Q{i + 1}: {q.Body}");
                Console.WriteLine($"   Your Answer  : {userAns}");
                Console.WriteLine($"   Correct Answer: {rightAns}");
                Console.WriteLine($"   Mark: {q.Mark} → {(isCorrect ? " Correct" : " Wrong")}");
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($" Your Total Grade: {obtainedMarks} / {totalMarks}");
            Console.WriteLine("========================================\n");
        }
    }

    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void RunExam()
        {
            List<Answer> userAnswers = new List<Answer>();

            Console.WriteLine("\n========================================");
            Console.WriteLine(" PRACTICAL EXAM START");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");

                foreach (var ans in q.AnswerList)
                    Console.WriteLine($"   {ans}");

                Console.Write(" Enter your choice (number): ");
                int choice = int.TryParse(Console.ReadLine(), out int c) ? c : 1;

                var selected = q.AnswerList.FirstOrDefault(a => a.AnswerId == choice);
                if (selected == null) selected = q.AnswerList[0];

                userAnswers.Add(selected);
                Console.WriteLine();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine(" PRACTICAL EXAM RESULTS");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                var userAns = userAnswers[i];
                var rightAns = q.RightAnswer;
                bool isCorrect = userAns.AnswerId == rightAns.AnswerId;

                Console.WriteLine($"Q{i + 1}: {q.Body}");
                Console.WriteLine($"   Your Answer  : {userAns}");
                Console.WriteLine($"   Correct Answer: {rightAns}");
                Console.WriteLine($"   Result: {(isCorrect ? " Correct" : " Wrong")}");
                Console.WriteLine();
            }
            Console.WriteLine("========================================\n");
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
            Console.WriteLine($"\n Exam created for: {SubjectName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Subject 1: Mathematics - Final Exam
            Subject math = new Subject(101, "Mathematics");

            FinalExam finalExam = new FinalExam(90, 3);
            finalExam.AddQuestion(new TrueFalseQuestion("TF", "7 × 6 = 42 ?", 5, true));
            finalExam.AddQuestion(new MCQQuestion("MCQ", "What is 15 + 8?", 10,
                new Answer[] { new Answer(1, "22"), new Answer(2, "23"), new Answer(3, "24") },
                new Answer(2, "23")));
            finalExam.AddQuestion(new TrueFalseQuestion("TF", "9 is the square root of 81?", 5, true));

            math.CreateExam(finalExam);
            finalExam.RunExam();

            // Subject 2: General Knowledge - Practical Exam
            Subject general = new Subject(102, "General Knowledge");

            PracticalExam practicalExam = new PracticalExam(60, 2);
            practicalExam.AddQuestion(new MCQQuestion("MCQ", "What is the capital of Egypt?", 5,
                new Answer[] { new Answer(1, "Alexandria"), new Answer(2, "Cairo"), new Answer(3, "Giza") },
                new Answer(2, "Cairo")));
            practicalExam.AddQuestion(new MCQQuestion("MCQ", "How many days in a week?", 5,
                new Answer[] { new Answer(1, "6"), new Answer(2, "7"), new Answer(3, "8") },
                new Answer(2, "7")));

            general.CreateExam(practicalExam);
            practicalExam.RunExam();
        }
    }
}