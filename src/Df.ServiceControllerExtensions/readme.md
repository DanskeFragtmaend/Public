# General extension methods for the ServiceCollection class





# <span style="color:lightblue">Methods</span>


## <span style="color:lightblue">AddConfiguration</span>
Adds configuration of type T to the service collection and returns the object.
Convenient when you want a configuration without the IOptions wrapper.

> **Example**
> 
> `services.AddConfiguration<QueueSettings>(configuration);`  
> where `configuration` is `IConfiguration`.  
> This will add a singleton instance of `QueueSettings` to `services`.
> 
> If you need the `QueueSettings` right away, `AddConfiguration` returns the instance:  
> `var myQueueSettings = services.AddConfiguration<QueueSettings>(configuration);`








# <span style="color:pink">NuGet package</span>
https://www.nuget.org/packages/Df.ServiceControllerExtensions/
