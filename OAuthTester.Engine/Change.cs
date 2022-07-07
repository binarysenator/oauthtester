namespace OAuthTester.Engine;

public struct Change
{
    public static Change<T> Add<T>(T item)
    {
        return new Change<T>()
        {
            Item = item,
            Type = ChangeType.Added,
        };
    }
}

public struct Change<T>
{
    public ChangeType Type { get; set; }
    public T Item { get; set; }
}