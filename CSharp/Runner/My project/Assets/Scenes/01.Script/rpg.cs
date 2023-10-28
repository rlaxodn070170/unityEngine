using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }

    public Character(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void AttackEnemy(Character enemy)
    {
        int damage = new Random().Next(0, Attack);
        Console.WriteLine($"{Name} attacks {enemy.Name} for {damage} damage.");
        enemy.TakeDamage(damage);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Simple RPG Game!");
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();
        Character player = new Character(playerName, 100, 10);
        Character enemy = new Character("Slime", 20, 5);

        while (player.IsAlive())
        {
            Console.WriteLine($"\nA wild {enemy.Name} appears!\n");
            while (enemy.IsAlive() && player.IsAlive())
            {
                Console.Write("Enter 'attack' to attack: ");
                string action = Console.ReadLine().ToLower();
                if (action == "attack")
                {
                    player.AttackEnemy(enemy);
                    if (enemy.IsAlive())
                    {
                        enemy.AttackEnemy(player);
                    }
                    Console.WriteLine($"{player.Name}'s health: {player.Health}");
                    Console.WriteLine($"{enemy.Name}'s health: {enemy.Health}\n");
                }
            }

            if (player.IsAlive())
            {
                Console.WriteLine($"You defeated the {enemy.Name}!\n");
            }
            else
            {
                Console.WriteLine($"{player.Name} was defeated!");
            }

            // You can add more features, levels, items, and complexity to the game.
        }

        Console.WriteLine("Game Over!");
    }
}
