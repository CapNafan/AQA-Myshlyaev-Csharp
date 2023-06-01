using CommandLine;

namespace BaseTheory {
    class Program {
        public class Options {
            [Option("number", Required = false, HelpText = "Check if number is greater than 7.")]
            public int Number {get; set;}

            [Option("name", Required = false, HelpText = "Check if input name is 'Вячеслав'.")]
            public string? Name {get; set;}

            [Option("divisible", Required = false, HelpText = "Outputs elements of an input array that are divisible by 3")]
            public IEnumerable<int>? Numbers { get; set; }
        }

        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(options => {
                    if (options.Number > 7) Console.WriteLine("Привет");
                    
                    if (!string.IsNullOrEmpty(options.Name)) {
                        if (options.Name == "Вячеслав") Console.WriteLine($"Привет, {options.Name}");
                        else Console.WriteLine("Нет такого имени");
                    }

                    if (options.Numbers != null && options.Numbers.Any()) {
                        var divisibleNumbers = options.Numbers.Where(n => n % 3 == 0);
                        Console.Write("Divisible numbers: ");

                        foreach (var num in divisibleNumbers) {
                            Console.Write($"{num} ");
                        }
                        Console.WriteLine();
                    }
                });
        }
    }
}