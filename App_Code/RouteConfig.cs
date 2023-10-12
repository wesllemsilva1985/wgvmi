/* Alteração não mesclada do projeto '4_App_Code'
Antes:
using System;
Após:
using Microsoft.AspNet.FriendlyUrls;

using System;
*/

using Microsoft.AspNet.FriendlyUrls;

using System.Web.Routing;

namespace wgvmi
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            // Outras rotas podem ser definidas aqui, se necessário.
        }
    }
}