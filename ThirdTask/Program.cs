namespace ThirdTask
{
    public class ProgramThirdTask
    {
        public List<int> _listNumbersUser = new List<int>();

        static void Main(string[] args)
        {
            ProgramThirdTask program = new ProgramThirdTask();
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

        public List<string> DogCatMuzzGuzz()
        {
            var result = new List<string>();

            foreach (var number in _listNumbersUser)
            {
                string value = "";

                if (number % 3 == 0 && number % 5 == 0)
                {
                    value = "good-boy";
                }
                else if (number % 3 == 0)
                {
                    value = "dog";
                }
                else if (number % 5 == 0)
                {
                    value = "cat";
                }

                if (number % 4 == 0)
                {
                    value += (value != "" ? "-" : "") + "muzz";
                }
                if (number % 7 == 0)
                {
                    value += (value != "" ? "-" : "") + "guzz";
                }

                if (value == "")
                {
                    value = number.ToString();
                }

                result.Add(value);
            }

            return result;
        }

        public void OutputResult()
        {
            try
            {
                List<string> result = DogCatMuzzGuzz();
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