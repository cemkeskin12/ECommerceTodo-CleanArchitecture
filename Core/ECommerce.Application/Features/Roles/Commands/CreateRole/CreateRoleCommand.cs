using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public class CreateAndGetAllAssignableRolesHandler : IRequestHandler<CreateRoleCommand>
        {
            private readonly IRoleService roleService;
            private readonly IMenuService menuService;

            public CreateAndGetAllAssignableRolesHandler(IRoleService roleService, IMenuService menuService)
            {
                this.roleService = roleService;
                this.menuService = menuService;
            }
            public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var data = menuService.GetMenuDefinitionEndPoints("ECommerce.WebApi");

                foreach (var item in data)
                    await roleService.CreateRolesAsync(item.Actions.Select(x => x.Code));

                return await Task.FromResult(Unit.Value);
            }
        }

    }
}
