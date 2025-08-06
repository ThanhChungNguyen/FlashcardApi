using FlashcardApi.Models;

namespace FlashcardApi.Services;

public class FlashcardRepository
{
    private readonly List<FlashcardSet> _sets = new();

    public IEnumerable<FlashcardSet> GetAll() => _sets;

    public FlashcardSet? GetById(string id) =>
        _sets.FirstOrDefault(s => s.Id == id);

    public FlashcardSet Add(string title)
    {
        var set = new FlashcardSet { Title = title };
        _sets.Add(set);
        return set;
    }

    public bool Update(FlashcardSet updated)
    {
        var index = _sets.FindIndex(s => s.Id == updated.Id);
        if (index == -1) return false;
        _sets[index] = updated;
        return true;
    }

    public bool Delete(string id)
    {
        var set = GetById(id);
        if (set is null) return false;
        _sets.Remove(set);
        return true;
    }
}
