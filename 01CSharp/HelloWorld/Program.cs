using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal whoDis = new Cat(); //a cat

            Cat auryn = new Cat();

            MakeItMove(auryn);

            int n = 3;
            double m = n;

            double p = 4.4;
            int q = (int)p; // 4

        }

        static Cat GetMeACat()
        {
            return new Cat();
        }

        static void MakeItMove(Animal animal)
        {
            animal.Move();
        }
    }

    class Animal
    {
        public virtual void Move()
        {
            Console.WriteLine("I move");
        }
    }

    class Cat : Animal
    {
        public override void Move()
        {
            Console.WriteLine("I slink");
        }
    }
}
