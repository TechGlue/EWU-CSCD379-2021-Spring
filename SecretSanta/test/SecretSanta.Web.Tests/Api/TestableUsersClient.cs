using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SecretSanta.Web.Api;

namespace SecretSanta.Web.Tests.Api{
    public class TestableUsersClient : IUsersClient
    {
        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<UserDto> GetAllUsersReturnValue{get; set;} = new();
        public int GetAllAsyncInvocationCount{get; set;}
        public Task<ICollection<UserDto>?> GetAllAsync()
        {
            GetAllAsyncInvocationCount++;
            return Task.FromResult<ICollection<UserDto>?>(GetAllUsersReturnValue);
        }
        public Task<ICollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<UserDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        
        public int PostAsyncInvocationCount {get; set;}
        public List<UserDto> PostAsyncInvokedParameters{get;} = new();
        public Task<UserDto> PostAsync(UserDto myUser)
        {
            PostAsyncInvocationCount++;
            PostAsyncInvokedParameters.Add(myUser);
            return Task.FromResult(myUser);
        }

        public Task<UserDto> PostAsync(UserDto user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> PutAsync(int id, UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> PutAsync(int id, UserDto user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
