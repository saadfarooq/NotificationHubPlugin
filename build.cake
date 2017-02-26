#addin nuget:https://nuget.org/api/v2/?package=Cake.FileHelpers&version=1.0.3.2
#addin nuget:https://nuget.org/api/v2/?package=Cake.Xamarin&version=1.2.3

var TARGET = Argument ("target", Argument ("t", "Default"));
var version = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.99");

var libraries = new Dictionary<string, string> {
 	{ "./src/NotificationHub.sln", "Any" },
};

var samples = new Dictionary<string, string> {
	{ "./samples/ConnectivitySample.sln", "Win" },
};

var BuildAction = new Action<Dictionary<string, string>> (solutions =>
{

	foreach (var sln in solutions) 
    {

		// If the platform is Any build regardless
		//  If the platform is Win and we are running on windows build
		//  If the platform is Mac and we are running on Mac, build
		if ((sln.Value == "Any")
				|| (sln.Value == "Win" && IsRunningOnWindows ())
				|| (sln.Value == "Mac" && IsRunningOnUnix ())) 
        {
			
			// Bit of a hack to use nuget3 to restore packages for project.json
			if (IsRunningOnWindows ()) 
            {
				
				Information ("RunningOn: {0}", "Windows");

				NuGetRestore (sln.Key, new NuGetRestoreSettings
                {
					ToolPath = "./tools/nuget3.exe"
				});

				// Windows Phone / Universal projects require not using the amd64 msbuild
				MSBuild (sln.Key, c => 
                { 
					c.Configuration = "Release";
					c.MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86;
				});
			} 
            else 
            {
                // Mac is easy ;)
				NuGetRestore (sln.Key);

				DotNetBuild (sln.Key, c => c.Configuration = "Release");
			}
		}
	}
});

Task("Libraries").Does(()=>
{
    BuildAction(libraries);
});

Task("Samples")
    .IsDependentOn("Libraries")
    .Does(()=>
{
});

Task ("NuGet")
	.IsDependentOn ("Samples")
	.Does (() =>
{
    if(!DirectoryExists("./Build/nuget/"))
        CreateDirectory("./Build/nuget");
        
	NuGetPack ("./nuget/Plugin.nuspec", new NuGetPackSettings { 
		Version = version,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = "./Build/nuget/",
		BasePath = "./",
		ToolPath = "./tools/nuget3.exe"
	});	
});

//Build the component, which build samples, nugets, and libraries
Task ("Default").IsDependentOn("NuGet");


Task ("Clean").Does (() => 
{
	CleanDirectories ("./Build/");
	CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
});

RunTarget (TARGET);
