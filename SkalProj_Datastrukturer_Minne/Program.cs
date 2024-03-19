using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            // FRÅGOR:
            // 1. I stacken lagras lokala variabler och metodanrop. När en metod blir called så skapas en ny stack frame med denna data, när metoden
            // returnerar så raderas stack framen. För att nå värden som ligger i heapen kan en pekare lagras i stacken som pekar på en minnesaddress
            // i heapen. Stacken är ordnad efter exekveringsordning (LIFO). Stacken är snabb och sköter sin egen minneshantering men har ett begränsat utrymme.
            //
            // I heapen lagras dynamiskt allokerade objekt och klassinstanser. Objekten på stacken kan ha en obegränsad storlek men är inte ordnade utan kan ligga
            // utspridda på olika minnesaddresser. En garbage collector sköter ordningen och rensning av heapen vilket kan innebär prestandproblem i vissa fall.
            //
            // 2. I value types lagras värdet direkt i variabeln. Exempel på dessa är, int, float, bool och struct. När dessa allokeras eller reallokeras skapas
            // en kopia på värdet.
            // Reference types har sitt värde på heapen med en pekare till minnesaddressen. Några exempel är klasser, interface och string. När en reference type 
            // kopieras så kopieras endast pekaren till objektet, inte själva objektet. Därmed hanteras value types av C#s runtime medan value types hanteras av 
            // garbage collectorn.
            //
            // 3. I första exemplet skapas en kopia av x när värdet är tre. Y blir ett nytt värde på stacken och kan ändras utan att x ändras.
            // I det andra exemplet kommer endast pekaren till objektet kopieras, både x och y pekar här på samma minnesaddress i heapen och alla
            // förändringar av objektet kommer påverka både x och y.
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. RecursiveEven"
                    + "\n6. RecursiveFibonacci"
                    + "\n7. IterativeEven"
                    + "\n8. IterativeFibonacci"

                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        Console.WriteLine("Enter a number (RecursiveEven):");
                        int nRecursiveEven = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"RecursiveEven({nRecursiveEven}): {RecursiveEven(nRecursiveEven)}");
                        break;
                    case '6':
                        Console.WriteLine("Enter a number (RecursiveFibonacci):");
                        int nRecursiveFibonacci = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"RecursiveFibonacci({nRecursiveFibonacci}) = {RecursiveFibonacci(nRecursiveFibonacci)}");
                        break;
                    case '7':
                        Console.WriteLine("Enter a number (IterativeEven):");
                        int nIterativeEven = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"IterativeEven({nIterativeEven}) = {IterativeEven(nIterativeEven)}"); break;
                    case '8':
                        Console.WriteLine("Enter a number (IterativeFibonacci):");
                        int nIterativeFibonacci = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"IterativeFibonacci({nIterativeFibonacci}) = {IterativeFibonacci(nIterativeFibonacci)}");
                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Use + to add and - to remove. Press 0 to go back to main menu.");
                string input = Console.ReadLine()!;

                char nav = input[0];
                string value = input.Substring(1);

                if (nav == '0') break;

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}'. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"Removed '{value}'. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        }
                        else
                        {
                            Console.WriteLine($"'{value}' not found in the list.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command. Use '+' to add or '-' to remove.");
                        break;
                }

                // Frågor:
                // 2. Den ökar när antalen element nått listans capacity.
                // 
                // 3. Den dubbleras varje gång den ökas.
                // 
                // 4. Varje gång kapaciteten ökas måste nytt minne allokeras och möjligvis det tidigare
                // allokerade minnet garbagehanteras. Detta kan kosta prestanda. En bra sak att tänka på
                // jag tagit med mig från tidigare programmeringsspråk (främst Rust) är att omman vet att 
                // man kommer behöva en viss capacity är det klokt att definiera denna capacity från början
                // så man slipper flera steg av dubbleringar och reallokationer när man senare fyller på sin
                // reference type. Jag misstänker att samma gäller i C#
                // 
                // 5. Det sker inte automatiskt då detta kan vara kapacitetskrävande men som jag förstått det 
                // går det att göra manuellt med TrimExcess. Kan nog vara användbart för att minska onödig
                // minnesanvänding i vissa fall.
                //
                // 6. Fördelar med array är att du kan styra minneshanteringen mer manuellt och kan vara bra 
                // när du vet storleken du kommer behöva. En array kan ej ändra sin storlek dynamiskt som en List tex.
                // Med stackalloc kan du styra utrymme på stacken manuellt och därmed få bättre prestanda.

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();
            string input;

            do
            {
                Console.WriteLine("ICA Queue Simulation:");
                Console.WriteLine("1. Add customer to queue");
                Console.WriteLine("2. Remove customer from queue");
                Console.WriteLine("0. Exit to main menu");
                Console.Write("Choose an option: ");
                input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        Console.Write("Enter customer name: ");
                        string customerName = Console.ReadLine()!;
                        queue.Enqueue(customerName);
                        Console.WriteLine($"{customerName} added to queue.");
                        break;
                    case "2":
                        if (queue.Count > 0)
                        {
                            string dequeuedCustomer = queue.Dequeue();
                            Console.WriteLine($"{dequeuedCustomer} removed from queue.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        break;


                    case "0":
                        Console.WriteLine("ICA is closing...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please chose 1, 2 or 3.");
                        break;
                }

                Console.WriteLine("Current queue:");
                foreach (var customer in queue)
                {
                    Console.WriteLine(customer);
                }

            } while (input != "0");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and popping to see how it behaves
            */
            {
                Console.WriteLine("Enter a string to reverse:");
                string input = Console.ReadLine()!;

                Stack<char> stack = new Stack<char>();
                foreach (char c in input)
                {
                    stack.Push(c);
                }

                string reversed = "";
                while (stack.Count > 0)
                {
                    reversed += stack.Pop();
                }

                Console.WriteLine($"Reversed: {reversed}");
            }
            // Fråga 1. Stack blir en orättvis ICA-kö då den första att hamna i kön kommer behandlas sist
            // eller inte alls om tillflödet till kön är samma eller högre än hastigheten av utflödet.
        }

        static void CheckParenthesis()
        {
            /*
             * Use this method to check if the parenthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.Write("Please enter the string you wish to check for balanced parentheses: ");
            string input = Console.ReadLine()!;

            // Man skulle kunna använda stack med ett switch statement men lite elegantare är
            // att använda en dictionary och en stack för att lösa problemet:

            static bool StackParenthesisChecker(string input)
            {
                var parenthesisPairs = new Dictionary<char, char>() {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

                Stack<char> stack = new Stack<char>();


                foreach (char c in input)
                {
                    if (parenthesisPairs.ContainsKey(c))
                    {
                        stack.Push(c);
                    }
                    else if (parenthesisPairs.ContainsValue(c))
                    {
                        if (stack.Count == 0 || parenthesisPairs[stack.Pop()] != c)
                        {
                            return false;
                        }
                    }
                }

                return stack.Count == 0;
            }

            bool isWellFormed = StackParenthesisChecker(input);
            Console.WriteLine(isWellFormed ? "(Stack) The string is well-formed.\n" : "(Stack) The string is not well-formed.\n");

        }
        // Reukrsion:
        // Fråga 2: RecusriveEven enligt samma princip som recursive odd:


        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return (RecursiveEven(n - 1) + 2);
        }

        // OBS att samtliga Fibonaccimetoder är 0-indexerade, dvs första numret är 0 inte 1.
        // Givetvis skulle man enkelt kunna använda n+1 om användaren ska få det första eller andra
        // numret osv.
        //
        // RecursiveFibonacci:
        static int RecursiveFibonacci(int n)
        {
            // För att hantera de två första värdena 0 och 1.
            if (n <= 1)
            {
                return n;
            }
            // Om n är mer än två körs metoden två gånger. 
            // Fibonacci defineras som summan av de två föregående
            // numren vilket vi får här:
            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        // Iteration:
        // Fråga 2:
        static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        // IterativeFibonacci:

        static int IterativeFibonacci(int n)
        {
            // Hantera två första
            if (n <= 1)
            {
                return n;
            }
            // Här vet vi att vi är på minst det tredje talet, därför sätts a och b
            // till de två första talen i sekvensen.
            int a = 0;
            int b = 1;
            int fib = 0;

            for (int i = 2; i <= n; i++)
            {
                // Nästa tal i sekvensen
                fib = a + b;
                // Flyttar talet ett steg i sekvensen. Det tidigare a blir b
                a = b;
                // Och be blir det senaste talet
                b = fib;
            }

            return fib;
        }

        // Fråga: Den iterativa funktionen är mer minneseffektiv då den återanvänder värdena i en loop.
        // Den rekursiva gör en mängd metodanrop som varje kommer få en egen stackframe och utökar minnes
        // behovet kontinuerligt i takt med ökande n. Stora tal kan även leda till en stack overflow här. 
        // Dessutom räknar den rekursiva versionen ut varje deltal separat medan den interativa använder en
        // uträkning för tal a och b.
    }

}

