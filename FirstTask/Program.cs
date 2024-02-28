namespace FirstTask
{
    public class ProgramTask
    {
        public List<int> _listNumbersUser = new List<int>();

        static void Main(string[] args)
        {
            ProgramTask program = new ProgramTask();
            bool continueProgram = true;

            while (continueProgram)
            {
                program.Run();
                continueProgram = program.AskToContinue();
            }
        }

        public void Run()
        {
            Console.WriteLine("Enter numbers separated by commas:");
            string inputDataUser = Console.ReadLine();
            ParseInput(inputDataUser);
            OutputResult();
        }

        public void ParseInput(string input)
        {
            try
            {
                _listNumbersUser = input.Split(',')
                            .Select(s => int.Parse(s.Trim()))
                            .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _listNumbersUser.Clear();
            }
        }

        public List<string> FizzBuzz()
        {
            var result = new List<string>();

            foreach (var number in _listNumbersUser)
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    result.Add("fizz-buzz");
                }
                else if (number % 3 == 0)
                {
                    result.Add("fizz");
                }
                else if (number % 5 == 0)
                {
                    result.Add("buzz");
                }
                else
                {
                    result.Add(number.ToString());
                }
            }

            return result;
        }

        public void OutputResult()
        {
            try
            {
                List<string> result = FizzBuzz();
                Console.WriteLine("Output:");
                Console.WriteLine(string.Join(", ", result));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool AskToContinue()
        {
            while (true)
            {
                Console.WriteLine("Continue? (Y/N)");
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "Y" || input == "N")
                {
                    return (input == "Y");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            }
        }
    }
}