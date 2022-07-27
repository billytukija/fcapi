using found_church_api.DataObjectTransfert;
using found_church_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace found_church_api.Services
{
    public class ChurchesService
    {
        private readonly IMongoCollection<Church> _churchesCollection;

        public ChurchesService(
            IOptions<FoundChurchDatabaseSettings> FoundChurchDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                FoundChurchDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                FoundChurchDatabaseSettings.Value.DatabaseName);

            _churchesCollection = mongoDatabase.GetCollection<Church>(
                FoundChurchDatabaseSettings.Value.ChurchesCollectionName);
        }

        public async Task<List<ChurchDto>> GetBySearch(String search)
        {
            var foundChurches = await _churchesCollection.Find(church
                 => church.Enabled && (church.ChurchName.ToUpper().Contains(search.ToUpper()) || church.PastorName.ToUpper().Contains(search.ToUpper())
                 || church.Country.ToUpper().Contains(search.ToUpper()) || church.State.ToUpper().Contains(search.ToUpper())
                 || church.State.ToUpper().Contains(search.ToUpper()))).ToListAsync();

            var churches = new List<ChurchDto>();

            foundChurches.ForEach(church =>
            {
                var churchDto = new ChurchDto()
                {
                    ChurchName = church.ChurchName,
                    PastorName = church.PastorName,
                    Country = church.Country,
                    State = church.State,
                    City = church.City,
                    Neighborhood = church.Neighborhood,
                    Street = church.Street,
                    Number = church.Number,
                    AdditionalInformations = church.AdditionalInformations
                };
                churches.Add(churchDto);
            });

            return churches;
        }

        public async Task<List<ChurchDto>> GetAsync()
        {
            var enabledChurches = await _churchesCollection.Find(x => x.Enabled).ToListAsync();
            var churches = new List<ChurchDto>();

            enabledChurches.ForEach(church =>
            {
                var churchDto = new ChurchDto()
                {
                    ChurchName = church.ChurchName,
                    PastorName = church.PastorName,
                    Country = church.Country,
                    State = church.State,
                    City = church.City,
                    Neighborhood = church.Neighborhood,
                    Street = church.Street,
                    Number = church.Number,
                    AdditionalInformations = church.AdditionalInformations
                };
                churches.Add(churchDto);
            });

            return churches;
        }

        public async Task<Church?> GetAsync(string id) =>
            await _churchesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AddChurchDto newChurch)
        {

            var church = new Church()
            {
                Id = GenerateId(),
                ChurchName = newChurch.ChurchName,
                PastorName = newChurch.PastorName,
                Country = newChurch.Country,
                State = newChurch.State,
                City = newChurch.City,
                Neighborhood = newChurch.Neighborhood,
                Street = newChurch.Street,
                Number = newChurch.Number,
                AdditionalInformations = newChurch.AdditionalInformations,
                NameProvider = newChurch.NameProvider,
                EmailProvider = newChurch.EmailProvider,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.MinValue,
                EnabledAt = DateTime.MinValue,
                Enabled = false
            };

            await _churchesCollection.InsertOneAsync(church);
        }

        public async Task UpdateAsync(string id, Church updatedChurch) =>
            await _churchesCollection.ReplaceOneAsync(x => x.Id == id, updatedChurch);

        public async Task RemoveAsync(string id) =>
            await _churchesCollection.DeleteOneAsync(x => x.Id == id);



        private static String GenerateId()
        {
            return string.Join(Environment.NewLine, RandomUniqueHexDirect());
        }
        private static String RandomUniqueHexDirect()
        {
            Random s_Generator = new Random();
            string value = string.Concat(Enumerable
                      .Range(0, 24)
                      .Select(j => s_Generator.Next(0, 16).ToString("x")));

            return value;
        }
    }
}
