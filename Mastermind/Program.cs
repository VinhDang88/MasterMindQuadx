Console.WriteLine("Welcome to Mastermind!\n");
Console.WriteLine("You must match a randomly-generated 4-digit number with all digits between 1-6");
Console.WriteLine($"Each time you guess a correct digit in the correct position you will recieve a '+'");
Console.WriteLine($"Each time you guess a correct digit but in the wrong position you will recieve a '-'");
Console.WriteLine("You will get 10 chances to guess the correct number\n");

Console.WriteLine("Example:");
Console.WriteLine("Random Number = 1112");
Console.WriteLine("Your Guess = 1222");
Console.WriteLine("Output: +  +\n");

Random rand = new Random();
string randomNumberGenerated = "";
int counter = 1;
bool winner = false;

//generate random number 
for (int i = 0; i < 4; i++)
{
    randomNumberGenerated += rand.Next(1, 7).ToString();
}

//main guessing loop
while (!winner && counter <= 10)
{
    Console.WriteLine($"Attempt #{counter}: Please enter a 4 digit number between 1-6");
    string userInput = Console.ReadLine();

    while (!ValidateUserInput(userInput))
    {
        Console.WriteLine("Invalid format: Please enter 4 numbers between 1-6");
        userInput = Console.ReadLine();
    }

    // one-guess win
    if (userInput == randomNumberGenerated)
    {
        Console.WriteLine("You win!");
        winner = true;
    }

    string feedbackToUser = "";
    if (userInput != randomNumberGenerated)
    {
        counter++;

        for (int i = 0; i < userInput.Length; i++)
        {
            if (randomNumberGenerated.Contains(userInput[i]))
            {
                if (randomNumberGenerated[i] == userInput[i])
                {
                    feedbackToUser += "+";
                }
                else
                {
                    feedbackToUser += "-";
                }
            }
            else feedbackToUser += " ";
        }
        Console.WriteLine($"Feedback: {feedbackToUser}");
        Console.WriteLine("Try again?");
    }
}
Console.WriteLine($"The number to guess: {randomNumberGenerated}"); 


bool ValidateUserInput(string userInput)
{
    if (String.IsNullOrWhiteSpace(userInput) ||
       userInput.Contains("7") ||
       userInput.Contains("8") ||
       userInput.Contains("9") ||
       userInput.Contains("0") ||
       (!Int32.TryParse(userInput, out int value)) ||  
       userInput.Length != 4)
    {
        return false;
    }
    else return true;
}
