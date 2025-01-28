using AutoMapper;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using VM;

namespace Api.Repositories;

public interface IRequestRepository : IBaseRepository<Request>
{
    Task<int> GetCount(string userId, string serviceId, string status = "Succeed");
}
public class RequestRepository(DataContext db) : BaseRepository<Request>(db), IRequestRepository
{
    public async Task<int> GetCount(string userId, string serviceId, string status = "Succeed")
    {
        return await GetQuery().CountAsync(
            r => r.UserId == userId &&
            r.ServiceId == serviceId &&
            r.Status == status);
    }
}


public class LanguageRepository : BaseRepository<Language>
{
    public LanguageRepository(DataContext db) : base(db) { }

    public async Task<Language?> GetByCodeAsync(string code)
    {
        return await GetByAsync(x => x.Code == code);
    }
}

public class CategoryRepository : BaseRepository<CategoryModel>
{
    public CategoryRepository(DataContext db) : base(db) { }

    public async Task<CategoryModel?> GetByNameAsync(string name)
    {
        return await GetByAsync(x => x.Name == name);
    }
}

public class TypeRepository : BaseRepository<TypeModel>
{
    public TypeRepository(DataContext db) : base(db) { }

    public async Task<TypeModel?> GetByNameAsync(string name)
    {
        return await GetByAsync(x => x.Name == name);
    }

    public async Task<List<TypeModel>> GetActiveTypesAsync()
    {
        return await GetAllAsync(x => x.Active);
    }
}

public class DialectRepository : BaseRepository<Dialect>
{
    public DialectRepository(DataContext db) : base(db) { }

    public async Task<Dialect?> GetByLanguageIdAsync(string languageId)
    {
        return await GetByAsync(x => x.LanguageId == languageId);
    }

    public async Task<List<Dialect>> GetDialectsByLanguageAsync(string languageId)
    {
        return await GetAllAsync(x => x.LanguageId == languageId);
    }
}

public class AdvertisementRepository : BaseRepository<Advertisement>
{
    public AdvertisementRepository(DataContext db) : base(db) { }

    public async Task<List<Advertisement>> GetActiveAdvertisementsAsync()
    {
        return await GetAllAsync(x => x.Active);
    }
}

public class AdvertisementTabRepository : BaseRepository<AdvertisementTab>
{
    public AdvertisementTabRepository(DataContext db) : base(db) { }

    public async Task<AdvertisementTab?> GetByAdvertisementIdAsync(string advertisementId)
    {
        return await GetByAsync(x => x.AdvertisementId == advertisementId);
    }
}


public interface ISpaceRepository : IBaseRepository<Space>
{
    Task<Space?> GetByTokenAsync(string token);
    Task<List<Space>> GetBySubscriptionIdAsync(string subscriptionId);
    Task<List<Space>> GetSpacesByRamAsync(int ram);
    Task<Space> CreateSpaceAsync(CreateSpaceVM createSpaceVM);
    Task<Space> UpdateSpaceAsync(UpdateSpaceVM updateSpaceVM);
    Task<Space> GetSpaceByIdAsync(string id);
    Task<List<Space>> SearchSpacesAsync(SearchSpaceVM searchSpaceVM);

}

public class SpaceRepository : BaseRepository<Space>, ISpaceRepository
{
    private readonly IMapper _mapper;

    public SpaceRepository(DataContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }
    public async Task<Space> CreateSpaceAsync(CreateSpaceVM createSpaceVM)
    {
        var space = _mapper.Map<Space>(createSpaceVM);
        await _dbSet.AddAsync(space);
        await SaveAsync();
        return space;
    }
    public async Task<Space?> GetByTokenAsync(string token)
    {
        return await _dbSet.FirstOrDefaultAsync(space => space.Token == token);
    }

    public async Task<List<Space>> GetBySubscriptionIdAsync(string subscriptionId)
    {
        return await _dbSet.Where(space => space.SubscriptionId == subscriptionId).ToListAsync();
    }

    public async Task<List<Space>> GetSpacesByRamAsync(int ram)
    {
        return await _dbSet.Where(space => space.Ram == ram).ToListAsync();
    }



  

    public async Task<Space> UpdateSpaceAsync(UpdateSpaceVM updateSpaceVM)
    {
        var space = _mapper.Map<Space>(updateSpaceVM);
        _dbSet.Update(space);
        await SaveAsync();
        return space;
    }

    public async Task<Space> GetSpaceByIdAsync(string id)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Space>> SearchSpacesAsync(SearchSpaceVM searchSpaceVM)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrEmpty(searchSpaceVM.Name))
        {
            query = query.Where(s => s.Name.Contains(searchSpaceVM.Name));
        }

        if (searchSpaceVM.Ram.HasValue)
        {
            query = query.Where(s => s.Ram == searchSpaceVM.Ram.Value);
        }

        if (searchSpaceVM.Bandwidth.HasValue)
        {
            query = query.Where(s => s.Bandwidth == searchSpaceVM.Bandwidth.Value);
        }

        return await query.ToListAsync();
    }
}
