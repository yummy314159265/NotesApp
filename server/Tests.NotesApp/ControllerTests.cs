using System.Security.Claims;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Controllers;

namespace Tests.NotesApp;

public class ControllerTests
{

    private readonly Helpers _help = new Helpers();
    
    private readonly Mock<INotesAppBusinessLayer> _mockBus = new();

    private readonly ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                                                {
                                                    new Claim(ClaimTypes.Name, "auth0id"),
                                                }, "mock"));

    [Fact]
    public async Task CreateProfileAsync_InputCreateProfileDto_ReturnsCreatedActionResultWithProfile()
    {
        // Arrange
        Profile p = _help.fakeProfile();

        _mockBus.Setup(bus => bus.CreateProfileAsync(It.IsAny<CreateProfileDto>(), It.IsAny<string>()))
            .ReturnsAsync(p);

        NotesAppController TheClassBeingTested = new NotesAppController(_mockBus.Object);

        TheClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = _user };

        // Act
        var result = await TheClassBeingTested.CreateProfileAsync(It.IsAny<CreateProfileDto>());
        var createdResult = result.Result as CreatedResult;
        var resultObject = createdResult?.Value as Profile;

        // Assert
        Assert.NotNull(resultObject);
        Assert.IsType<Profile>(resultObject);
        Assert.Equal(createdResult?.StatusCode, 201);
        Assert.Equal(p.ProfileId, resultObject.ProfileId);
    }
}