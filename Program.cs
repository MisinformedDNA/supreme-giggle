using System;
using System.Threading;

namespace AmusingConsole;

class Program
{
    private static readonly Random random = new();
    
    static void Main(string[] args)
    {
        Console.Clear();
        ShowWelcomeAnimation();
        
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadKey(true);
            
            Console.Clear();
            
            switch (choice.KeyChar)
            {
                case '1':
                    ShowAsciiArt();
                    break;
                case '2':
                    TellJokes();
                    break;
                case '3':
                    PlayRockPaperScissors();
                    break;
                case '4':
                    ShowMatrixEffect();
                    break;
                case '5':
                    ColorfulText();
                    break;
                case '6':
                    RandomQuoteGenerator();
                    break;
                case 'q':
                case 'Q':
                    ShowFarewell();
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
    
    static void ShowWelcomeAnimation()
    {
        var title = @"
    ╔═══════════════════════════════════════════╗
    ║           🎭 AMUSING CONSOLE 🎭           ║
    ║         Your Daily Dose of Fun!          ║
    ╚═══════════════════════════════════════════╝
        ";
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (char c in title)
        {
            Console.Write(c);
            if (c != ' ' && c != '\n' && c != '\r')
                Thread.Sleep(20);
        }
        Console.ResetColor();
        Thread.Sleep(1000);
    }
    
    static void ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🎮 ENTERTAINMENT MENU 🎮");
        Console.WriteLine("========================");
        Console.ResetColor();
        
        Console.WriteLine("1. 🎨 ASCII Art Gallery");
        Console.WriteLine("2. 😂 Joke Generator");
        Console.WriteLine("3. ✂️ Rock Paper Scissors");
        Console.WriteLine("4. 🔮 Matrix Effect");
        Console.WriteLine("5. 🌈 Colorful Text Demo");
        Console.WriteLine("6. 💭 Inspirational Quotes");
        Console.WriteLine("Q. 👋 Quit");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nChoose your entertainment: ");
        Console.ResetColor();
    }
    
    static void ShowAsciiArt()
    {
        var arts = new[]
        {
            @"
       /\_/\  
      ( o.o ) 
       > ^ <
    ",
            @"
    \\    /\\
     )  ( ')
    (  /  )
     \(__)|
    ",
            @"
      .-""-.
     /      \
    |  o   o  |
     \   >   /
      '.___.'
    ",
            @"
        ___
       (   )
      /  _  \
     | (_) |
      \___/
    ",
            @"
       🚀
      /|\
     / | \
    🌟 | 🌟
       |
      / \
     👽   👽
    "
        };
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎨 ASCII Art Gallery 🎨");
        Console.WriteLine("========================");
        Console.ResetColor();
        
        foreach (var art in arts)
        {
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 16);
            Console.WriteLine(art);
            Thread.Sleep(1500);
        }
        
        Console.ResetColor();
    }
    
    static void TellJokes()
    {
        var jokes = new[]
        {
            ("Why don't scientists trust atoms?", "Because they make up everything! 🧪"),
            ("Why did the programmer quit his job?", "He didn't get arrays! 💻"),
            ("What do you call a fake noodle?", "An impasta! 🍝"),
            ("Why don't eggs tell jokes?", "They'd crack each other up! 🥚"),
            ("What's the best thing about Switzerland?", "I don't know, but the flag is a big plus! 🇨🇭"),
            ("Why do programmers prefer dark mode?", "Because light attracts bugs! 🐛"),
            ("How do you organize a space party?", "You planet! 🚀"),
            ("What did the ocean say to the beach?", "Nothing, it just waved! 🌊")
        };
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("😂 Joke Generator 😂");
        Console.WriteLine("===================");
        Console.ResetColor();
        
        var joke = jokes[random.Next(jokes.Length)];
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Q: {joke.Item1}");
        Console.Write("Press any key for the punchline...");
        Console.ReadKey();
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Green;
        TypeWriterEffect($"A: {joke.Item2}");
        Console.ResetColor();
    }
    
