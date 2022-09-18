using Services.DTO;
using AutoMapper;
using DomainModels;
using Repositories;


namespace Services;

public class ItemExistService
{
  readonly DataContext _context;

  public ItemExistService(DataContext context)
  {
    _context = context;
  }

  public bool DoesItemExist(int id)
  {
    return _context.Items
        .Where(r => !r.IsDeleted)
        .Where(r => r.Id == id)
        .Any();
  }

 


}
