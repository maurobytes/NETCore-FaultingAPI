# ASP.NETCore Resilience Sample

This sample demonstrates how to create a Faulting Web API utilizing .NET Core 3.0 and a throttling library.

The solution has two projects, the Faulting API itself and a Worker Service that calls the API to make repeated requests and logs the responses obtained.

You can follow along [this post I made at the Dev Community](https://dev.to/maurocon3ras/increasing-your-net-core-app-s-resiliency-building-a-faulting-api-2dll) to learn how I built this sample

## This sample was made with:

- [ASP.NET Core 3](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.0)
- [ASP.NET Core rate limiting middleware](https://github.com/stefanprodan/AspNetCoreRateLimit)