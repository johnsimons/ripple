using System.Collections.Generic;
using ripple.Nuget;

namespace ripple.Model
{
	public enum SearchLocation
	{
		Local,
		Remote
	}

	public interface IFeedService
	{
		IRemoteNuget NugetFor(Dependency dependency);

		IEnumerable<Dependency> DependenciesFor(Dependency dependency, UpdateMode mode, SearchLocation location = SearchLocation.Remote);
	}
}