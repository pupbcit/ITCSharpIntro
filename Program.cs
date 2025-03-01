namespace ITCSharpIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME");

            //pin, view balance, withdraw, deposit

            double balance = 10000.0;
            int pin = 1234;

            Console.Write("Enter PIN: ");
            int userPin = Convert.ToInt16(Console.ReadLine());

            if (userPin == pin)
            {
                Console.WriteLine("Success!!");

                string[] actions = new string[] { "[1] View Balance", "[2] Withdraw", "[3] Deposit", "[4] Exit" };

                Console.WriteLine("ACTIONS");

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }
                Console.Write("Enter Action: ");

                int userAction = Convert.ToInt16(Console.ReadLine());

                switch (userAction)
                {
                    case 1:
                        Console.WriteLine($"Your balance is {balance}");
                        break;
                    case 2:
                        Console.Write("Enter amount to withdraw: ");
                        double toWithdraw = Convert.ToDouble(Console.ReadLine());

                        balance -= toWithdraw;

                        Console.WriteLine($"Your new balance is {balance}");

                        break;
                    case 3:
                        Console.Write("Enter amount to deposit: ");
                        double toDeposit = Convert.ToDouble(Console.ReadLine());

                        balance += toDeposit;

                        Console.WriteLine($"Your new balance is {balance}");
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Console.WriteLine("Incorrect Password. Try again.");
            }

        }
    }
}
