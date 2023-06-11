namespace Core.Application;

public abstract record BaseUpdateWithUserAndTimeStampCommand<T, PrimaryKeyType> : BaseUpdateWithUserCommand<T, PrimaryKeyType>, IBaseUpdateWithUserAndTimeStampCommand<T, PrimaryKeyType>
{
    public BaseUpdateWithUserAndTimeStampCommand(long timeStamp)
    {
        TimeStamp = timeStamp;
    }
    public long TimeStamp { get; set; }
}
