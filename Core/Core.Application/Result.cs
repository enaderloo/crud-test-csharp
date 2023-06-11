namespace Core.Application;

public class Result
{
    public Result()
    {
        IsSucceeded = true;
    }

    public bool IsSucceeded { get; set; }
    public string ErrorMessages { get; protected set; }
    public string DevMessages { get; protected set; }
    public object Payload { get; set; }

    public virtual void SetError(string error, bool isDev = false)
    {
        IsSucceeded = false;

        if (isDev)
            DevMessages = error;
        else
            ErrorMessages = error;
    }
}