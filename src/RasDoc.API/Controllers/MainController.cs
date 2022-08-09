using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RasDoc.Domain.Interfaces;
using RasDoc.Domain.Notifications;

namespace RasDoc.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotifications();
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifations().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotifyInvalidModelError(modelState);
            }

            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var erroMgs = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(erroMgs);
            }
        }

        protected void NotifyError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
