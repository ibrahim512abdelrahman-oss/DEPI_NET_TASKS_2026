using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectOop
{
    public class Answer : ICloneable, IComparable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public override string ToString()
            => $"{AnswerId}. {AnswerText}";

        public object Clone()
            => new Answer(AnswerId, AnswerText);

        public int CompareTo(Answer other)
            => AnswerId.CompareTo(other.AnswerId);
    }

    public abstract class Question : ICloneable, IComparable<Question>
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

        public override string ToString()
            => $"[{GetQuestionType()}] {Header}: {Body} (Mark: {Mark})";

        public abstract object Clone();

        public int CompareTo(Question other)
            => Mark.CompareTo(other.Mark);
    }

    public class TrueFalseQuestion : Question
    {
        private bool _isTrue;

        public TrueFalseQuestion(string header, string body, int mark, bool isTrue)
            : base(header, body, mark,
                  new Answer[] { new Answer(1, "True"), new Answer(2, "False") },
                  isTrue ? new Answer(1, "True") : new Answer(2, "False"))
        {
            _isTrue = isTrue;
        }

        public override string GetQuestionType() => "True/False";

        public override object Clone()
            => new TrueFalseQuestion(Header, Body, Mark, _isTrue);
    }

    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer) { }

        public override string GetQuestionType() => "MCQ";

        public override object Clone()
        {
            var clonedAnswers = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
            var clonedRight = (Answer)RightAnswer.Clone();
            return new MCQQuestion(Header, Body, Mark, clonedAnswers, clonedRight);
        }
    }

    public abstract class Exam : ICloneable
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

        public override string ToString()
            => $"Exam | Time: {Time} min | Questions: {NumberOfQuestions}";

        public abstract object Clone();
    }

    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions) { }

        public override void RunExam()
        {
            List<Answer> userAnswers = new List<Answer>();
            int totalMarks = 0, obtainedMarks = 0;

            Console.WriteLine("\n========================================");
            Console.WriteLine("         FINAL EXAM START");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");
                foreach (var ans in q.AnswerList)
                    Console.WriteLine($"   {ans}");

                Console.Write(" Enter your choice (number): ");
                int choice = int.TryParse(Console.ReadLine(), out int c) ? c : 1;

                var selected = q.AnswerList.FirstOrDefault(a => a.AnswerId == choice)
                               ?? q.AnswerList[0];
                userAnswers.Add(selected);
                Console.WriteLine();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("         FINAL EXAM RESULTS");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                var userAns = userAnswers[i];
                bool isCorrect = userAns.AnswerId == q.RightAnswer.AnswerId;

                if (isCorrect) obtainedMarks += q.Mark;
                totalMarks += q.Mark;

                Console.WriteLine($"Q{i + 1}: {q.Body}");
                Console.WriteLine($"   Your Answer   : {userAns}");
                Console.WriteLine($"   Correct Answer: {q.RightAnswer}");
                Console.WriteLine($"   Mark: {q.Mark} -> {(isCorrect ? "Correct" : "Wrong")}");
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"  Your Total Grade: {obtainedMarks} / {totalMarks}");
            Console.WriteLine("========================================\n");
        }

        public override object Clone()
        {
            var cloned = new FinalExam(Time, NumberOfQuestions);
            foreach (var q in Questions)
                cloned.AddQuestion((Question)q.Clone());
            return cloned;
        }

        public override string ToString()
            => $"Final {base.ToString()}";
    }

    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions) { }

        public override void RunExam()
        {
            List<Answer> userAnswers = new List<Answer>();

            Console.WriteLine("\n========================================");
            Console.WriteLine("        PRACTICAL EXAM START");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");
                foreach (var ans in q.AnswerList)
                    Console.WriteLine($"   {ans}");

                Console.Write(" Enter your choice (number): ");
                int choice = int.TryParse(Console.ReadLine(), out int c) ? c : 1;

                var selected = q.AnswerList.FirstOrDefault(a => a.AnswerId == choice)
                               ?? q.AnswerList[0];
                userAnswers.Add(selected);
                Console.WriteLine();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("        PRACTICAL EXAM RESULTS");
            Console.WriteLine("========================================\n");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                var userAns = userAnswers[i];
                bool isCorrect = userAns.AnswerId == q.RightAnswer.AnswerId;

                Console.WriteLine($"Q{i + 1}: {q.Body}");
                Console.WriteLine($"   Your Answer   : {userAns}");
                Console.WriteLine($"   Correct Answer: {q.RightAnswer}");
                Console.WriteLine($"   Result: {(isCorrect ? "Correct" : "Wrong")}");
                Console.WriteLine();
            }
            Console.WriteLine("========================================\n");
        }

        public override object Clone()
        {
            var cloned = new PracticalExam(Time, NumberOfQuestions);
            foreach (var q in Questions)
                cloned.AddQuestion((Question)q.Clone());
            return cloned;
        }

        public override string ToString()
            => $"Practical {base.ToString()}";
    }

    public class Subject : ICloneable, IComparable<Subject>
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

        public override string ToString()
            => $"Subject [{SubjectId}]: {SubjectName}";

        public object Clone()
        {
            var cloned = new Subject(SubjectId, SubjectName);
            if (Exam != null)
                cloned.Exam = (Exam)Exam.Clone();
            return cloned;
        }

        public int CompareTo(Subject other)
            => SubjectId.CompareTo(other.SubjectId);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subject math = new Subject(101, "Mathematics");
            Console.WriteLine(math);

            FinalExam finalExam = new FinalExam(90, 3);
            finalExam.AddQuestion(new TrueFalseQuestion("TF", "7 x 6 = 42 ?", 5, true));
            finalExam.AddQuestion(new MCQQuestion("MCQ", "What is 15 + 8?", 10,
                new Answer[] { new Answer(1, "22"), new Answer(2, "23"), new Answer(3, "24") },
                new Answer(2, "23")));
            finalExam.AddQuestion(new TrueFalseQuestion("TF", "9 is the square root of 81?", 5, true));

            math.CreateExam(finalExam);

            Subject mathCopy = (Subject)math.Clone();
            Console.WriteLine($"Cloned: {mathCopy}");

            finalExam.RunExam();
        }
    }
}