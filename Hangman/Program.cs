using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

List<string> keywords = ["food", "delicious", "stalin", "polpot", "angelus", "legna"];
int numTries = 10;
int tryCounter = 0;
string guess;
List<string> correctGuess = [];
bool isPlaying = false;
List<string> chosenWord;
char j;
void Main()
{
    chosenWord = GetWord(keywords);
    foreach (string s in chosenWord)
    {
        Console.WriteLine(s);
    }
    

    Console.WriteLine("Do you wish to play hangman? Y/N");
    string answer = Console.ReadLine().ToUpper();

    if (answer == "Y")
    {
        isPlaying = true;


        while (isPlaying)
        {
            guess = GetGuess();
            Console.WriteLine($"Your guess was ---{guess}---");

            bool isRight = isCorrect(guess, chosenWord);

            if (isRight)
            {
                Console.WriteLine("");
                Console.WriteLine("Congrats!");
                bool check = ifWon(correctGuess, chosenWord);

                if (check)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You won! Thanks for playing!");
                    isPlaying = false;
                }
            }
            else if (tryCounter >= numTries)
            {
                Console.WriteLine("You ran out of tries! Game over.");
                isPlaying = false;
            }
            else
            {
                Console.WriteLine("You were wrong, keep trying!");
            }
        }
    }
    else if (answer == "N")
    {
        isPlaying = false;
        Console.WriteLine("Thanks anyways!");
    }
    else
    {
        Console.WriteLine("Invalid answer!");
    }
}

List<string> GetWord(List<string> keywords)
{
    Random random = new Random();
    int num = random.Next(keywords.Count);
    List<string> chosenWord = [];
    string yo = keywords[num];
    char[] g = yo.ToCharArray();
    foreach (char c in g)
    {
        chosenWord.Add(c.ToString());
    }
    return chosenWord;
}

string GetGuess()
{
    Console.WriteLine("Enter a character: ");
    string guess = Console.ReadLine();
    return guess;
}

bool isCorrect(string guess, List<string> chosenWord)
{
    if (chosenWord.Contains(guess))
    {
        Console.WriteLine("You got a correct character!");
        Console.WriteLine($"Correct character was {guess}");
        correctGuess.Add(guess);
        Console.WriteLine("Correct guesses so far include...");
        Console.Write(string.Join("", correctGuess));
        tryCounter++;
        return true;
    }
    else
    {
        tryCounter++;
        return false;
    }
}

bool ifWon(List<string> correctGuess, List<string> chosenWord)
{
    List<string> reorderedCorrectGuess = new List<string>();
    foreach (var item in chosenWord)
    {
        if (correctGuess.Contains(item))
        {
            reorderedCorrectGuess.Add(item);
        }
    }

    Console.WriteLine("Correct Guess (Reordered):");
    Console.WriteLine(string.Join("", reorderedCorrectGuess));

    if (chosenWord.SequenceEqual(reorderedCorrectGuess))
    {
        Console.WriteLine("Congratulations! You've guessed the word correctly!");
        return true;
    }

    return false;
}

Main();