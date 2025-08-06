namespace FlashcardApi.Models;

public class Card
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Front { get; set; } = string.Empty;
    public string Back { get; set; } = string.Empty;
}
