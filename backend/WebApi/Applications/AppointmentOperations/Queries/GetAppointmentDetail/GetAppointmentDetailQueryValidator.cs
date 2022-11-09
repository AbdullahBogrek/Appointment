using FluentValidation;

namespace WebApi.Applications.AppointmentOperations.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQueryValidator : AbstractValidator<GetAppointmentDetailQuery>
    {
        public GetAppointmentDetailQueryValidator()
        {
            RuleFor(query => query.AppointmentId).GreaterThan(0);
        }
        
    }

}