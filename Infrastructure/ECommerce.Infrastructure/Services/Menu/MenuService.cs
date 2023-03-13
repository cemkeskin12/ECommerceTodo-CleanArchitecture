using ECommerce.Application.Attributes;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Config;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ECommerce.Infrastructure.Services
{
    public class MenuService : IMenuService
    {

        public List<Menu> GetMenuDefinitionEndPoints(string assemblyName)
        {
            var assembly = Assembly.Load(assemblyName);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
            List<Menu> menus = new();

            if (controllers is not null)
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(x => x.IsDefined(typeof(MenuDefinitionAttribute)));
                    if (actions.Any(x => x.ReturnParameter != null))
                        foreach (var action in actions)
                        {
                            var attributes = action.GetCustomAttributes(true);
                            if (attributes is not null)
                            {
                                Menu menu = null;
                                string replacedMenuName = controller.Name.Remove(controller.Name.Length - 10); //for remove controller part of text --controller is 10 char
                                

                                if (!menus.Any(x => x.Name == replacedMenuName))
                                {
                                    menu = new() { Name = replacedMenuName };
                                    menus.Add(menu);
                                }
                                else
                                    menu = menus.FirstOrDefault(x => x.Name == replacedMenuName);


                                var menuDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(MenuDefinitionAttribute)) as MenuDefinitionAttribute;
                                Domain.Config.Action customAction = new()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), menuDefinitionAttribute.ActionType),
                                    Definition = action.Name
                                };

                                var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttribute is not null)
                                    customAction.HttpType = httpAttribute.HttpMethods.First();
                                else
                                    customAction.HttpType = HttpMethods.Get;

                                customAction.Code = $"{menu.Name}.{customAction.HttpType}.{customAction.ActionType}.{action.Name}";

                                menu.Actions.Add(customAction);


                            }
                        }
                }
            return menus;
        }
    }
}
