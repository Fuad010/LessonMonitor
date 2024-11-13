using FluentValidation;
using LessonMonitor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.BusinessLogic.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Id).Equal(default(int));
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.YoutubeUserId).NotEmpty();
        }
    }
}
