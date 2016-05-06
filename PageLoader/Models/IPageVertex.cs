using OpenQA.Selenium;

namespace PageLoader.Models
{
    /// <summary>
    /// Vertex is a single node in the graph, often encapsulates some sort of information (e.g. Web pages contain HTML elements)
    /// </summary>
    interface IPageVertex
    {
        IWebDriver PageDriver { get; }
    }
}
