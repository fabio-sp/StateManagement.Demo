namespace StateManagement.Demo.Store;

public class CollectionStateService(ICollectionService collectionService) : ICollectionStateService
{
    public event Action CollectionsChanged;
    
    public List<Collection> AvailableCollections { get; } = new();
    public List<CollectionDetails> DashboardCollections { get; } = new();

    public async Task LoadAvailableCollections()
    {
        var collections = await collectionService.GetAll();
        AvailableCollections.Clear();
        AvailableCollections.AddRange(collections);
        OnCollectionsChanged();
    }
    
    public async Task OpenCollection(string collectionId)
    {
        var currentCollection = await collectionService.Get(collectionId);
        DashboardCollections.Add(currentCollection);
        OnCollectionsChanged();
    }

    private void OnCollectionsChanged()
    {
        CollectionsChanged?.Invoke();
    }
}