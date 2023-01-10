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
                input = "";
                output = "";

                Console.WriteLine("Enter you text to convert to binary:");
                input = Console.ReadLine();

                foreach (char c in input)
                {
                    string binary = Convert.ToString(c, 2).PadLeft(8, '0');
                    for (int i = 0; i < binary.Length; i += 8)
                    {
                        string binaryValue = binary.Substring(i, 8);
                        output += binaryValue + " ";
                    }
                }

                Console.WriteLine("\nBinary representation of the input string:");
                Console.WriteLine("\n******************************\n\n{0}\n\n******************************", output);

                break;

            case 3:
                Console.Clear();
                Console.WriteLine("------------------------------\n" + "Exiting program...\n" + "------------------------------\n");
                break;
        }
    }
}