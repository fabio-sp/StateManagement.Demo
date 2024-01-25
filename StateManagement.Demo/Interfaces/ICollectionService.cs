namespace StateManagement.Demo.Interfaces;

public interface ICollectionService
{
    public Task<Collection[]> GetAll();
    public Task<CollectionDetails> Get(string collectionId);
}