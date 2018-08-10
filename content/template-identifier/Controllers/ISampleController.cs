using Microsoft.AspNetCore.Mvc;

namespace template_identifier.Controllers
{
    /// <summary>
    /// TODO: Implement https://github.com/xuzhg/OData.OpenAPI
    /// A project to convert an Edm (Entity Data Model) to OpenApi 3.0. Instead of writing this controller manually
    /// </summary>
    public interface ISampleController
    {
        IActionResult Get();
        IActionResult Get(int key);

    }
}
