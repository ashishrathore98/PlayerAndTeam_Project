using System;
using System.Collections.Generic;

class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int PlayerAge { get; set; }
}

interface ITeam
{
    void Add(Player player);
    void Remove(int playerId);
    Player GetPlayerById(int playerId);
    Player GetPlayerByName(string playerName);
    List<Player> GetAllPlayers();
}

class OneDayTeam : ITeam
{
    public static List<Player> oneDayTeam = new List<Player>();

    public OneDayTeam()
    {
        oneDayTeam.Capacity = 11;
    }

    public void Add(Player player)
    {
        if (oneDayTeam.Count < 11)
        {
            oneDayTeam.Add(player);
            Console.WriteLine("Player added successfully.");
        }
        else
        {
            Console.WriteLine("Cannot add more than 11 players.");
        }
    }

    public void Remove(int playerId)
    {
        Player playerToRemove = oneDayTeam.Find(player => player.PlayerId == playerId);
        if (playerToRemove != null)
        {
            oneDayTeam.Remove(playerToRemove);
            Console.WriteLine("Player removed successfully.");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }

    public Player GetPlayerById(int playerId)
    {
        return oneDayTeam.Find(player => player.PlayerId == playerId);
    }

    public Player GetPlayerByName(string playerName)
    {
        return oneDayTeam.Find(player => player.PlayerName == playerName);
    }

    public List<Player> GetAllPlayers()
    {
        return oneDayTeam;
    }
}

class Program
{
    static void Main(string[] args)
    {
        OneDayTeam team = new OneDayTeam();

        while (true)
        {
            Console.WriteLine("Enter 1: To Add Player, 2: To Remove Player by Id, 3: Get Player By Id,");
            Console.WriteLine("4: Get Player by Name, 5: Get All Players, 6: Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Player newPlayer = new Player();
                    Console.Write("Enter Player Id: ");
                    newPlayer.PlayerId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Player Name: ");
                    newPlayer.PlayerName = Console.ReadLine();
                    Console.Write("Enter Player Age: ");
                    newPlayer.PlayerAge = Convert.ToInt32(Console.ReadLine());
                    team.Add(newPlayer);
                    break;

                case 2:
                    Console.Write("Enter Player Id to Remove: ");
                    int playerIdToRemove = Convert.ToInt32(Console.ReadLine());
                    team.Remove(playerIdToRemove);
                    break;

                case 3:
                    Console.Write("Enter Player Id to Get: ");
                    int playerIdToGet = Convert.ToInt32(Console.ReadLine());
                    Player playerById = team.GetPlayerById(playerIdToGet);
                    if (playerById != null)
                    {
                        Console.WriteLine($"Player: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Player Name to Get: ");
                    string playerNameToGet = Console.ReadLine();
                    Player playerByName = team.GetPlayerByName(playerNameToGet);
                    if (playerByName != null)
                    {
                        Console.WriteLine($"Player: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;

                case 5:
                    List<Player> allPlayers = team.GetAllPlayers();
                    foreach (Player player in allPlayers)
                    {
                        Console.WriteLine($"Player: {player.PlayerName}, Age: {player.PlayerAge}");
                    }
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
