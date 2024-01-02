namespace WakuWakuAPI.Domain.Models;
public class Category {
    private static int lastId = 0;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Category(string name, string description) {
        this.Id = ++lastId;
        this.Name = name;
        this.Description = description;
    }
}
