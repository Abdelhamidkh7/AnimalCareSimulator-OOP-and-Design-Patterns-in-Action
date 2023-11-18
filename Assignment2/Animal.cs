using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using System.Collections.Generic;

namespace Assignment2
{
    abstract class Animal
    {
        public string Name { get; protected set; }
        public int Exhilaration { get; protected set; }
      //  public int GetEx() { return Exhilaration; }
   
        public void ModifyEx(int e) { Exhilaration += e; }
        protected Animal(string name, int e) { Name = name; Exhilaration = e; }
        public bool Alive() { return Exhilaration > 0; }
       
        public IMood LiveChange(IMood day,bool a)
        {
            if (Alive())

            {
                if (a)
                {
                   day = Traverse1(day);
                }
                else day = Traverse(day);

            }
            return day;
        }

        protected abstract IMood Traverse(IMood mood);
        protected abstract IMood Traverse1(IMood mood);
    }
    class Tarantula : Animal
    {
        public Tarantula(string str, int e) : base(str, e) { }
         protected override IMood Traverse(IMood mood)
        { 
            
            return mood.ChangeT(this);
            
       }
        protected override IMood Traverse1(IMood mood)
        {
            if (mood is Blue)
                return Usual.Instance().ChangeT(this);
            else return Joyfull.Instance().ChangeT(this);
        }

    }
    class Hamster : Animal
    {
        public Hamster(string str, int e) : base(str, e) { }
        protected override IMood Traverse(IMood mood)
        {

            return mood.ChangeH(this);
        }
        protected override IMood Traverse1(IMood mood)
        {
            if (mood is Blue)
                return Usual.Instance().ChangeH(this);
            else return Joyfull.Instance().ChangeH(this);
        }
    }
    class  Cat: Animal
    {
        public Cat(string str, int e) : base(str, e) { }
         protected override IMood Traverse(IMood mood)
         {
           
            return mood.ChangeC(this);
        }
        protected override IMood Traverse1(IMood mood)
        {
            if (mood is Blue)
                return Usual.Instance().ChangeC(this);
            else return Joyfull.Instance().ChangeC(this);
        }
    }
    
}
