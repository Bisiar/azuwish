using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorBasic.Pages;

partial class Index
{
    
    List<Resource>? resources;
    string? selectedCustomerId;
    string? selectedCustomerName;
    string? filter;
 
    
    async Task HandleInput(ChangeEventArgs e)
    {
        filter = e.Value?.ToString();
        if (filter?.Length > 2)
        {
            //resources = await http.GetFromJsonAsync<List<Resource>>($"/data/companyfilter?filter={filter}");
        }
        else
        {
            resources = null;
            selectedCustomerName = selectedCustomerId = null;
        }
    }

    private Task SelectResource(object resourceId)
    {
        throw new NotImplementedException();
    }
}

internal class Resource
{
    public string Id { get; set; }
    public string Name { get; set; }
}