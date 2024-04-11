namespace System;

public static class ExtendedSystem
{
    public static void WriteToConsole(this object objectToDisplay) => Console.Write(objectToDisplay);

    public static void WriteCollectionToConsole<T>(this ICollection<T> collectionToDisplay)
    {
        foreach (object item in collectionToDisplay)
        {
            Console.WriteLine(item);
        }
    }
}
