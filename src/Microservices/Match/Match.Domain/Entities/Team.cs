namespace Match.Domain.Entities;

public class Team
{
    private Team() { }

    public Team(string name, string? imagePath = null)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Team name is required.");

        Name = name.Trim();
        Image = imagePath;
    }

    public Team(int id, string name, string? imagePath = null)
        : this(name, imagePath)
    {
        Id = id;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Image { get; private set; }

    public ICollection<Match> HomeMatches { get; private set; }
    public ICollection<Match> AwayMatches { get; private set; }

    public void Rename(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Team name is required.", nameof(name));

        Name = name.Trim();
    }

    public void ChangeImage(string? imagePath)
    {
        Image = imagePath;
    }
}
