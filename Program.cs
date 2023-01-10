using BinaryConverter.Entities;

Console.WriteLine("Paste you binary code here...");
string input = Console.ReadLine().Replace(" ", string.Empty);
string output = "";

Characters characters = new();

for (int i = 0; i < input.Length; i += 8)
{
    string binaryValue = input.Substring(i, 8);
    char asciiCharacter;
    if ( characters.binaryCodeDictionary.TryGetValue(binaryValue, out asciiCharacter))
    {
        output += asciiCharacter;
    }
}
Console.WriteLine("\nYour code returns...\n\n******************************\n\n{0}\n\n******************************",
    output);