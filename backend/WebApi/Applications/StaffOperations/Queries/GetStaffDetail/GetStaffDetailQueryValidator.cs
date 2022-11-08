using FluentValidation;

namespace WebApi.Applications.StaffOperations.Queries.GetStaffDetail
{
    public class GetStaffDetailQueryValidator : AbstractValidator<GetStaffDetailQuery>
    {
        public GetStaffDetailQueryValidator()
        {
            RuleFor(query => query.StaffId).GreaterThan(0);
        }
        
    }

}