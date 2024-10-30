using System.IO.Abstractions.TestingHelpers;
using AutoFixture.Xunit2;
using Objectivity.AutoFixture.XUnit2.AutoMoq.Attributes;
using Ploch.Data.GenericRepository.EFCore.IntegrationTesting;
using Ploch.EditorConfigTools.DataAccess;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing.IntegrationTests;

public class EditorConfigFileProcessorTests : GenericRepositoryDataIntegrationTest<EditorConfigDbContext>
{
    private const string TestFileContent = @"
# global_option_1_above_comment
global_option_1 = value1 # global_option_1_side_comment
global_option_2 = value2

# global_comment_above_section
[*.ext1]
group1.option1 = value1
group1.option2= value2
group1.option3 = value3

# group2.option1_comment
group2.option1 = value2.1

group3.option1.severity = warning

customkey_with_comment = true # Comment here

[*.{ ext2,ext3,ext4}]
section2_value1 = value1
section2_value2 = value2
section2_value3 = value3

group1.option3 = should_not_override_section1
group1.option2= value2

customkey_with_comment = true # Comment here

[*Tests.ext1]
custom_test_setting1 = value1
custom_test_setting2 = value2
custom_test_setting3 = value3

group1.option1 = should_override_section1_value1
group1.option2 = should_override_section1_value2
global_option_1 = should_override_global_value1
";

    [Theory]
    [AutoMockData]
    public async Task ProcessTest([Frozen(Matching.ImplementedInterfaces)] MockFileSystem mockFileSystem, EditorConfigFileProcessor sut)
    {
        mockFileSystem.AddFile("c:/.editorconfig", new MockFileData(TestFileContent));
        var editorConfigFile = new EditorConfigFile
                               {
                                   Name = ".editorconfig",
                                   FilePath = "c:/.editorconfig",
                                   ConfigSections = [],
                                   Project = new Project { Name = "test", Path = "." }
                               };

        await sut.ExecuteAsync(editorConfigFile);

        editorConfigFile.ConfigSections.Should().HaveCount(2);
        var firstSection = editorConfigFile.ConfigSections.First();
        firstSection.GlobPattern.Should().Be("*.cs");

        firstSection.ConfigEntries.Should().HaveCount(4);

        var secondSection = editorConfigFile.ConfigSections.Skip(1).First();
        secondSection.ConfigEntries.Should().HaveCount(3);
    }

    [Theory]
    [AutoMockData]
    public async Task ProcessFileTest([Frozen(Matching.ImplementedInterfaces)] MockFileSystem mockFileSystem, EditorConfigFileProcessor sut)
    {
        mockFileSystem.AddFile("c:/.editorconfig", new MockFileData(await File.ReadAllTextAsync("test-files/simple-single-file/.editorconfig")));

        var editorConfigFile = new EditorConfigFile
                               {
                                   Name = ".editorconfig",
                                   FilePath = "c:/.editorconfig",
                                   ConfigSections = [],
                                   Project = new Project { Name = "test", Path = "." }
                               };

        await sut.ExecuteAsync(editorConfigFile);

        editorConfigFile.ConfigSections.Should().HaveCount(2);
        var firstSection = editorConfigFile.ConfigSections.First();
        firstSection.GlobPattern.Should().Be("*.cs");

        firstSection.ConfigEntries.Should().HaveCount(4);

        var secondSection = editorConfigFile.ConfigSections.Skip(1).First();
        secondSection.ConfigEntries.Should().HaveCount(3);
    }
}