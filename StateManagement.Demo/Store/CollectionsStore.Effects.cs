namespace StateManagement.Demo.Store;

public partial class CollectionsStore
{
    private readonly ICollectionService _collectionService;
    private readonly IConversationService _conversationService;
    private readonly ILogger<CollectionsStore> _logger;
    
    public CollectionsStore(ICollectionService collectionService, ILogger<CollectionsStore> logger, IConversationService conversationService)
    {
        _collectionService = collectionService;
        _logger = logger;
        _conversationService = conversationService;
    }

    [EffectMethod]
    public async Task HandleLoadCollectionsAction(LoadCollectionsAction action, IDispatcher dispatcher)
    {
        var collections = await _collectionService.GetCollections();
        dispatcher.Dispatch(new UpdateCollectionsAction(collections));
    }

    [EffectMethod]
    public async Task HandleOpenCollectionAction(OpenCollectionAction action, IDispatcher dispatcher)
    {
        try
        {
            var currentCollection = await _collectionService.GetCollectionData(action.CollectionId);
            dispatcher.Dispatch(new AddCurrentCollectionToDashboardAction(currentCollection));
        }
        catch(Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }

    [EffectMethod]
    public Task HandleAskQuestionAction(AskQuestionAction action, IDispatcher dispatcher)
    {
        var collectionId = _conversationService.GetCollectionToOpen(action.Text);
        if (collectionId is not null)
            dispatcher.Dispatch(new OpenCollectionAction(collectionId));

        return Task.CompletedTask;
    }
}