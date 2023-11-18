using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Keeper
    {
        #region Exceptions
        public class EmptyListException : Exception { };
      
        public class ExOutOfRange : Exception { };
        public class WrongInputException : Exception { };
        public class AllAnimalsDiedExeption : Exception { };
#endregion
        private List<Animal> Animals { get; }
        private List<Animal> maxanimals { get; }
        private List<IMood> Days { get; }
        
        public Keeper()
        {
            maxanimals = new List<Animal>();
            Animals = new List<Animal>();
            Days = new List<IMood>();
        }
        public List<string> GetMood()
        {
            List<string> names = new List<string>();
            foreach (IMood day in Days)
            {
                string name = day.GetType().Name;
                names.Add(name);
                
            }
            return names;
        }
        #region Adding Animals
        public void AddTarantula(string Name, int Exhilaration)
        {
            Animals.Add(new Tarantula(Name, Exhilaration));
        }
        public void AddHamster(string Name, int Exhilaration)
        {
            Animals.Add(new Hamster(Name, Exhilaration));
        }
        public void AddCat(string Name, int Exhilaration)
        {
            Animals.Add(new Cat(Name, Exhilaration));
        }
        #endregion
        public List<(string, int)> GetAnimal()
        {
            List<(string,int)> names = new List<(string, int)>();
            foreach (Animal animal in Animals)
            {
                string name = animal.Name;
                int exhilaration = animal.Exhilaration;
                names.Add( (name,exhilaration));
              
            }
            return names;
        }
        #region Adding Moods
        public void KJoyfull()
        { Days.Add(Joyfull.Instance()); }
        public void KUsual()
        { Days.Add(Usual.Instance()); }
        public void KBlue()
        { Days.Add(Blue.Instance()); }

        #endregion
        //made it not void to use it for test cases
        public List<string> Maximum()
        {
            
           
            //List<Animal> maxanimals = new List<Animal>();
            List<string> maxnames = new List<string>();
            int d = 0;
           


            List<IMood> temp = new List<IMood>();

            if (this.Animals.Count == 0 || this.Days.Count == 0)
            {
                throw new EmptyListException();
            }
           
            for (int j = 0; j < this.Days.Count; j++)

            {
                int maxex = 0;
                Animal? max = null;
                int cnt = 0;
                bool more5 = this.ExMoreThen5();
               
                    for (int i = 0; i < this.Animals.Count; ++i)
                {



                    if (this.Animals[i].Exhilaration > 5)
                    {
                        cnt++;

                    }


                    { temp.Insert(j, this.Animals[i].LiveChange(this.Days[j], more5)); }

                        if (this.Animals[i].Exhilaration >= 70)
                        {
                            
                            throw new ExOutOfRange();

                        }
                    
                    
                   
                    if (maxex < this.Animals[i].Exhilaration)
                    {
                        maxex = this.Animals[i].Exhilaration;

                        max = this.Animals[i];


                    }
                   Console.Write(this.Animals[i].Name + " " + this.Animals[i].Exhilaration + "\n");

            
            }
               
                
                if (maxex > 0)
                {

                    maxanimals.Add(max);
                    maxnames.Add(max.Name);
                    Console.WriteLine("Day {0}: " + max.Name, d += 1);
                }


                else
                {
                    throw new AllAnimalsDiedExeption();
                    

                }


                this.Days[j] = temp[j];
               Console.WriteLine(this.Days[j].GetType().Name);


                maxex = 0;

             

            }
       


            return maxnames;
        }
       

        public bool ExMoreThen5()
    {
        foreach (Animal animal in Animals)
        {
            if (animal.Exhilaration <= 5)
            {
                return false;
            }
            

        }
        return true;
    }
}
    } 
