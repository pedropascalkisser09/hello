using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MazeGame
{
    static char[,] maze;
    static int playerX, playerY, exitX, exitY;
    static Random rand = new Random();
    static string paragraph = "(note: if may typo ako sorry in advance nakakaduling mag type sa c#) hi lovey! happy 1 year and 3 months to us :) medyo matagal ko na pinapractice gawin to ang advance na nga medyo sa current lessons namin ahhahaha but i already studied a few of the codes dito so no worries. i just wanted to say thank you for being in my life. i've known you for so long and i want to add more years to that. i know we've had some shortcomings these days, but that won't stop me from learning something new for you just to make you smile, even for a second, that smile is worth everything. this isn't a major milestone, but i'm still gonna do something extra like this as always hehe. i genuinely hope you find peace and happiness with yourself and for you to heal from all the things you've been through, even the stuff you don't tell me. i'm your best friend, your lover, your number one kaasaran and number 2 fan (kasi sabi mo dad mo yung 1). i love you so much that even something as bland as coding makes me feel giddy inside, basta i'm making it for you it already feels special. thank you again baby for understanding me even when the world seems to pull us apart. if the world is against us, then i'm ready to turn against the world. again, happy 1 year and 3 months to us. each second of my life is devoted to loving and missing you. xoxo";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Play?");
            Console.Write("yes?: ");
            string choice = Console.ReadLine();

            if (choice == "yes")
            {
                GenerateMaze(20, 20); // Generate a 20x20 maze
                PlayGame();
            }
        }
    }

    static void GenerateMaze(int width, int height)
    {
        maze = new char[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                maze[i, j] = (rand.Next(0, 4) == 0) ? '#' : ' ';
            }
        }

        playerX = 0; // Set playerX to 0
        playerY = 0; // Set playerY to 0
        maze[playerX, playerY] = 'O';

        exitX = width - 1;
        exitY = height - 1;
        maze[exitX, exitY] = 'X';
    }

    static void PlayGame()
    {
        while (true)
        {
            Console.Clear();
            PrintMaze();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            MovePlayer(keyInfo.Key);

            if (playerX == exitX && playerY == exitY)
            {
                Console.Clear();
                Console.WriteLine("congrats! good job.");
                Console.WriteLine("1. play again");
                Console.WriteLine("2. secret (surprise....)");
                Console.Write("choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    GenerateMaze(20, 20);
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine(paragraph);
                    Console.WriteLine("\npress any key to go back to the menu...");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }

    static void PrintMaze()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                Console.Write(maze[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void MovePlayer(ConsoleKey key)
    {
        int newX = playerX, newY = playerY;

        switch (key)
        {
            case ConsoleKey.W:
                newX = playerX - 1;
                break;
            case ConsoleKey.S:
                newX = playerX + 1;
                break;
            case ConsoleKey.A:
                newY = playerY - 1;
                break;
            case ConsoleKey.D:
                newY = playerY + 1;
                break;
        }

        if (newX >= 0 && newX < maze.GetLength(0) && newY >= 0 && newY < maze.GetLength(1) && maze[newX, newY] != '#')
        {
            maze[playerX, playerY] = ' ';
            playerX = newX;
            playerY = newY;
            maze[playerX, playerY] = 'O';
        }
    }
}
