int[] generatedDigits = Enumerable.Range(1, 6).OrderBy(c => Guid.NewGuid()).Take(4).ToArray();
 
for (var a = 0; a < 10; a++)
{
    Console.WriteLine("Enter four digits between 1 and 6: ");
    string? enteredString = Console.ReadLine();

    try {
        var enteredDigits = enteredString?.ToCharArray().Select(c => byte.Parse(c.ToString())).ToArray();
        var valuesCorrect = new Dictionary<int, string>();
        if (enteredDigits == null || enteredDigits.Count() != 4 || enteredDigits.Any(e => e > 6))
        {
            a = RetryPlay(a);
            continue;
        }
        for (int i = 0; i < enteredDigits?.Length; i++)
        {
            int enteredDigit = enteredDigits[i];
            if (enteredDigit == generatedDigits[i])
            {
                valuesCorrect.Add(-(i+1), "+");
            }
            else if (generatedDigits.Contains(enteredDigit))
            {
                valuesCorrect.Add(i+1, "-");
            }
        }

        if(valuesCorrect.Count == 0)
            Console.WriteLine("No correct digits.");
        else 
            Console.WriteLine(String.Join(" ", valuesCorrect.OrderBy(v => v.Key).Select(v => v.Value)));

        if(valuesCorrect.Count() == 4 && valuesCorrect.All(v => v.Key < 0))
        {
            Console.WriteLine("You won the game!");
            break;
        } 
        else if (a == 9){
            Console.WriteLine("You lost the game.");            
        }
    }
    catch {
       a = RetryPlay(a);
       continue;
    }
}

static int RetryPlay(int a) {
    Console.WriteLine("Please only enter numbers between 1 and 6.");
    a--; //to retry current play
    return a;
}
