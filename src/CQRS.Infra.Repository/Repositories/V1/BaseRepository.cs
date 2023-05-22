using System.Linq.Expressions;
using CQRS.Domain.Contracts.V1;
using CQRS.Domain.Entites.V1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CQRS.Infra.Repository.Repositories.V1;

public abstract class BaseRepository<T> where T: IEntity
{
    protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
    {
        var database = client.GetDatabase(settings.Value.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }
    public readonly IMongoCollection<T> Collection;
    public async Task AddAsync(T entity, CancellationToken cancellation)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellation);
    }
    public async Task UpdateAsync(T entity, CancellationToken cancellation)
    {
        await Collection.ReplaceOneAsync(
            entity => entity.Id!.Equals(entity.Id), entity,
            new ReplaceOptions { IsUpsert = true },
            cancellation);
    }
    public async Task RemoveAsync(Guid personId, CancellationToken cancellation)
    {
        var filter = Builders<T>.Filter
            .Eq(restaurant => restaurant.Id, personId);
        await Collection.DeleteOneAsync(filter, cancellationToken: cancellation);
    }
    public async Task<T> FindByIdAsync(Guid personId, CancellationToken cancellation)
    {
        var filter = Builders<T>.Filter
            .Eq(restaurant => restaurant.Id, personId);
        return await Collection.Find(filter).FirstOrDefaultAsync(cancellation);
    }
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellation)
    {
        var filter = Builders<T>.Filter.Where(expression);
        return await Collection.Find(filter).ToListAsync(cancellation);
    }
    protected FilterDefinition<T> GetFilterById(Guid id)
    {
        return Builders<T>.Filter.Eq(entity => entity.Id, id);
    }
}
