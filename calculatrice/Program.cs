
void Ccolor(string color = "white")
{
    switch (color)
    {
        case "green":
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case "white":
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case "red":
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case "blue":
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case "yellow":
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        default:
            break;
    }
}
double Addition(double valueA , double valueB)
{
    return valueA + valueB;
}
double Substract(double valueA, double valueB)
{
    return valueA - valueB;
}
double Multiply(double valueA, double valueB)
{
    return valueA * valueB;
}
double Divide(double valueA, double valueB)
{
    return valueA / valueB;
}
double Modulo(double valueA, double valueB)
{
    return valueA % valueB;
}
double operationHandler(List<string> operationToHandle)
{
    double totalOutput;
    totalOutput = 0;
    for (int i = 0; i < operationToHandle.Count; i++)
    {
        if(i % 2 != 0)
        {
            double parseout;
            bool parseBool;
            parseBool = double.TryParse(operationToHandle[i + 1], out parseout);
            if (!parseBool)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERREUR {operationToHandle[i + 1]} n'est pas valide a cette endroit(position: {i + 2} )");
                Console.BackgroundColor = ConsoleColor.Black;
                continue;
            }
            parseBool = double.TryParse(operationToHandle[i - 1], out parseout);
            if (!parseBool)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERREUR {operationToHandle[i - 1]} n'est pas valide a cette endroit(position: {i} )");
                Console.BackgroundColor = ConsoleColor.Black;
                continue;
            }
            if (i == 1)
            {
                if (operationToHandle[i] == "+")
                {
                    totalOutput = Addition(double.Parse(operationToHandle[i + 1]), double.Parse(operationToHandle[i - 1]));
                }
                else if(operationToHandle[i] == "-")
                {
                    totalOutput = Substract(double.Parse(operationToHandle[i + 1]), double.Parse(operationToHandle[i - 1]));
                }
                else if (operationToHandle[i] == "x" || operationToHandle[i] == "X")
                {
                    totalOutput = Multiply(double.Parse(operationToHandle[i + 1]), double.Parse(operationToHandle[i - 1]));
                }
                else if (operationToHandle[i] == "/")
                {
                    totalOutput = Divide(double.Parse(operationToHandle[i + 1]), double.Parse(operationToHandle[i - 1]));
                }
                else if (operationToHandle[i] == "%")
                {
                    totalOutput = Modulo(double.Parse(operationToHandle[i + 1]), double.Parse(operationToHandle[i - 1]));
                }
            }
            else if(i > 1)
            {
                if (operationToHandle[i] == "+")
                {
                    totalOutput = Addition(totalOutput, double.Parse(operationToHandle[i + 1]));
                }
                else if (operationToHandle[i] == "-")
                {
                    totalOutput = Substract(totalOutput, double.Parse(operationToHandle[i + 1]));
                }
                else if (operationToHandle[i] == "x")
                {
                    totalOutput = Multiply(totalOutput, double.Parse(operationToHandle[i + 1]));
                }
                else if (operationToHandle[i] == "/")
                {
                    totalOutput = Divide(totalOutput, double.Parse(operationToHandle[i + 1]));
                }
                else if (operationToHandle[i] == "%")
                {
                    totalOutput = Modulo(totalOutput, double.Parse(operationToHandle[i - 1]));
                }
            }
        }
    }
    return totalOutput;
}
void ShowList(List<string> ListToHandle)
{
    Console.WriteLine("--- Voici la liste des operation faite ----");
    for(int i = 0; i < ListToHandle.Count; i++)
    {
        Console.WriteLine($"{ListToHandle[i]}");
    }
}
bool programEnd;
Ccolor("green");
Console.WriteLine("Bienvenue dand votre calculatrice personelle dernier generation\n---------------------------------------------------------\n-----Instruction----\nPour utilisé la Calculatrice rien de plus simple entrée simplement\nvotre nombre, un espace, l'opperande, un espace , votre deuxiémme nombre puis le troisiémme....\nattention les operation se feront de gauche a droite dans l'ordre\n\npour demarer appuyer sur une touche");
Console.WriteLine("");
Console.ReadKey();
programEnd = false;
Console.Clear();
Ccolor();
List<string> historiqueDesOperation = new List<string>();
 
do
{
    Console.Clear();
    List<string> operationEnCours ;
    string operation;

    Console.WriteLine("---- Menu principales ----\n x = Multiplication \n + = Addition\n / = division\n - = Soustraction\n % = dModulo");
    Console.WriteLine("--Commande annexe--\n Quitter = Quitter\n Liste = Liste des précedent operation");
    Console.Write("Entrer votre operation: ");
    operation = Console.ReadLine();
    if(operation == null || operation == "")
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("ERREUR vous n'avez rien entrée");
        Console.BackgroundColor = ConsoleColor.Black;
        continue;
    }
    operationEnCours = new List<string>(operation.Split(" ")) ;
    if (operationEnCours[0] == "Quitter")
    {
        Ccolor("green");
        Console.WriteLine("Au revoir");
        programEnd = true;
        Console.ReadKey();
    }
    else if (operationEnCours[0] == "Liste")
    {
        Ccolor("green");
        ShowList(historiqueDesOperation);
        Ccolor("white");
        Console.ReadKey();
    }
    else if (operationEnCours.Count >= 3)
    {
        Console.WriteLine($"Resultat : {operationHandler(operationEnCours)}");
        historiqueDesOperation.Add($"{operation} = {operationHandler(operationEnCours)}");
        Console.ReadKey();
    }
    else if(operationEnCours.Count < 3) 
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("ERREUR pas assez de donnée dans le prompte!");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ReadKey();
        continue;
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("ERREUR Commande non reconue!");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ReadKey();
        continue;
    }
    

} while (programEnd != true);
