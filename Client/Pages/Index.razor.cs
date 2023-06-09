using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorBasic.Pages;

partial class Index
{
    private List<Resource>? allResources;
    private string? filter;
    private List<Resource>? resources;
    private string? selectedResourcePrefix;
    private string? selectedResourceName;

    protected override async Task OnInitializedAsync()
    {
        allResources = await http.GetFromJsonAsync<List<Resource>>($"/data/resources.json");
    }

    private Task HandleInput(ChangeEventArgs e)
    {
        filter = e.Value?.ToString();
        if (filter?.Length > 0)
        {
            if (allResources != null) resources = allResources.Where(r => r.Name.Contains(filter)).ToList();
        }
        else
        {
            resources = null;
            selectedResourceName = selectedResourcePrefix = null;
        }

        return Task.CompletedTask;
    }

    private void SelectResource(string resourcePrefix)
    {
        if (allResources != null) selectedResourcePrefix = allResources.FirstOrDefault(r => r.Name.Contains(resourcePrefix))?.Prefix;
    }
}

internal class Resource
{
    public string Category { get; set; }
    public string Name { get; set; }

    public string NameSpace { get; set; }
    public string Prefix { get; set; }
}