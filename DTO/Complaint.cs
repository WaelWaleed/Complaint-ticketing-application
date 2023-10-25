using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Complaint : BaseDTO
    {
        public string Name {  get; set; }
        public bool Approved { get; set; } = false;
        public int UserID { get; set; }
        public User? User { get; set; }
        public ICollection<Demand>? Demands { get; set; }
    }

    public class ComplaintValidation : AbstractValidator<Complaint>
    {
        public ComplaintValidation() 
        {
            When(e => e.ID > 0 && e != null && e.IsDeleted == false, () =>
            {
                RuleFor(e => e.Name).NotNull().WithMessage("Name Is Required");
                RuleFor(e => e.Name).NotEmpty().WithMessage("Name Is Required");

                RuleFor(e => e.User).NotNull().WithMessage("User Is Required");
                RuleFor(e => e.User).NotEmpty().WithMessage("User Is Required");

            });
        }
    }

}
