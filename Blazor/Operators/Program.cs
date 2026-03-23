// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] words =
{
	"Красота", "среди", "бегущих", null, "Первых", "нет", "и", "отстающих"
};

for (int i = 0; i < words.Length; i++)
{
	Console.Write($"{words[i]} ");
}
Console.WriteLine(null);