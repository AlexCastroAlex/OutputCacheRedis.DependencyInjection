# OutputCaching.Sample

As you all know , Microsoft released with ASP .NET Core 7.0 a new middleware named Output caching middleware.

This middlewares works like a charm till you work in a distributed environement and is also limited in storage as it is working with in memory system.

When you use the Microsoft middleware , you use : 

```csharp
builder.Services.AddOutputCache();
........
app.UseOutputCache();
```

And in your code for exemple : 
```csharp
 group.MapGet("/", async (IProductService service) =>
            {
                await Task.Delay(1000);
                return TypedResults.Ok(service.GetProducts());
            })
            .CacheOutput(c=> 
            {
                c.Tag("Product");
            });
```

the only thing you will have to change if you want to use Redis cache instead of in memory cache is : 

```csharp
builder.Services.AddOutputCache();
```
replaced by :
```csharp
builder.Services.AddRedisOutputCache("localhost:6379,password=mylocalredispassword");
```
You only have to put **in parameter you Redis cache connection string** and continue using caching like before when using in memory cache.

Feel free to ask for improvements or make PR's to propose some :)

