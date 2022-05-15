namespace SoftBox.DataBase.InterfacesEntities;

public interface INamedEntity<T> : IEntity<T>
{
    string Name { get; set; }
}
