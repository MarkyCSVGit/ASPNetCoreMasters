using Services.DTO;
using AutoMapper;
using DomainModels;
using Repositories;
using Services.Data;

namespace Services;

public class ItemExistService
{
  readonly AppDbContext _context;

  public ItemExistService(AppDbContext context)
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
