﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Complaint : BaseDTO
    {
        public string Description {  get; set; }
        public bool Approved { get; set; } = false;
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public List<DTO.FileInfo>? AttachmentInfo { get; set; }
        public string? Attachment { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public ICollection<Demand>? Demands { get; set; }
    }

    public class ComplaintValidation : AbstractValidator<Complaint>
    {
        public ComplaintValidation() 
        {
            When(e => e.ID == 0 && e != null && e.IsDeleted == false, () =>
            {
                RuleFor(e => e.Description).NotNull().WithMessage("Name Is Required");
                RuleFor(e => e.Description).NotEmpty().WithMessage("Name Is Required");

                RuleFor(e => e.UserName).NotNull().WithMessage("User Name Is Required");
                RuleFor(e => e.UserName).NotEmpty().WithMessage("User Name Is Required");

                RuleFor(e => e.UserNumber).NotNull().WithMessage("User Number Is Required");
                RuleFor(e => e.UserNumber).NotEmpty().WithMessage("User Number Is Required");

                RuleFor(e => e.Attachment).NotNull().WithMessage("User Attachment Is Required");
                RuleFor(e => e.Attachment).NotEmpty().WithMessage("User Attachment Is Required");

            });
            When(e => e.ID > 0 && e != null && e.IsDeleted == false, () =>
            {
                RuleFor(e => e.Description).NotNull().WithMessage("Name Is Required");
                RuleFor(e => e.Description).NotEmpty().WithMessage("Name Is Required");

                RuleFor(e => e.UserName).NotNull().WithMessage("User Name Is Required");
                RuleFor(e => e.UserName).NotEmpty().WithMessage("User Name Is Required");

                RuleFor(e => e.UserNumber).NotNull().WithMessage("User Number Is Required");
                RuleFor(e => e.UserNumber).NotEmpty().WithMessage("User Number Is Required");

            });
            When(e => e.ID > 0 && e != null && e.IsDeleted == true, () =>
            {
                RuleFor(e => e.Description).Null();
                RuleFor(e => e.Description).Empty();

                RuleFor(e => e.UserName).Null();
                RuleFor(e => e.UserName).Empty();

                RuleFor(e => e.UserNumber).Null();
                RuleFor(e => e.UserNumber).Empty();
            });
        }
    }

}
