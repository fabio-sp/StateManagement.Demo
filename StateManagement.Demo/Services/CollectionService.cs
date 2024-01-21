namespace StateManagement.Demo.Services;

public class CollectionService : ICollectionService
{
    private static readonly Collection[] Collections =
    {
        new("id-1", "ordini"),
        new("id-2", "fatture"),
        new("id-3", "clienti")
    };

    public Task<Collection[]> GetCollections()
        => Task.FromResult(Collections);

    public Task<CurrentCollection> GetCollectionData(string collectionId)
    {
        var collection = Collections.FirstOrDefault(c => c.Id == collectionId);
        if (collection is not null)
            return Task.FromResult(new CurrentCollection(collection.Id, collection.Name, []));
        throw new ApplicationException($"No collection found for Id {collectionId}");
    }
}