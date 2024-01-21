namespace StateManagement.Demo.Services;

public interface ICollectionService
{
    public Task<Collection[]> GetCollections();
    public Task<CurrentCollection> GetCollectionData(string collectionId);
}