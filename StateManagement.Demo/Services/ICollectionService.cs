namespace StateManagement.Demo.Services;

public interface ICollectionService
{
    public Task<CollectionsStore.Collection[]> GetCollections();
    public Task<CollectionsStore.CurrentCollection> GetCollectionData(string collectionId);
}