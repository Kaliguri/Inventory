using System;

[Serializable]
public class Item
{
    public int ID;
    public int Count;

    public Item(int id, int count)
    {
        ID = id;
        Count = count;
    }

}

[Serializable]
public class Animal: Item
{
    public AnimalState State;
    public enum AnimalState
    {
        Normal,
        Wounded
    }

    public Animal(int id, int count, AnimalState state) : base(id, count)
    {
        State = state;
    }

}