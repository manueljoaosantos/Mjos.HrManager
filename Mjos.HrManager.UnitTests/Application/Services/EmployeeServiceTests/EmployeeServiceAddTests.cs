﻿using AutoFixture;
using Mjos.HrManager.Application.Models.InputModels;
using Mjos.HrManager.Application.Services;
using Mjos.HrManager.Core.Entities;
using Mjos.HrManager.Core.Exceptions;
using Mjos.HrManager.Core.Repositories;
using Moq;
using Shouldly;

namespace Mjos.HrManager.UnitTests.Application.Services.EmployeeServiceTests
{
    public class EmployeeServiceAddTests
    {
        [Fact]
        public void ValidEmployee_AddIsCalled_ReturnValidEmployeeViewModel()
        {
            // Arrange
            // Criação do dto com dados aleatórios
            var addEmploymentInputModel = new Fixture().Create<AddEmployeeInputModel>();
            addEmploymentInputModel.BirthDate = DateTime.Today.AddYears(-29);

            // Criação de mock para passar como dependência
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var result = employeeService.Add(addEmploymentInputModel);

            // Assert
            // Assert.Equal(addEmploymentInputModel.Role, result.Role);
            // Assert.Equal(addEmploymentInputModel.FullName, result.FullName);
            // Assert.Equal(addEmploymentInputModel.Document, result.Document);
            // Assert.Equal(addEmploymentInputModel.BirthDate, result.BirthDate);
            // Assert.Equal(addEmploymentInputModel.RoleLevel, result.RoleLevel);
            // Assert.Equal(addEmploymentInputModel.Role, result.Role);
            result.FullName.ShouldBe(addEmploymentInputModel.FullName);
            result.Document.ShouldBe(addEmploymentInputModel.Document);
            result.BirthDate.ShouldBe(addEmploymentInputModel.BirthDate);
            result.RoleLevel.ShouldBe(addEmploymentInputModel.RoleLevel);
            result.Role.ShouldBe(addEmploymentInputModel.Role);

            employeeRepositoryMock.Verify(er => er.Add(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public void InvalidBirthDateForEmployee_AddIsCalled_ThrowAnInvalidBirthDateException()
        {
            // Arrange
            var addEmployeeInputModel = new Fixture().Create<AddEmployeeInputModel>();
            addEmployeeInputModel.BirthDate = DateTime.Today.AddDays(1);

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act + Assert
            var exception = Assert.Throws<BirthDateCannotBeInTheFutureException>(() =>
                employeeService.Add(addEmployeeInputModel));

            Assert.Equal("Birth date cannot be in the future.", exception.Message);

            Should.Throw<BirthDateCannotBeInTheFutureException>(() =>
                employeeService.Add(addEmployeeInputModel))
                .Message.ShouldBe("Birth date cannot be in the future.");
        }
    }
}
