using MediatR;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public class CreateUCAFRequest : IRequest<CreateUCAFResponse>
    {
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }
    }
}
