namespace StateManagement.Demo.Store;

public interface ICollectionStateService
{
    List<Collection> AvailableCollections { get; }
    List<CurrentCollection> CollectionsInDashboard { get; }
    Task OpenCollection(string collectionId);
    event Action CollectionsChanged;
    Task LoadAvailableCollections();
}