using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.S0055
{
	[FunctionalityMarker]
	public partial interface ILocalRepositoryScripts : IFunctionalityMarker
	{
        public async Task CreateWebStaticRazorComponents()
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
            var isPrivate = true;
            var repositoriesDirectoryPath =
                //DirectoryPaths.Instance.TemporaryRepositoryParent
                @"C:\Code\DEV\Git\GitHub\SafetyCone"
                ;


            /// Run.
            var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
                libraryContext,
                isPrivate,
                repositoriesDirectoryPath);

            //await Instances.FileSystemOperator.ClearDirectory(
            //    repositoryContext.LocalDirectoryPath);

            var repositoryResult = await Instances.LocalRepositoryOperations.Create_WebStaticRazorComponents(
                libraryContext,
                repositoryContext);

            Instances.VisualStudioOperator.OpenSolutionFile(
                repositoryResult.SolutionContext.SolutionFilePath);
        }

        public async Task CreateConsoleRepository()
		{
			/// Inputs.
			var libraryContext =
				Instances.LibraryContexts.Example
				;
            var isPrivate = true;
			var repositoriesDirectoryPath = DirectoryPaths.Instance.TemporaryRepositoryParent;


			/// Run.
			var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
				libraryContext,
				isPrivate,
				repositoriesDirectoryPath);

            await Instances.FileSystemOperator.ClearDirectory(
				repositoryContext.LocalDirectoryPath);

			var repositoryResult = await Instances.LocalRepositoryOperations.Create_Console(
				libraryContext,
				repositoryContext);

            Instances.VisualStudioOperator.OpenSolutionFile(
                repositoryResult.SolutionContext.SolutionFilePath);
        }
	}
}