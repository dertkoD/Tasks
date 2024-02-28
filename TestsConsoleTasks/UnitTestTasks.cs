using FirstTask;
using SecondTask;
using ThirdTask;

namespace TestsConsoleTasks
{
    [TestFixture]
    public class ProgramTestTasks
    {
        [Test]
        public void ParseInput_ValidInput_ShouldParseNumbersCorrectly()
        {
            // Arrange
            var program = new ProgramTask();
            string input = "1, 2, 3, 4, 5";

            // Act
            program.ParseInput(input);

            // Assert
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, program._listNumbersUser);
        }

        [Test]
        public void ParseInput_InvalidInput_ShouldClearListNumbersUser()
        {
            // Arrange
            var program = new ProgramTask();
            string input = "1, two, 3, 4, 5";

            // Act
            program.ParseInput(input);

            // Assert
            Assert.IsEmpty(program._listNumbersUser);
        }

        [Test]
        public void FizzBuzz_ShouldReturnExpectedResults()
        {
            // Arrange
            var program = new ProgramTask();
            program._listNumbersUser = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            List<string> result = program.FizzBuzz();

            // Assert
            Assert.AreEqual(new List<string> { "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizz-buzz" }, result);
        }

        [Test]
        public void FizzBuzzMuzzGuzz_ShouldReturnExpectedResults()
        {
            // Arrange
            var program = new ProgramSecondTask();
            program._listNumbersUser = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };

            // Act
            List<string> result = program.FizzBuzzMuzzGuzz();

            // Assert
            Assert.AreEqual(new List<string> { "1", "2", "fizz", "muzz", "buzz", "fizz", "guzz", "muzz", "fizz", "buzz", "11", "fizz-muzz", "13", "guzz", "fizz-buzz", "fizz-buzz-muzz", "fizz-buzz-guzz", "fizz-buzz-muzz-guzz" }, result);
        }

        [Test]
        public void DogCatMuzzGuzz_ShouldReturnExpectedResults()
        {
            // Arrange
            var program = new ProgramThirdTask();
            program._listNumbersUser = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };

            // Act
            List<string> result = program.DogCatMuzzGuzz();

            // Assert
            Assert.AreEqual(new List<string> { "1", "2", "dog", "muzz", "cat", "dog", "guzz", "muzz", "dog", "cat", "11", "dog-muzz", "13", "guzz", "good-boy", "good-boy-muzz", "good-boy-guzz", "good-boy-muzz-guzz" }, result);
        }

        [Test]
        public void AskToContinue_ValidInput_ShouldReturnTrue()
        {
            // Arrange
            var program = new ProgramTask();
            StringReader input = new StringReader("Y");
            Console.SetIn(input);

            // Act
            bool result = program.AskToContinue();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AskToContinue_InvalidInputThenValidInput_ShouldReturnTrue()
        {
            // Arrange
            var program = new ProgramTask();
            StringReader input = new StringReader("invalidInput\nY");
            Console.SetIn(input);

            // Act
            bool result = program.AskToContinue();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AskToContinue_InvalidInput_ShouldAskAgain()
        {
            // Arrange
            var program = new ProgramTask();
            StringReader input = new StringReader("invalidInput\ninvalidInput\nN");
            Console.SetIn(input);

            // Act
            bool result = program.AskToContinue();

            // Assert
            Assert.IsFalse(result);
        }
    }
}