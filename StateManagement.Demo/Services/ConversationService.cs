namespace StateManagement.Demo.Services;

public class ConversationService(ICollectionStateService collectionService) : IConversationService
{
    public void HandleRequest(string query)
    {
        var words = query.Split(" ");
        
        for(var i = words.Length-1; i > 0; i--)
        {
            var word = words[i];
            var collection = collectionService
                .AvailableCollections
                .FirstOrDefault(c => c.Name.Contains(word, StringComparison.InvariantCultureIgnoreCase));

            if (collection is not null)
                collectionService.OpenCollection(collection.Id);
        }
    }
}