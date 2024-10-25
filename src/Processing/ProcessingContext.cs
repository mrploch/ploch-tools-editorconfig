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

    public async Task<SettingDefinition?> GetSettingDefinitionAsync(string sectionName)
    {
        var section = _settingDefinitions.TryGetValue(sectionName, out var definition)
            ? definition
            : await _settingDefinitionRepository.FindFirstAsync(q => q.Name == sectionName);
        return section;
    }

    public Task AddSettingDefinitionAsync(SettingDefinition settingDefinition)
    {
        _settingDefinitions.Add(settingDefinition.Name, settingDefinition);

        return _settingDefinitionRepository.AddAsync(settingDefinition);
    }

    public async Task<FilePattern?> GetFilePatternAsync(string globPattern)
    {
        return _filePatterns.TryGetValue(globPattern, out var extension)
            ? extension
            : await _filePatternRepository.FindFirstAsync(q => q.GlobPattern == globPattern);
    }

    public Task AddFilePatternAsync(FilePattern filePattern)
    {
        _filePatterns.TryAdd(filePattern.GlobPattern, filePattern);

        return _filePatternRepository.AddAsync(filePattern);
    }

    public async Task<FileType?> GetFileTypeAsync(string fileExtension, CancellationToken cancellationToken = default)
    {
        return _fileTypes.TryGetValue(fileExtension, out var fileType)
            ? fileType
            : (await _fileExtensionRepository.GetByIdAsync(fileExtension, dbSet => dbSet.Include(q => q.FileType),
                cancellationToken))?.FileType;
    }

    public void AddFileType(string fileExtension, FileType fileType)
    {
        _fileTypes.TryAdd(fileExtension, fileType);
        _fileTypeRepository.AddAsync(fileType);
    }
}