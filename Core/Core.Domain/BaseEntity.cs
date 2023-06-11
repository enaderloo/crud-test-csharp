using MediatR;

namespace Core.Domain;

public abstract class BaseEntity<PrimaryKeyType>
{
    int? _requestedHashCode;
    public PrimaryKeyType Id { get; set; }

    public bool IsTransient()
    {
        return Id is null || Id.Equals(default(PrimaryKeyType));
    }
    public override bool Equals(object obj)
    {
        if (obj is null || obj is not BaseEntity<PrimaryKeyType>)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        BaseEntity<PrimaryKeyType> item = (BaseEntity<PrimaryKeyType>)obj;

        if (item.IsTransient() || IsTransient())
            return false;

        return item.Id!.Equals(Id);
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id!.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }
    public static bool operator ==(BaseEntity<PrimaryKeyType> left, BaseEntity<PrimaryKeyType> right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(BaseEntity<PrimaryKeyType> left, BaseEntity<PrimaryKeyType> right)
    {
        return !(left == right);
    }
    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();



    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= new();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

}
