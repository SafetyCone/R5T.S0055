using System;
using System.Threading.Tasks;

using R5T.F0047;
using R5T.F0084;
using R5T.F0087;
using R5T.F0089;
using R5T.F0090;
using R5T.T0132;


namespace R5T.S0055
{
	[FunctionalityMarker]
	public partial interface ILocalRepositoryScripts : IFunctionalityMarker
	{
        public async Task New_WebStaticRazorComponents()
        {
            /// Inputs.
            var libraryContext =
                //Instances.LibraryContexts.Example
                new T0153.LibraryContext
                {
                    LibraryName = "R5T.E0065",
                    LibraryDescription = "An experimental repository for testing two-stage repository creation/repository population."
                }
                ;
            var ownerName = GitHubOwnerNames.Instance.SafetyCone;
            var isPrivate = true;
            var repositoriesDirectoryPath =
                //DirectoryPaths.Instance.TemporaryRepositoryParent
                @"C:\Code\DEV\Git\GitHub\SafetyCone"
                ;


            /// Run.
            var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
                libraryContext,
                ownerName,
                isPrivate,
                repositoriesDirectoryPath);

            //await Instances.FileSystemOperator.ClearDirectory(
            //    repositoryContext.LocalDirectoryPath);

            var repositoryResult = await Instances.LocalRepositoryOperations.Create_WebStaticRazorComponents(
                libraryContext,
                repositoryContext);

            Instances.VisualStudioOperator.OpenSolutionFile(
                repositoryResult.SolutionResult.SolutionContext.SolutionFilePath);
        }

        public async Task New_ConsoleRepository()
		{
			/// Inputs.
			var libraryContext =
				Instances.LibraryContexts.Example
				;
            var ownerName = GitHubOwnerNames.Instance.SafetyCone;
            var isPrivate = true;
			var repositoriesDirectoryPath = DirectoryPaths.Instance.TemporaryRepositoryParent;


			/// Run.
			var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
				libraryContext,
                ownerName,
				isPrivate,
				repositoriesDirectoryPath);

            await Instances.FileSystemOperator.ClearDirectory(
				repositoryContext.LocalDirectoryPath);

            await F0035.LoggingOperator.Instance.InConsoleLoggerContext(
                nameof(New_ConsoleRepository),
                async logger =>
                {
                    //var repositoryResult = await Instances.RepositoryOperations.New_Console(
                    //    libraryContext,
                    //    repositoryContext,
                    //    logger);

                    // See if it's easy to do from scratch.
                    var repositoryResult = new SolutionRepositoryResult<SolutionResult>();

                    await RepositoryOperator.Instance.CreateRepository(
                        repositoryContext,
                        RepositorySetupOperations.Instance.SetupRepository_WithStandardActions(
                            async repositoryContext =>
                            {
                                repositoryResult.LocalRepositoryResult = new LocalRepositoryResult
                                {
                                    DirectoryPath = repositoryContext.LocalDirectoryPath,
                                };

                                var solutionContext = SolutionContextOperations.Instance.GetSolutionContext(
                                    libraryContext,
                                    repositoryContext.IsPrivate,
                                    repositoryContext.LocalDirectoryPath);

                                var solutionResult = new SolutionResult
                                {
                                    SolutionContext = solutionContext,
                                };

                                repositoryResult.SolutionResult = solutionResult;

                                await SolutionOperator.Instance.CreateSolution(
                                    solutionContext,
                                    SolutionSetupOperations.Instance.SetupSolution_WithStandardActions(
                                        solutionResult,
                                        async solutionContext =>
                                        {
                                            var projectContext = ProjectContextOperations.Instance.GetConsoleProjectContext(
                                                libraryContext,
                                                solutionContext.SolutionDirectoryPath);

                                            solutionResult.ProjectContext = projectContext;

                                            var bad_projectContext = ProjectContextOperator.Instance.GetProjectContext(
                                                projectContext.ProjectFilePath,
                                                projectContext.ProjectDescription);

                                            await ProjectOperator.Instance.CreateProject(
                                                bad_projectContext,
                                                ProjectSetupOperations.Instance.SetupProject_Console());
                                        }));
                            }));

                    Instances.VisualStudioOperator.OpenSolutionFile(
                        repositoryResult.SolutionResult.SolutionContext.SolutionFilePath);
                });
        }
	}
}