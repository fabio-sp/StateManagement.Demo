namespace StateManagement.Demo.Services;

public class CollectionService : ICollectionService
{
    private static readonly Collection[] Collections =
    {
        new("id-1", "ordini"),
        new("id-2", "fatture"),
        new("id-3", "clienti")
    };

    public Task<Collection[]> GetAll()
        => Task.FromResult(Collections);

    public Task<CollectionDetails> Get(string collectionId)
    {
        var collection = Collections.FirstOrDefault(c => c.Id == collectionId);
        if (collection is not null)
            return Task.FromResult(new CollectionDetails(collection.Id, collection.Name, []));
        throw new ApplicationException($"No collection found for Id {collectionId}");
    }
}