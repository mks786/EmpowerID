global using Confluent.Kafka;
global using EmpowerID.Core.CQRS.CommandHandling;
global using EmpowerID.Core.CQRS.QueryHandling;
global using EmpowerID.Core.Domain;
global using EmpowerID.Core.EventBus;
global using EmpowerID.Core.Infrastructure.CQRS;
global using EmpowerID.Core.Infrastructure.EventBus;
global using EmpowerID.Core.Infrastructure.Http;
global using EmpowerID.Core.Infrastructure.Identity;
global using EmpowerID.Core.Infrastructure.Integration;
global using EmpowerID.Core.Infrastructure.Kafka.Consumer;
global using EmpowerID.Core.Infrastructure.Kafka.Serialization;
global using EmpowerID.Core.Infrastructure.Kafka.Workers;
global using EmpowerID.Core.Infrastructure.Outbox.Workers;
global using EmpowerID.Core.Infrastructure.WebApi;
global using EmpowerID.Core.Infrastructure.Workers;
global using EmpowerID.Core.Persistence;
global using EmpowerID.Core.Testing;
global using IdentityModel.Client;
global using JasperFx.Core.Reflection;
global using Marten;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using NSubstitute;
global using Polly;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Expressions;
global using System.Net.Http.Headers;
global using System.Net.Mime;
global using System.Text;
global using Weasel.Core;
global using Marten.Linq;