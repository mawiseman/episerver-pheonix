using Feature.Robots.Models.Blocks;

namespace Feature.Robots.Models.Pages
{
    public interface IHasRobots
    {
        RobotsBlock Robots { get; set; }
    }
}