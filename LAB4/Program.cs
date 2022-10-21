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
    abstract public class   Challenge
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
            return "Тип объекта:" + base.GetType() + " Значение объекта:"+base.ToString();
        }

    }
    public class Test:Challenge
    {
        protected string name;
        public virtual string Name
        {
            get => name;
            set => name = value;
        }
        
        public Test()
        {
            Name = "Default";
        }

        public Test(string nm)
        {
            name = nm;
        }

        public override void Start()
        {
            Console.WriteLine("Тест(Test) начался");
        }

        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Имя:" + name;
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
    }
    public class GradExam:Exam
    {
        protected string subject;
        public virtual string Subject { get; set; }

        public GradExam(string sub)
        {
            subject = sub;
        }
        public GradExam()
        {
            subject = "Default";
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
    sealed public class Question:GradExam
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
            Console.WriteLine("Вопрос: "+ question);
        }
        public void CheckAnswer(string answ)
        {
            if(answ==answer)
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
            return "Тип объекта:" + GetType() + " Вопрос:"+question + " Ответ:"+answer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GradExam GA = new GradExam();
            Question A = new Question("Как?", "Так");
            Console.WriteLine(A.ToString());
            Console.WriteLine(GA.ToString());
            A.CheckAnswer("НЕ");
            GA.Start();
        }
    }
}
