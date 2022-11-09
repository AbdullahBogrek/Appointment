using FluentValidation;

namespace WebApi.Applications.ServiceOperations.Queries.GetServiceDetail
{
    public class GetServiceDetailQueryValidator : AbstractValidator<GetServiceDetailQuery>
    {
        public GetServiceDetailQueryValidator()
        {
            RuleFor(query => query.ServiceId).GreaterThan(0);
        }
        
    }

}