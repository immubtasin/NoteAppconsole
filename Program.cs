List<string> notes = new List<string>();
string filePath = "notes.txt";

if (File.Exists(filePath))
{
    notes.AddRange(File.ReadAllLines(filePath));
}

while (true)
{
    Console.WriteLine("\nWelcome to my Note App!");
    Console.WriteLine("1. View Notes");
    Console.WriteLine("2. Add Note");
    Console.WriteLine("3. Delete Note");
    Console.WriteLine("0. Exit");

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    if (choice == "3")
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("No notes to delete!");
        }
        else
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + notes[i]);
            }

            Console.Write("Enter the note number to delete: ");
            string? noteNumber = Console.ReadLine();

            if (int.TryParse(noteNumber, out int number)
                && number >= 1 && number <= notes.Count)
            {
                notes.RemoveAt(number - 1);
                File.WriteAllLines(filePath, notes);
                Console.WriteLine("Note deleted!");
            }
            else
            {
                Console.WriteLine("Enter a valid note number.");
            }
        }
    }

    if (choice == "0")
    {
        File.WriteAllLines(filePath, notes);
        Console.WriteLine("Notes saved. Goodbye!");
        break;
    }

    if (choice == "2")
    {
        Console.Write("Enter your note: ");
        string? noteTitle = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(noteTitle))
        {
            Console.WriteLine("Note cannot be empty.");
        }
        else
        {
            notes.Add(noteTitle.Trim());
            File.WriteAllLines(filePath, notes);
            Console.WriteLine("Note added!");
        }
    }

    if (choice == "1")
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("You don't have any notes. Add one first.");
        }
        else
        {
            Console.WriteLine("Your notes:");

            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + notes[i]);
            }
        }
    }

    if (choice != "0" && choice != "1" && choice != "2" && choice != "3")
    {
        Console.WriteLine("Invalid option. Please choose 0, 1, 2, or 3.");
    }
}