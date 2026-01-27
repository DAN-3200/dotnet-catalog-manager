using Moq;
using ProductCatalog.Application.Dtos;
using ProductCatalog.Application.Ports;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Application.UseCases;

namespace ProductCatalog.Tests.Unit;

// cli: dotnet test --filter <function_name>
public class UnitTestCategoryUseCase
{
    [Fact]
    public async Task TestSaveCategory()
    {
        var repoMock = new Mock<IPortsGenericRepo<Category>>();
        var useCase = new CategoryUseCase(repoMock.Object);

        var input = new CategoryDto { Title = "", Description = "" };
        await useCase.SaveCategory(input);
    }

    [Fact]
    public async Task TestGetCategory()
    {
        var repoMock = new Mock<IPortsGenericRepo<Category>>();

        var model = new Category("123", "Thing", "Thing");
        repoMock.Setup(i => i.GetById("123")).ReturnsAsync(model);


        var useCase = new CategoryUseCase(repoMock.Object);

        var input = "123";
        var output = await useCase.GetCategory(input);

        Assert.Equal(model, output);
    }

    [Fact]
    public async Task TestEditCategory()
    {
        var repoMock = new Mock<IPortsGenericRepo<Category>>();
        var model = new Category("123", "Thing", "Thing");
        repoMock.Setup(i => i.GetById("123")).ReturnsAsync(model);

        var useCase = new CategoryUseCase(repoMock.Object);
        var input = new CategoryDto { Title = "Pokamon", Description = "PiPokOmon" };

        await useCase.EditCategory("123", input);
    }
}
