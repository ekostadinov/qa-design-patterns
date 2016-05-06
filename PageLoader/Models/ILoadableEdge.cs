using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace PageLoader.Models
{
    /// <summary>
    /// Edges connect one or more vertices. Can contain a value quantifying the weight of the edge.
    /// They don't explicitly exist which can be a problem for some graph algorithms. To simplify our lives, 
    /// we can make edges explicit at the cost of some additional memory.
    /// To traverse between pages, some action (algorithm) should be performed.
    /// </summary>
    interface ILoadableEdge : ILoadableComponent
    {
        IList<ILoadableEdge> RootNeighbours { get; }
        IList<ILoadableEdge> NodeNeighbours { get; }

    }
}
