using AutoFixture.Xunit2;
using Ploch.Common.Collections;
using Ploch.EditorConfigTools.Models;
using Ploch.EditorConfigTools.DataAccess;
using System.IO.Abstractions.TestingHelpers;
using Objectivity.AutoFixture.XUnit2.AutoMoq.Attributes;
using Ploch.Data.GenericRepository.EFCore.IntegrationTesting;

namespace Ploch.EditorConfigTools.Processing.IntegrationTests;
public class EditorConfigFileProcessorTests : GenericRepositoryDataIntegrationTest<EditorConfigDbContext>
{
    private const string TestFileContent = @"
root = true
# C# code style
[*.cs]
indent_style = space
indent_size = 4
guidelines = 160

# RCS1169: Make field read-only.
dotnet_diagnostic.rcs1169.severity = warning

# Standard properties
sa1200.severity = none
customkey_with_comment = true # Comment here

[*.{ appxmanifest,asax}]
indent_style = space
indent_size = 4
tab_width = 4
[*.cs]

# RCS1169: Make field read-only.
dotnet_diagnostic.rcs1169.severity = warning

# Standard properties
dotnet_diagnostic.sa1200.severity = none
customkey_with_comment = true # Comment here

[*Tests.cs]
indent_style = space
indent_size = 4
tab_width = 4";

    [Theory]
    [AutoMockData]
    public async Task ProcessTest([Frozen(Matching.ImplementedInterfaces)] MockFileSystem mockFileSystem, EditorConfigFileProcessor sut)
    {
        mockFileSystem.AddFile("c:/.editorconfig", new MockFileData(TestFileContent));
        var editorConfigFile = new EditorConfigFile
        {
            Name = ".editorconfig", FilePath = "c:/.editorconfig", ConfigSections = [], Project = new Project { Name = "test", Path = "." }
        };

        await sut.ExecuteAsync(editorConfigFile);

        editorConfigFile.ConfigSections.Should().HaveCount(2);
        var firstSection = editorConfigFile.ConfigSections.First();
        firstSection.GlobPattern.Should().Be("*.cs");

        firstSection.ConfigEntries.Should().HaveCount(4);

        var secondSection = editorConfigFile.ConfigSections.Second();
        secondSection.ConfigEntries.Should().HaveCount(3);
    }

    private static byte[] GetFileContent(string filePath)
    {
        return File.ReadAllBytes(filePath);
    }
}