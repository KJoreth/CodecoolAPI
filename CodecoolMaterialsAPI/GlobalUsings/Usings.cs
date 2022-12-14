global using CodecoolMaterialsAPI.Data.Context;
global using Microsoft.EntityFrameworkCore;
global using CodecoolMaterialsAPI.Data.DAL.Interfaces;
global using CodecoolMaterialsAPI.Data.DAL.Repositories;
global using CodecoolMaterialsAPI.Extensions;
global using CodecoolMaterialsAPI.Data.Exceptions;
global using CodecoolMaterialsAPI.Middlewares;
global using Microsoft.AspNetCore.Mvc;
global using AutoMapper;
global using CodecoolMaterialsAPI.Data.Entities;
global using CodecoolMaterialsAPI.DTOs.MaterialDTOs;
global using CodecoolMaterialsAPI.Services;
global using CodecoolMaterialsAPI.Services.Interfaces;
global using CodecoolMaterialsAPI.Data.UnitOfWork;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Logging;
global using System;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using CodecoolMaterialsAPI.DTOs.AuthorDTOs;
global using CodecoolMaterialsAPI.DTOs.Review;
global using CodecoolMaterialsAPI.DTOs.TypeDTOs;
global using CodecoolMaterialsAPI.DTOs.ReviewDTOs;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Serialization;
global using Microsoft.AspNetCore.JsonPatch;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using System.Security.Cryptography;
global using CodecoolMaterialsAPI.Security;
global using Microsoft.AspNetCore.Authorization;
global using CodecoolMaterialsAPI.DTOs.UserDTOs;
global using CodecoolMaterialsAPI.Data.Entities.Enums;
global using System.Net.Mime;
global using Microsoft.OpenApi.Models;
global using System.IO;
global using System.Reflection;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
