using FluentValidation;
using FluentValidation.Results;
using RasDoc.Domain.Interfaces;
using RasDoc.Domain.Notifications;
using RasDoc.Entities.Models;

namespace RasDoc.Domain.Repository
{
    public abstract class BaseNotification
    {
        private readonly INotifier _notifier;

        public BaseNotification(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : EntityBase
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
            {
                return true;
            }

            Notify(validator);

            return false;
        }
    }
}
