using DGD203_game;
using System;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items;
    private string _buffer;
    private Player _owner;
    public Inventory(Player player)
    {
        Items = new List<Item>();
        _owner = player;
    }
    public void PickUp(Item item)
    {
        Console.WriteLine($"You obtained the {item}!");
        Items.Add(item);
    }
    public void RemoveItem(Item item) 
    {
        Items.Remove(item);
    }
    public void CheckItems()
    {
        if (this.Items.Count == 0)
        {
            Console.WriteLine("You have no items.");
            return;
        }
        Console.WriteLine("Here is your items:");
        for (int i = 0; i < this.Items.Count; i++)
            Console.WriteLine($"[{i+1}] {this.Items[i]}");
        Console.WriteLine("If you want to use any item, type the respective number. If not, just type 0.");
        _buffer = Console.ReadLine();
        while (!Equals(_buffer, "0"))
        {
            switch (_buffer)
            {
                case "1":
                    UseItem(this.Items[0]);
                    return;
                case "2":
                    if (Items.Count < 2)
                    {
                        Console.WriteLine("I don't understand.");
                        _buffer = Console.ReadLine();
                        break;
                    }
                    UseItem(this.Items[1]);
                    return;
                case "3":
                    if (Items.Count < 3)
                    {
                        Console.WriteLine("I don't understand.");
                        _buffer = Console.ReadLine();
                        break;
                    }
                    UseItem(this.Items[2]);
                    return;
                case "4":
                    if (Items.Count < 4)
                    {
                        Console.WriteLine("I don't understand.");
                        _buffer = Console.ReadLine();
                        break;
                    }
                    UseItem(this.Items[3]);
                    return;
                default:
                    Console.WriteLine("I don't understand.");
                    _buffer = Console.ReadLine();
                    break;
            }
        }
        Console.WriteLine("No action was taken.");
    }
    public void UseItem(Item item)
    {
        if (item == Item.SillyCatTea)
        {
            Console.WriteLine("Will you drink the tea?\n[1] Smells delicious!\n[2] No thank you.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                _owner.SillyCatSyndrome();
                this.RemoveItem(item);
            }
            else
                Console.WriteLine("Didn't take the sip.");
        }
        else
        {
            Console.WriteLine("Will you pet the cat?\n[1] Yes. Pet it well.\n[2] No.");
            _buffer = Console.ReadLine();
            while (!Equals(_buffer, "1") && !Equals(_buffer, "2"))
            {
                Console.WriteLine("What do you mean?");
                _buffer = Console.ReadLine();
            }
            if (Equals(_buffer, "1"))
            {
                Console.WriteLine("Cat purrs. How delightful. Cat goes away after giving you a little kiss on the forehead.");
                Program.score += 10;
                this.RemoveItem(item);
            }
            else
                Console.WriteLine("You have a hearth of stone.");
        }
    }
}
public enum Item
{
    SillyCatTea,
    OrangeCatHector,
    TuxedoCatBesiktas,
    CalicoCatBean
}