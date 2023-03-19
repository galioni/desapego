using Desapego.API.Models;
using Desapego.API.Models.Configuration;
using Desapego.API.Models.Models;
using Desapego.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Desapego.API.Services.Implementations;

public class ProductServiceRepository : IServiceRepository<Product>
{
    private readonly MongoClient _client;

    private readonly IMongoDatabase _database;

    private readonly IMongoCollection<Product> _products;

    public ProductServiceRepository(IOptions<DesapegoStoreSettings> bookStoreDatabaseSettings)
    {
        _client = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);

        _database = _client.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);

        _products = _database.GetCollection<Product>(DesapegoCollections.Product);
    }

    public async Task<IEnumerable<Product>> GetAll() =>
        await _products.Find(_ => _.RecordStatus).ToListAsync();

    public async Task<Product> GetById(string Id) =>
        await _products.Find(x => x.Id == Id).FirstOrDefaultAsync();

    public async Task Create(Product entity) =>
        await _products.InsertOneAsync(entity);

    public async Task Update(string Id, Product updatedEntity) =>
        await _products.ReplaceOneAsync(x => x.Id == Id, updatedEntity);

    public async Task Delete(string Id) =>
        await _products.DeleteOneAsync(x => x.Id == Id);
}