using System;
using System.Collections.Generic;

//Есть аквариум, в котором плавают рыбы. В этом аквариуме может быть максимум определенное кол-во рыб.
//Рыб можно добавить в аквариум или рыб можно достать из аквариума. (программу делать в цикле для того, чтобы рыбы могли “жить”) 
//Все рыбы отображаются списком, у рыб также есть возраст. За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть.
//Рыб также вывести в консоль, чтобы можно было мониторить показатели.

// создаем аквариум
// создаем 10 видов рыб
// у рыб должно быть ИМЯ цвет и прожитые дни/максимум жизней

namespace Project_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
        }
    }

    class Aquarium
    {
        private List<Fish> _fishs = new List<Fish>();

        public Aquarium()
        {
            _fishs.Add(new Fish1("fish_1", 1, 5, "green"));
            _fishs.Add(new Fish2("fish_2", 1, 9, "yellow"));
            _fishs.Add(new Fish3("fish_3", 1, 12, "red"));
            _fishs.Add(new Fish4("fish_4", 1, 15, "blu"));
            _fishs.Add(new Fish5("fish_5", 1, 17, "greey"));
        }

    }

    abstract class Fish
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public int MaxAge { get; protected set; }
        public string Color { get; protected set; }

        public Fish(string name, int age, int maxAge, string color)
        {
            Name = name;
            Age = age;
            MaxAge = maxAge;
            Color = color;
        }

        public void OneYear()
        {
            Age++;
        }

        public bool Dead()
        {
            if(Age >= MaxAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract Fish Clone();

    }

    class Fish1 : Fish 
    {
        public Fish1(string name, int age, int maxAge, string color) : base(name, age, maxAge, color)
        {

        }

        private Fish1(Fish1 fish1) : this(fish1.Name, fish1.Age, fish1.MaxAge, fish1.Color)
        {

        }

        public override Fish Clone()
        {
            return new Fish1(this);
        }
    }

    class Fish2 : Fish
    {
        public Fish2(string name, int age, int maxAge, string color) : base(name, age, maxAge, color)
        {

        }

        private Fish2(Fish2 fish2) : this(fish2.Name, fish2.Age, fish2.MaxAge, fish2.Color)
        {

        }

        public override Fish Clone()
        {
            return new Fish2(this);
        }
    }

    class Fish3 : Fish
    {
        public Fish3(string name, int age, int maxAge, string color) : base(name, age, maxAge, color)
        {

        }

        private Fish3(Fish3 fish3) : this(fish3.Name, fish3.Age, fish3.MaxAge, fish3.Color)
        {

        }

        public override Fish Clone()
        {
            return new Fish3(this);
        }
    }

    class Fish4 : Fish
    {
        public Fish4(string name, int age, int maxAge, string color) : base(name, age, maxAge, color)
        {

        }

        private Fish4(Fish4 fish4) : this(fish4.Name, fish4.Age, fish4.MaxAge, fish4.Color)
        {

        }

        public override Fish Clone()
        {
            return new Fish4(this);
        }
    }

    class Fish5 : Fish
    {
        public Fish5(string name, int age, int maxAge, string color) : base(name, age, maxAge, color)
        {

        }

        private Fish5(Fish5 fish5) : this(fish5.Name, fish5.Age, fish5.MaxAge, fish5.Color)
        {

        }

        public override Fish Clone()
        {
            return new Fish5(this);
        }
    }

}
