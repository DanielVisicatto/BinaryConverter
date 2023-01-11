using BinaryConverter.Entities;

int userOption = 0;
while(userOption >= 0 && userOption != 3)
{
    Console.WriteLine("\n" + "------------------------------\n" + "Select you option:\n" + "\n" + "1 - Decodify your Binary Code to text\n" + "2 - Codify your text to Binary Code\n" + "3 - Exit Program");

    if (!int.TryParse(Console.ReadLine(), out userOption))
    {
        Console.WriteLine("Your input needs to be an valid int number...");
    }
    else
    {
        string input, output; 
        Characters characters = new();

        switch (userOption)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Enter your binary code here...");
                input = Console.ReadLine().Replace(" ", string.Empty);
                output = "";                

                for (int i = 0; i < input.Length; i += 8)
                {
                    string binaryValue = input.Substring(i, 8);
                    char asciiCharacter;
                    if (characters.binaryCodeDictionary.TryGetValue(binaryValue, out asciiCharacter))
                    {
                        output += asciiCharacter;
                    }
                }
                Console.WriteLine("\nYour code returns...\n\n******************************\n\n{0}\n\n******************************",
                    output);
                break;

            case 2:
                Console.Clear();
                Console.WriteLine("Enter your ASCII code here...");
                input = Console.ReadLine();
                output = "";

                foreach (char c in input)
                {
                    string binaryValue = string.Empty;
                    
                    foreach (var entry in characters.binaryCodeDictionary)
                    {
                        if (entry.Value == c)
                        {
                            binaryValue = entry.Key;
                            break;
                        }
                    }

                    output += binaryValue;
                }

                Console.WriteLine("\nBinary representation of the input string:\n******************************\n\n");
                
                for (int i = 0; i < output.Length; i += 8)
                {
                    string binaryValue = output.Substring(i, 8);
                    Console.Write("{0} ", binaryValue);
                }
                Console.WriteLine("\n\n ******************************");                

                break;

            case 3:
                Console.Clear();
                Console.WriteLine("------------------------------\n" + "Exiting program...\n" + "------------------------------\n");
                break;
        }
    }
}