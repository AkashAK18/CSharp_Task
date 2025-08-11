using System;

public class LimitReachedException : Exception
{
    public LimitReachedException(string message) : base(message)
    {
    }
}
