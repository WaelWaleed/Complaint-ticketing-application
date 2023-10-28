using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Demand : BaseDTO
    {
        public string Description { get; set; }
        public int ComplaintID { get; set; }
        //public Complaint? Complaint { get; set; }
    }

    public class DemandValidation : AbstractValidator<Demand>
    {
        public DemandValidation()
        {
            When(e => e.ID > 0 && e != null && e.IsDeleted == false, () =>
            {
                RuleFor(e => e.Description).NotNull().WithMessage(" Description Is Required");
                RuleFor(e => e.Description).NotEmpty().WithMessage("Description Is Required");

            });
        }
    }

}
