using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using Jobs.Infrastructure.Auth;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Jobs.Application.Commands.User.Password.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel>
{
    private readonly IUserRepository _repository;
    private readonly IMemoryCache _memoryCache;
    private readonly IAuthService _authService;

    public ChangePasswordCommandHandler(IUserRepository repository, IMemoryCache memoryCache, IAuthService authService)
    {
        _repository = repository;
        _memoryCache = memoryCache;
        _authService = authService;
    }

    public async Task<ResultViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"RecoveryCode:{request.Email}";

        if (!_memoryCache.TryGetValue(cacheKey, out string? code) || code != request.Code)
            return ResultViewModel.Error("Oops...erro ao realizar troca de senha.");

        _memoryCache.Remove(cacheKey);

        var user = await _repository.GetUserByEmailAsync(request.Email);

        if (user is null)
            return ResultViewModel.Error("Oops...erro ao realizar troca de senha.");

        var hash = _authService.ComputeHash(request.NewPassword);

        user.UpdatePassword(hash);
        await _repository.UpdateUserAsync(user);

        return ResultViewModel.Success();
    }
}
