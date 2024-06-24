using HospitalManagementSystemBackend.BLL.Interfaces;
using HospitalManagementSystemBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.BLL.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> Add(T item)
        {
            return await _repository.Add(item);
        }

        public async Task<List<T>> Add(List<T> items)
        {
            return await _repository.Add(items);
        }

        public async Task<T> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<T>> Delete(List<T> items)
        {
            return await _repository.Delete(items);
        }

        public async Task<List<T>> Get()
        {
            return await _repository.Get();
        }

        public async Task<List<T>> Get(Func<T, bool> func)
        {
            return await _repository.Get(func);
        }

        public async Task<T> GetSingle(Guid id)
        {
            return await _repository.GetSingle(id);
        }

        public async Task<T> GetSingle(Func<T, bool> func)
        {
            return await _repository.GetSingle(func);
        }

        public async Task<T> Update(T item)
        {
            return await _repository.Update(item);
        }

        public async Task<List<T>> Update(List<T> items)
        {
            return await _repository.Update(items);
        }
    }
}
