namespace Ploch.EditorConfigTools.UseCases;

public interface IUseCase
{ }

public interface IUseCase<in TSettings> : IUseCase
{
    Task ExecuteAsync(TSettings settings);
}

public interface IUseCase<in TSettings, TResult> : IUseCase
{
    Task<TResult> ExecuteAsync(TSettings settings);
}