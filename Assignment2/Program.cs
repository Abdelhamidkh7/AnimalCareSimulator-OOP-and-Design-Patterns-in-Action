
/*Name: Abdel Hamid Khaled 
 * Neptune Code:UMI93X
 _____________________________________________________________________________________________________________
 Hobby animals need several things to preserve their exhilaration. Steve has some hobby animals: tarantulas,
hamsters, and cats. Every animal has a name and their exhilaration level is between 0 and 70 (0 means that the
animals dies). If their keeper is joyful, he takes care of everything to cheer up his animals, and their exhilaration
level increases: of the tarantulas by 1, of the hamsters by 2, and of the cats by 3.
On a usual day, Steve takes care of only the cats (their exhilaration level increases by 3), so the exhilaration level
of the rest decreases: of the tarantulas by 2, and of the hamsters by 3. On a blue day, every animal becomes a bit
sadder and their exhilaration level decreases: of the tarantulas by 3, of the hamsters by 5, of the cats by 7.
Steve’s mood improves by one if the exhilaration level of every alive animal is at least 5.
Every data is stored in a text file. The first line contains the number of animals. Each of the following lines contain
the data of one animal: one character for the type (T – Tarantula, H – Hamster, C – Cat), name of the animal (one
word), and the initial level of exhilaration.
In the last line, the daily moods of Steve are enumerated by a list of characters (j – joyful, u – usual, b – blue). The
file is assumed to be correct.
List the animals of the highest exhilaration level at the end of each day.
*/


using System;
using TextFile;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Assignment2
{
    
    public class Program
    {

        static void Main()
        {
            TextFileReader reader = new("inp.txt");
            Keeper Steve = new Keeper();
            List<Animal> animals = new();
            // populating animals
            try
            {
                reader.ReadLine(out string line); int n = int.Parse(line);
            
           
           
            
         

            //Reading Animals (Types,Name and Exhilaration)
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal? animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        char cha = char.Parse(tokens[0]);
                        string name = tokens[1];
                        int p = int.Parse(tokens[2]);

                        switch (cha)
                        {
                            case 'T': animal = new Tarantula(name, p); Steve.AddTarantula(name, p); break;
                            case 'H': animal = new Hamster(name, p); Steve.AddHamster(name, p); break;
                            case 'C': animal = new Cat(name, p); Steve.AddCat(name, p); break;
                            default:
                                throw new Keeper.WrongInputException();
                        }
                    }
                    catch (Keeper.WrongInputException) { Console.WriteLine("Invalid animal type at line: {0}! Fix the File!!!",i+2);
                        return;
                    }
                }
                animals.Add(animal);
            }
           
            int cnt = 0;
            char ch = 'q';
            List<IMood> days = new();

                //Reading Steve's Moods
                while (true)
                {
                    try
                    {
                        reader.ReadChar(out ch);
                        if (ch == '\0')
                        {
                            // Handle the end-of-file condition
                            break;
                        }
                        switch (ch)
                        {
                            case 'j': Steve.KJoyfull(); break;
                            case 'u': Steve.KUsual(); break;
                            case 'b': Steve.KBlue(); break;
                            default:
                                throw new Keeper.WrongInputException();
                        }
                        cnt++;
                    }
                    catch (Keeper.WrongInputException)
                    {
                        Console.WriteLine("Invalid mood type at day: {0} ! Fix the File!!!", cnt);
                        return;
                    }
                }
                }
            catch (Keeper.EmptyListException) { Console.WriteLine("No Animals found!! Fix the File!!!"); return; }

            catch (System.FormatException)
            {
                Console.WriteLine("Wrong Format! Fix the File!!!");
                return;
            }




            // Steve Starts Keeping the Animals
            try
            {
               Steve.Maximum();

               
            }
            
                    catch (Keeper.ExOutOfRange)
                    {
                    Console.WriteLine("Exhilaration out of range");
                    
                }
            catch(Keeper.AllAnimalsDiedExeption) { Console.WriteLine("All Animals Died :("); }
}

    }

}
    

