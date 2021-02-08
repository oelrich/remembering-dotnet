using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Items.Controllers
{
  public class ItemsController
  {
    #region Constructor
    private readonly ItemsContext _context;

    public ItemsController(ItemsContext context)
        => _context = context;
    #endregion

    #region Get

    public IEnumerable<Item> Get()
        => _context.Set<Item>().Include(e => e.Tags).OrderBy(e => e.Name);

    public Item Get(string itemName)
        => _context.Set<Item>().Include(e => e.Tags).FirstOrDefault(e => e.Name == itemName);
    #endregion

    #region PostItem
    public Item PostItem(string itemName)
    {
      var item = _context.Add(new Item(itemName)).Entity;

      _context.SaveChanges();

      return item;
    }
    #endregion

    #region PostTag
    public Tag PostTag(string itemName, string tagLabel)
    {
      var tag = _context
          .Set<Item>()
          .Include(e => e.Tags)
          .Single(e => e.Name == itemName)
          .AddTag(tagLabel);

      _context.SaveChanges();

      return tag;
    }
    #endregion

    #region DeleteItem
    public Item DeleteItem(string itemName)
    {
      var item = _context
          .Set<Item>()
          .SingleOrDefault(e => e.Name == itemName);

      if (item == null)
      {
        return null;
      }

      _context.Remove(item);
      _context.SaveChanges();

      return item;
    }
    #endregion
  }
}