    static void PlayRockPaperScissors()
    {
        var choices = new[] { "Rock 🪨", "Paper 📄", "Scissors ✂️" };
        var playerWins = 0;
        var computerWins = 0;
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("✂️ Rock Paper Scissors ✂️");
        Console.WriteLine("=========================");
        Console.ResetColor();
        
        for (int round = 1; round <= 3; round++)
        {
            Console.WriteLine($"\nRound {round}:");
            Console.WriteLine("1. Rock 🪨");
            Console.WriteLine("2. Paper 📄");
            Console.WriteLine("3. Scissors ✂️");
            Console.Write("Your choice (1-3): ");
            
            var playerInput = Console.ReadKey().KeyChar;
            Console.WriteLine();
            
            if (!char.IsDigit(playerInput) || playerInput < '1' || playerInput > '3')
            {
                Console.WriteLine("Invalid choice! Computer wins this round.");
                computerWins++;
                continue;
            }
            
            var playerChoice = int.Parse(playerInput.ToString()) - 1;
            var computerChoice = random.Next(3);
            
            Console.WriteLine($"You chose: {choices[playerChoice]}");
            Console.WriteLine($"Computer chose: {choices[computerChoice]}");
            
            if (playerChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((playerChoice == 0 && computerChoice == 2) ||
                     (playerChoice == 1 && computerChoice == 0) ||
                     (playerChoice == 2 && computerChoice == 1))
            {
                Console.WriteLine("You win this round! 🎉");
                playerWins++;
            }
            else
            {
                Console.WriteLine("Computer wins this round! 🤖");
                computerWins++;
            }
        }
        
        Console.WriteLine("\n" + new string('=', 30));
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (playerWins > computerWins)
            Console.WriteLine("🏆 YOU WIN! Congratulations! 🏆");
        else if (computerWins > playerWins)
            Console.WriteLine("🤖 COMPUTER WINS! Better luck next time! 🤖");
        else
            Console.WriteLine("🤝 IT'S A TIE! Great game! 🤝");
        
        Console.ResetColor();
    }
    
    static void ShowMatrixEffect()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🔮 Matrix Effect 🔮");
        Console.WriteLine("===================");
        Console.WriteLine("Press any key to stop...\n");
        
        var width = Console.WindowWidth;
        var height = Console.WindowHeight - 5;
        var drops = new int[width];
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$%^&*()";
        
        // Initialize drops
        for (int i = 0; i < drops.Length; i++)
            drops[i] = random.Next(height);
        
        var startTime = DateTime.Now;
        while (!Console.KeyAvailable && DateTime.Now - startTime < TimeSpan.FromSeconds(10))
        {
            for (int i = 0; i < drops.Length; i += 2)
            {
                Console.SetCursorPosition(i, drops[i]);
                Console.Write(chars[random.Next(chars.Length)]);
                
                drops[i]++;
                if (drops[i] > height)
                    drops[i] = 0;
            }
            
            Thread.Sleep(100);
        }
        
        if (Console.KeyAvailable)
            Console.ReadKey();
        
        Console.ResetColor();
    }
    
    static void ColorfulText()
    {
        Console.WriteLine("🌈 Colorful Text Demo 🌈");
        Console.WriteLine("========================");
        
        var message = "This is a rainbow text effect!";
        var colors = new[] 
        {
            ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green,
            ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta
        };
        
        for (int i = 0; i < message.Length; i++)
        {
            Console.ForegroundColor = colors[i % colors.Length];
            Console.Write(message[i]);
            Thread.Sleep(100);
        }
        
        Console.WriteLine();
        Console.ResetColor();
        
        // Blinking effect
        Console.WriteLine("\nBlinking text effect:");
        for (int blink = 0; blink < 6; blink++)
        {
            Console.ForegroundColor = blink % 2 == 0 ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write("✨ BLINKING TEXT ✨");
            Thread.Sleep(500);
            Console.Write("\r" + new string(' ', 20) + "\r");
            Thread.Sleep(200);
        }
        
        Console.ResetColor();
    }
    
    static void RandomQuoteGenerator()
    {
        var quotes = new[]
        {
            ("\"The only way to do great work is to love what you do.\"", "- Steve Jobs"),
            ("\"Life is what happens to you while you're busy making other plans.\"", "- John Lennon"),
            ("\"The future belongs to those who believe in the beauty of their dreams.\"", "- Eleanor Roosevelt"),
            ("\"In the middle of difficulty lies opportunity.\"", "- Albert Einstein"),
            ("\"It is during our darkest moments that we must focus to see the light.\"", "- Aristotle"),
            ("\"Success is not final, failure is not fatal: it is the courage to continue that counts.\"", "- Winston Churchill"),
            ("\"The only impossible journey is the one you never begin.\"", "- Tony Robbins"),
            ("\"Code is poetry.\"", "- Anonymous Programmer")
        };
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("💭 Inspirational Quote Generator 💭");
        Console.WriteLine("===================================");
        Console.ResetColor();
        
        var quote = quotes[random.Next(quotes.Length)];
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeWriterEffect(quote.Item1);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        TypeWriterEffect(quote.Item2);
        Console.ResetColor();
    }
    
    static void ShowFarewell()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        var farewell = @"
    ╔═══════════════════════════════════════════╗
    ║         👋 Thanks for Playing! 👋         ║
    ║                                           ║
    ║         Hope you had some fun! 🎉         ║
    ║                                           ║
    ║            Come back soon! 😊             ║
    ╚═══════════════════════════════════════════╝
        ";
        
        Console.WriteLine(farewell);
        Console.ResetColor();
        Thread.Sleep(2000);
    }
    
    static void TypeWriterEffect(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(50);
        }
    }
}