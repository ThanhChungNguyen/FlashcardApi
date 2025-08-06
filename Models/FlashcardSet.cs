namespace FlashcardApi.Models;

public class FlashcardSet
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public List<Card> Cards { get; set; } = new();
}
