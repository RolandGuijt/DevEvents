using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net;
using Microsoft.Azure.Documents;

namespace DevEvents.Api.Repositories
{
    public class Repository<T>
    where T: class
    {
        private readonly DocumentClient _client;
        private readonly Uri _collectionUri;
        private readonly string _databaseName;
        private readonly string _collectionName;

        public Repository(DocumentClient client, IConfiguration config)
        {
            _client = client;
            _databaseName = config["Cosmos:Database"];
            _collectionName = config["Cosmos:Collection"];
            _collectionUri = UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName);
        }
        
        public async Task<List<T>> GetList(Expression<Func<T, bool>> predicate)
        {
            var query = _client.CreateDocumentQuery<T>(_collectionUri)
                .Where(predicate)
                .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }
        
        public async Task<T> GetById(string id)
        {
            try
            {
                Document document = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_databaseName, _collectionName, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        
        public async Task<Document> Create(T item)
        {
            return await _client.CreateDocumentAsync(_collectionUri, item);
        }
        
        public async Task<Document> Update(string id, T item)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_databaseName, _collectionName, id), item);
        }
    }
}