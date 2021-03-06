// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RedisDemoNET5.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using RedisDemoNET5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using RedisDemoNET5.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\_Imports.razor"
using Microsoft.Extensions.Caching.Distributed;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\Pages\FetchData.razor"
using RedisDemoNET5.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\Pages\FetchData.razor"
using RedisDemoNET5.Extensions;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "D:\@Projects\RedisTest\AzureRedis\RedisDemoNET5\RedisDemoNET5\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;

    private string loadLocation = "";//From DB, Cache
    private string isCacheData = "";

    private async Task LoadForecast()
    {
        forecasts = null;//wipeout existing values;
        loadLocation = null;

        string recordKey = "WeatherForecast_" + DateTime.Now.ToString("yyyyMMdd-hhmm");

        forecasts = await cache.GetRecordAsync<WeatherForecast[]>(recordKey);

        if (forecasts is null)
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);

            loadLocation = $"Loaded from API at {DateTime.Now}";
            isCacheData = "";

            await cache.SetRecordAsync(recordKey, forecasts);
        }
        else
        {
            loadLocation = $"Loaded from the cache at {DateTime.Now}";
            isCacheData = "text-danger";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDistributedCache cache { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
