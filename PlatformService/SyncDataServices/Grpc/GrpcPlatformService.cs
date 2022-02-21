using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using PlatformService.Data;

namespace PlatformService.SyncDataServices.Grpc
{
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly PlatformRepo _repository;
        private readonly IMapper _mapper;

        public GrpcPlatformService(PlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Task<PlatformResponse> GetAllPlatforms(GetAllRequests request, ServerCallContext context)
        {
            var response = new PlatformResponse();
            var _platforms = _repository.GetAllPlatforms();

            foreach (var platform in _platforms)
            {
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(platform));
            }

            return Task.FromResult(response);
        }
    }
}
