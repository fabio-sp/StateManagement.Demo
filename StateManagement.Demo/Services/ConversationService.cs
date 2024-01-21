namespace StateManagement.Demo.Services;

public class ConversationService(ICollectionStateService collectionStateService) : IConversationService
{
    public string GetCollectionToOpen(string question)
    {
        var words = question.Split(" ");
        
        for(var i = words.Length-1; i > 0; i--)
        {
            var word = words[i];
            var collection = collectionStateService
                .AvailableCollections
                .FirstOrDefault(c => c.Name.Contains(word, StringComparison.InvariantCultureIgnoreCase));

            if (collection is not null)
                return collection.Id;
        }

        return null;
    }
}