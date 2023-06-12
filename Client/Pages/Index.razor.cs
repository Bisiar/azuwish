using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorBasic.Pages;

partial class Index
{
    private List<Resource>? _allResources = new List<Resource>();
    private string? _filter;
    private List<Resource>? _resources = new List<Resource>();
	private Resource? _selectedResource;
    private string? _selectedResourcePrefix;

    private string _selectResourceName;
    //private string? _selectedResourceName;

    private string SelectedResourceName
    {
        get => _selectedResource?.Name ?? string.Empty;
        // set => _selectResourceName = value;
    }

    protected override async Task OnInitializedAsync()
    {
        _allResources = await http.GetFromJsonAsync<List<Resource>>($"/data/resources.json");
    }

    private void HandleInput(ChangeEventArgs e)
    {
        _filter = e.Value?.ToString();
        if (_filter?.Length > 0)
        {
            if (_allResources != null)
			{
 				_resources = _allResources.Where(r => r.Name.Contains(_filter)).ToList();
			}
        }
        else
        {
           // _resources = null;
           // _selectedResource = null;
        }

       // return Task.CompletedTask;
    }

    private void SelectResource(string query)
    {
        if (_allResources != null)
        {
            var foundResource = _allResources.Find(r => r.Name.Equals(query));
            if (foundResource != null)
            {
                _selectedResource = foundResource;
            }
            else
            {
                _resources = _allResources.FindAll(r => r.Name.Contains(query) || r.Prefix.Contains(query));
            }
            
       //     _resources = null;
            // selectedResourcePrefix = allResources.FirstOrDefault(r => r.Prefix.Contains(resourcePrefix))?.Prefix;
        }

        //_filter = query;
    }
}

internal class Resource
{

    public string Category { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }

    public string NameSpace { get; set; }
    public string Prefix { get; set; }
	public string Url { get; set; }

}