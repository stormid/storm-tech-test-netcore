using System;
using Bogus;
using Bogus.Extensions;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoLists;
using Xunit;

namespace Todo.Tests.Views.TodoList
{
    public sealed class TodoListDetailViewmodelTests
    {
        [Fact]
        public void TodoListDetailViewmodel_ItemsAreNull_ViewModelCreatedWithEmptyList()
        {
            // Arrange
            var faker = new Faker();

            // Act
            Action act = () =>
            {
                var _ = new TodoListDetailViewmodel(faker.Random.Int(), faker.Lorem.Sentence(), null);
            };

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        public void TodoListDetailViewmodel_ItemsNotNull_ViewModelCreatedWithSortedList(int todoItemCount)
        {
            // Arrange
            var faker               = new Faker();
            var userIdentity        = new IdentityUser(faker.Person.Email);
            var testTodoListBuilder = new TestTodoListBuilder(userIdentity, faker.Company.Bs());

            for (var i = 0; i < todoItemCount; i++)
                testTodoListBuilder = testTodoListBuilder.WithItem(faker.Lorem.Sentence(), faker.PickRandom<Importance>());

            var todoList = testTodoListBuilder.Build();
            
            // Act
            var todoListDetailViewModel = TodoListDetailViewmodelFactory.Create(todoList);

            // Assert
            todoListDetailViewModel.Items.Should().BeInAscendingOrder(todoItem => todoItem.Importance);
        }
    }
}