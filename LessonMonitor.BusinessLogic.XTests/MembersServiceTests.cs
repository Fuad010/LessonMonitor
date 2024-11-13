using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class MembersServiceTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IMembersRepository> _membersRepositoryMock;
        private readonly MembersService _service;

        public MembersServiceTests()
        {
            _fixture = new Fixture();

            _membersRepositoryMock = new Mock<IMembersRepository>();
            _service = new MembersService(_membersRepositoryMock.Object);
        }

        ////
        //// Get Tests ////
        ////
        [Fact]
        public async Task Get_ShouldReturnMembers()
        {
            // arrange - подготавливаем данные
             
            var expectedMembers = _fixture
                .CreateMany<Member>(34)
                .ToArray();

            _membersRepositoryMock
                .Setup(x => x.Get())
                .ReturnsAsync(expectedMembers);

            // act - запускаем тестируемый метод
            var members = await _service.Get();

            // assert - проверяем/валидируем результаты теста
            members.Should().NotBeNullOrEmpty()
                .And.HaveCount(expectedMembers.Length);

            _membersRepositoryMock.Verify(x => x.Get(), Times.Once);
        }

        ////
        //// Create Tests ////
        ////

        [Fact]
        public async Task Create_ValidMember_ShouldReturnMemberId()
        {
            // arrange - подготавливаем данные

            var expectedMemberId = _fixture.Create<int>();

            var member = _fixture.Build<Member>()
                .Without(x => x.Id)
                .Create();


            _membersRepositoryMock
                .Setup(x=>x.Add(member))
                .ReturnsAsync(expectedMemberId);

            // act - запускаем тестируемый метод
            var memberId = await _service.Create(member);

            // assert - проверяем/валидируем результаты теста
            Assert.Equal(expectedMemberId, memberId);

            _membersRepositoryMock.Verify(x => x.Add(member), Times.Once);
        }

        [Fact]
        public async Task Create_MemberIsNull_ShouldThrowArgumentNullException()
        {
            // arrange

            // act
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(null));

            // assert 
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Theory]
        [InlineData(144, "test", "test")]
        [InlineData(-53, "test", "test")]
        [InlineData(1411, null, null)]
        [InlineData(0, " ", "test")]
        [InlineData(0, "", "test")]
        [InlineData(0, null, null)]
        public async Task Create_InvalidMember_ShouldThrowArgumentNullException(int id, string name, string youtubeUserId)
        {
            // arrange
            var member = new Member
            {
                Id = id,
                Name = name,
                YoutubeUserId = youtubeUserId
            };

            // act
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

       
    }
}
