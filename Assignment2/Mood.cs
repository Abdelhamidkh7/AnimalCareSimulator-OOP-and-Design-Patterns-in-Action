using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Assignment2
{
   //public enum G {   blue = 0, usual = 1, joyfull =2 }
    interface IMood
    {
        IMood ChangeT(Tarantula p);
        IMood ChangeH(Hamster p);
        IMood ChangeC(Cat p);
       
    }

    

    class Joyfull : IMood
    {
      
        public IMood ChangeT(Tarantula p)
        {
            p.ModifyEx(1);
           
                return Joyfull.Instance();
            ;
        }
        public IMood ChangeH(Hamster p)
        {
            p.ModifyEx(2);
            return Joyfull.Instance();
          
        }
        public IMood ChangeC(Cat p)
        {
            p.ModifyEx(3);
            return Joyfull.Instance();
           
        }
        private Joyfull() { }


        private static Joyfull instance = null;
        public static Joyfull Instance()
        {
            if (instance == null)
            {
                instance = new Joyfull();
            }
            return instance;
        }
       
    }
    class Usual : IMood
    {

        public IMood ChangeT(Tarantula p)
        {
            p.ModifyEx(-2);
           
            {

                return Usual.Instance();
            }
            ;
        }
        public IMood ChangeH(Hamster p)
        {

             p.ModifyEx(-3);
           
                return Usual.Instance();
            

        }
        public IMood ChangeC(Cat p)
        {
             p.ModifyEx(3);
          
               
                return Usual.Instance();
            

        }
        private Usual() { }


        private static Usual? instance = null;
        public static Usual Instance()
        {
            if (instance == null)
            {
                instance = new Usual();
            }
            return instance;
        }
       
    }
    class Blue : IMood
    {

        public IMood ChangeT(Tarantula p)
        {
             p.ModifyEx(-3);
            

                return Blue.Instance();
            
            
        }
        public IMood ChangeH(Hamster p)
        {
            p.ModifyEx(-5);
            
            
             
                return Blue.Instance();
            

        }
        public IMood ChangeC(Cat p)
        {
            p.ModifyEx(-7);
           
             
                return Blue.Instance();
            

        }
        private Blue() { }


        private static Blue? instance = null;
        public static Blue Instance()
        {
            if (instance == null)
            {
                instance = new Blue();
            }
            return instance;
        }
       
        }
    }


