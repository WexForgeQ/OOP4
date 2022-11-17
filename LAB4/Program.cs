using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LAB4
{
   



    interface IStart
    {
        public void Start();

    }
    abstract public class Challenge
    {

        protected string time;


        public virtual string Time
        {
            get => time;
            set => time = value;
        }
        public Challenge(string time)
        {
            Time = time;

        }

        public Challenge()
        {
            time = "Default";
        }
        public abstract void Start();


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "Тип объекта:" + base.GetType() + " Значение объекта:" + base.ToString();
        }

    }
    public class Test : Challenge
    {
        public struct Student
        {

           public  string name;
           public string school;
           public int brthyear;
           public int grade;

        }

        Student ST = new Student();



        public Test()
        {
            ST.name = "Default";
        }

        public Test(string nm)
        {
            ST.name = nm;
        }

        public override void Start()
        {
            Console.WriteLine("Тест(Test) начался");
        }

        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Имя:" + ST.name;
        }
    }
    public partial class Exam : Test
    {
        public int classroom;

        public int Classroom { get; set; }

        public Exam(int cls)
        {
            classroom = cls;
        }
        public Exam()
        {
            classroom = 100;
        }
        public override void Start()
        {
            Console.WriteLine("Тест(Exam) начался");
        }
        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Кабинет:" + classroom;
        }

        public List <Question> questions = new List<Question>();

        public Exam(List <Question> Q) => questions = Q;

        public Question this[int index]
        {
            get => questions[index];
            set => questions[index] = value;
        }

        public void AddQuestToTest(string qua)
        {

            Question Q = new Question(qua);
            questions.Add(Q);

        }
        public void DisplayQuestions()
        {
            int i = 0;
            foreach (Question q in questions)
            {
                i++;
                Console.WriteLine("Вопрос №"+ i + ": " + q.question);
            }

        }

    }
    public class GradExam : Exam
    {
        public enum Subjects
        {
            Биология = 1,
            Математика,
            Русский,
            Default
        }
        public Subjects subject = new Subjects();

        public virtual string Subject { get; set; }

        public GradExam(int i)
        {
            subject = (Subjects)i;
        }

    public GradExam()
        {
            subject = Subjects.Default;
        }

        public override void Start()
        {
            Console.WriteLine("Тест(GradExam) начался");
        }

        public override string ToString()
        {
            return "Тип объекта:" + base.GetType() + " Предмет:" + subject;
        }
   
    }
    sealed public class Question : GradExam
    {
        public string question;

        public Question()
        {
            question = "Default";
        }

        public Question(string que)
        {
            question = que;
        }
        public void DisplayQuestion()
        {
            Console.WriteLine("Вопрос: " + question);
        }

        public override void Start()
        {
            Console.WriteLine("Тест(Question) начался");
        }

        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Вопрос:" + question;
        }

    }


    static class Printer
    {

        public static void IAmPrinting(Challenge test)
        {
            if (test is Exam testing)
            {
                Console.WriteLine(testing.ToString());
            }
            else if (test is GradExam final_exam)
            {
                Console.WriteLine(final_exam.ToString());
            }
            else if (test is Test test1)
            {
                Console.WriteLine(test1.ToString());
            }
            else if (test is Question question)
            {
                Console.WriteLine(question.ToString());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }


    public class Session
    {
        List<Exam> exams = new List<Exam>();
        List<GradExam> gradExams = new List<GradExam>();

        public List<Exam> Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams = value;
            }
        }
        public List<GradExam> GradExams
        {
            get
            {
                return gradExams;
            }
            set
            {
                gradExams = value;
            }
        }
        public void AddExam(Exam A)
        {
            exams.Add(A);
        }
        public void RemoveExam(Exam A)
        {
            exams.Remove(A);
        }
        public void DisplayExams()
        {
            Console.WriteLine("Список тестов: ");
            foreach(Exam exam in Exams)
            {
                Console.Write("Тест в кабинете №:" + exam.classroom + "; ");
            }
            Console.WriteLine();

        }
        public void DisplayGradExams()
        {

            Console.WriteLine("Список экзаменов: ");
            foreach (GradExam grexam in GradExams)
            {
                Console.Write("Тест по предмету: " + grexam.subject + "; ");
            }
            Console.WriteLine();

        }


        public void AddGrandExam(GradExam A)
        {
            gradExams.Add(A);
        }
        public void RemoveGrandExam(GradExam A)
        {
            gradExams.Remove(A);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            GradExam A = new GradExam(1);
            GradExam B = new GradExam(2);
            GradExam C = new GradExam(3);
            Exam D = new Exam(314);
            Exam E = new Exam(312);
            A.AddQuestToTest("fff");
            A.AddQuestToTest("dfds");
            B.AddQuestToTest("dfds");
            B.AddQuestToTest("dfds");
            C.AddQuestToTest("dfds");
            Session Sess = new Session();
            Sess.AddGrandExam(A);
            Sess.AddGrandExam(B);
            Sess.AddGrandExam(C);
            Sess.AddExam(D);
            Sess.AddExam(E);
            Sess.DisplayExams();
            Sess.DisplayGradExams();
           
        }
    }
}
