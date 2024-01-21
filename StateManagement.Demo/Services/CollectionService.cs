namespace StateManagement.Demo.Services;

public class CollectionService : ICollectionService
{
    private static CollectionsStore.Collection[] _collections =
    {
        new("id-1", "ordini"),
        new("id-2", "fatture"),
        new("id-3", "clienti")
    };

    public Task<CollectionsStore.Collection[]> GetCollections()
        => Task.FromResult(_collections);

    public Task<CollectionsStore.CurrentCollection> GetCollectionData(string collectionId)
    {
        var collection = _collections.FirstOrDefault(c => c.Id == collectionId);
        if (collection is not null)
            return Task.FromResult(new CollectionsStore.CurrentCollection(collection.Id, collection.Name, new List<CollectionsStore.CollectionDataRow>()));
        throw new ApplicationException($"No collection found for Id {collectionId}");
    }
}