using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Configuration
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Verifica se existe uma Session chamada "UsuarioLogado"
            var usuarioLogado = context.HttpContext.Session.GetString("nome_usuario");

            if (string.IsNullOrEmpty(usuarioLogado))
            {
                context.Result = new RedirectToActionResult("Login", "Funcionario", null);
            }

            base.OnActionExecuting(context);
        }
    }

}
