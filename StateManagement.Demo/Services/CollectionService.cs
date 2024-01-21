namespace StateManagement.Demo.Services;

public class CollectionService : ICollectionService
{
    private static Collection[] _collections =
    {
        new("id-1", "ordini"),
        new("id-2", "fatture"),
        new("id-3", "clienti")
    };

    public Task<Collection[]> GetCollections()
        => Task.FromResult(_collections);

    public Task<CurrentCollection> GetCollectionData(string collectionId)
    {
        var collection = _collections.FirstOrDefault(c => c.Id == collectionId);
        if (collection is not null)
            return Task.FromResult(new CurrentCollection(collection.Id, collection.Name, new List<CollectionDataRow>()));
        throw new ApplicationException($"No collection found for Id {collectionId}");
    }
}