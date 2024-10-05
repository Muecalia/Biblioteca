using Biblioteca.Application.Queries.Request.Users;
using Biblioteca.Application.Queries.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class FindAllUsersHandler : IRequestHandler<FindAllUsersRequest, PagedResponse<FindAllUsersResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public FindAllUsersHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<PagedResponse<FindAllUsersResponse>> Handle(FindAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var listUsers = await _iUserRepository.FindAll(cancellationToken);
                var result = new List<FindAllUsersResponse>();

                System.Diagnostics.Debug.WriteLine($"Count (Handler): {listUsers.Count}");

                listUsers.ForEach(user => result.Add(new FindAllUsersResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    CreatedAt = user.CreatedAt.ToShortDateString(),
                    UpdatedAt = user.UpdatedAt != null ? user.UpdatedAt.Value.ToShortDateString() : string.Empty
                }));

                return new PagedResponse<FindAllUsersResponse>(result, "Sucesso ao carrgar os utilizador");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar os utilizador. Mensagem: {ex}");
                throw;
            }
        }

    }
}
