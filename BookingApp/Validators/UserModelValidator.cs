using BookingApp.Classes;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace BookingApp.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        private readonly BookingAppDbContext _context;

        public UserModelValidator(BookingAppDbContext context)
        {
            _context = context;

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress()
                .MustAsync(IsEmailUnique)
                .WithMessage("a");

            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(2);

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(2);

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .WithMessage("b");
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken token)
        {
            var result = await _context.Users.AnyAsync(i => i.Email == email);
            result = !result;
            return (result);
        }
    }
}
