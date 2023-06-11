namespace Core.Application;

public interface IBaseUpdateWithUserAndTimeStampCommand<T, PrimaryKeyType> : IBaseUpdateWithUserCommand<T, PrimaryKeyType>
{
    long TimeStamp { get; set; }
}
