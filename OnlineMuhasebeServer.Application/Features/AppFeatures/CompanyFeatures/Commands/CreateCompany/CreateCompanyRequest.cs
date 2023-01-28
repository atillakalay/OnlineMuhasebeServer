using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public class CreateCompanyRequest : IRequest<CreateCompanyResponse>
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
