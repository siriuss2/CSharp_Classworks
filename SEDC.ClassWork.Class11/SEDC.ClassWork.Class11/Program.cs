using Newtonsoft.Json;
using SEDC.ClassWork.Class11.Entities;
using SEDC.ClassWork.Class11.ReaderWriter;

string folderPath = @"..\..\..\Exercise\";
string filePath = folderPath + "exercise.json";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}
List<Dog> dogs = new List<Dog>();

while (true)
{
    Console.WriteLine("Enter the name of the dog:");
    string userInputForDogName = Console.ReadLine();

    Console.WriteLine("Enter the age of the dog:");
    int userInputForDogAge = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the color of the dog:");
    string userInputForDogColor = Console.ReadLine();

    Dog dog1 = new Dog(userInputForDogName, userInputForDogAge, userInputForDogColor);
    dogs.Add(dog1);

    string serializedDogs = JsonConvert.SerializeObject(dogs);

    ReaderWriter.WriteFile(filePath, serializedDogs);

    string exerciseData = ReaderWriter.ReadFile(filePath);
    List<Dog> deserializedDogs = JsonConvert.DeserializeObject<List<Dog>>(exerciseData);

    Console.WriteLine("Y to continue , N to exit");
    string userInput = Console.ReadLine();

    if (userInput.ToLower() == "y")
    {
        Console.Clear();
        continue;
    }
    else
        break;
}

