using Nhom10_HoDuongTien.Models.TokenAuth;
using Nhom10_HoDuongTien.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Nhom10_HoDuongTien.Web.Tests.Controllers;

public class HomeController_Tests : Nhom10_HoDuongTienWebTestBase
{
    [Fact]
    public async Task Index_Test()
    {
        await AuthenticateAsync(null, new AuthenticateModel
        {
            UserNameOrEmailAddress = "admin",
            Password = "123qwe"
        });

        //Act
        var response = await GetResponseAsStringAsync(
            GetUrl<HomeController>(nameof(HomeController.Index))
        );

        //Assert
        response.ShouldNotBeNullOrEmpty();
    }
}