global using EmpowerID.Core.CQRS.CommandHandling;
global using EmpowerID.Core.CQRS.QueryHandling;
global using EmpowerID.Core.Domain;
global using EmpowerID.Core.Exceptions;
global using EmpowerID.Core.Infrastructure;
global using EmpowerID.Core.Infrastructure.Http;
global using EmpowerID.Core.Infrastructure.Identity;
global using EmpowerID.Core.Infrastructure.Integration;
global using EmpowerID.Core.Infrastructure.Marten;
global using EmpowerID.Core.Infrastructure.WebApi;
global using EmpowerID.Core.Persistence;
global using EmpowerID.UserManagement.Api.Application.GettingUserDetails;
global using EmpowerID.UserManagement.Api.Application.GettingUserDetailsWithToken;
global using EmpowerID.UserManagement.Api.Application.RegisteringUser;
global using EmpowerID.UserManagement.API.Controllers.Requests;
global using EmpowerID.UserManagement.Application.RegisteringUser;
global using EmpowerID.UserManagement.Domain;
global using EmpowerID.UserManagement.Domain.Commands;
global using EmpowerID.UserManagement.Domain.Events;
global using EmpowerID.UserManagement.Infrastructure.Projections;
global using Marten;
global using Marten.Events;
global using Marten.Events.Aggregation;
global using Marten.Events.Projections;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;
global using Newtonsoft.Json;
global using System.ComponentModel.DataAnnotations;