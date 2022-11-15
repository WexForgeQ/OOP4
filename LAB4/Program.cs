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
    public class Exam : Test
    {
        protected int classroom;

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
        public virtual int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
    }
    public class GradExam : Exam
    {
        enum Subjects
        {
            Биология = 1,
            Математика,
            Русский,
            Default
        }
        Subjects subject = new Subjects();
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
        struct Questions
        {
          
        }
    }
    sealed public class Question : GradExam
    {
        string question;
        string answer;

        

        public Question()
        {
            question = "Default";
            answer = "Default";
        }
        public Question(string que, string answ)
        {
            question = que;
            answer = answ;
        }
        public void DisplayQuestion()
        {
            Console.WriteLine("Вопрос: " + question);
        }
        public void CheckAnswer(string answ)
        {
            if (answ == answer)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
        }

        public override void Start()
        {
            Console.WriteLine("Тест(Question) начался");
        }
        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Вопрос:" + question + " Ответ:" + answer;
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



    class Program
    {
        static void Main(string[] args)
        {
            Test Ts = new Test("GFfg");
            Console.WriteLine(Ts.ToString());
            Exam Ex = new Exam(314);
            GradExam GA = new GradExam(1);
            Question A = new Question("Как?", "Так");
            Console.WriteLine(A.ToString());
            Console.WriteLine(GA.ToString());
            A.CheckAnswer("НЕ");
            GA.Start();
            if(A is GradExam)
                Console.WriteLine("A is GrandExam");
            //GA = A as GradExam;
            //if(GA != null)
                //Console.WriteLine("Произошло приведение");
            //Console.WriteLine(GA.ToString());
            Challenge [] Arr = { GA, A, Ex };
            for(int i=0; i<3; i++)
            {
                Printer.IAmPrinting(Arr[i]);
            }
            //Console.WriteLine(Subjects.Биология);
        }
    }
}
