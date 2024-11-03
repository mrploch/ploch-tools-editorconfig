using Ploch.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;
public class ProcessingContext(IUnitOfWork unitOfWork)
{
    private readonly IReadWriteRepositoryAsync<FileExtension, string> _fileExtensionRepository = unitOfWork.Repository<FileExtension, string>();
    private readonly IReadWriteRepositoryAsync<FilePattern, int> _filePatternRepository = unitOfWork.Repository<FilePattern, int>();
    private readonly Dictionary<string, FilePattern> _filePatterns = [];
    private readonly IReadWriteRepositoryAsync<FileType, int> _fileTypeRepository = unitOfWork.Repository<FileType, int>();
    private readonly Dictionary<string, FileType> _fileTypes = [];

    private readonly IReadWriteRepositoryAsync<SettingDefinition, Guid> _settingDefinitionRepository =
        unitOfWork.Repository<SettingDefinition, Guid>();

    private readonly Dictionary<string, SettingDefinition> _settingDefinitions = [];

    public async Task<SettingDefinition?> GetSettingDefinitionAsync(string sectionName, CancellationToken cancellationToken = default)
    {
        var section = _settingDefinitions.TryGetValue(sectionName, out var definition)
            ? definition
            : await _settingDefinitionRepository.FindFirstAsync(q => q.Name == sectionName, cancellationToken: cancellationToken);
        return section;
    }

    public Task AddSettingDefinitionAsync(SettingDefinition settingDefinition, CancellationToken cancellationToken = default)
    {
        _settingDefinitions.Add(settingDefinition.Name, settingDefinition);

        return _settingDefinitionRepository.AddAsync(settingDefinition, cancellationToken);
    }

    public async Task<FilePattern?> GetFilePatternAsync(string globPattern, CancellationToken cancellationToken = default)
    {
        return _filePatterns.TryGetValue(globPattern, out var extension)
            ? extension
            : await _filePatternRepository.FindFirstAsync(q => q.GlobPattern == globPattern, cancellationToken: cancellationToken);
    }

    public Task AddFilePatternAsync(FilePattern filePattern, CancellationToken cancellationToken = default)
    {
        _filePatterns.TryAdd(filePattern.GlobPattern, filePattern);

        return _filePatternRepository.AddAsync(filePattern, cancellationToken);
    }

    public async Task<FileType?> GetFileTypeAsync(string fileExtension, CancellationToken cancellationToken = default)
    {
        return _fileTypes.TryGetValue(fileExtension, out var fileType)
            ? fileType
            : (await _fileExtensionRepository.GetByIdAsync(fileExtension, dbSet => dbSet.Include(q => q.FileType), cancellationToken))?.FileType;
    }

    public void AddFileType(string fileExtension, FileType fileType)
    {
        _fileTypes.TryAdd(fileExtension, fileType);

        if (fileType.Id == default)
        {
            _fileTypeRepository.AddAsync(fileType);
        }
    }
}
