using Entities;
using Moq;
using Ports;
using usecase;
using Dtos;

public class UnitTestCategoryUseCase
{
    [Fact]
    public async Task TestSaveCategory()
    {
        var RepoMock = new Mock<IPortsGenericRepo<Category>>();
        var useCase = new CategoryUseCase(RepoMock.Object);

        var input = new CategoryDto { Title = "Coisar", Description = "Truta" };
        await useCase.SaveCategory(input);
    }

    [Fact]
    public async Task TestGetCategory()
    {
        var RepoMock = new Mock<IPortsGenericRepo<Category>>();
        
        var model = new Category ("123","Thing","Thing");
        RepoMock.Setup(i => i.GetById("123"))
        .ReturnsAsync(
            model
        );

        var useCase = new CategoryUseCase(RepoMock.Object);

        var input = "123";
        var output = await useCase.GetCategory(input);

        Assert.Equal(model, output);
    }
}
