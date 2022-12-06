using System;


namespace R5T.S0055
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static T0153.Z001.ILibraryContexts LibraryContexts => T0153.Z001.LibraryContexts.Instance;
        public static F0090.ILocalRepositoryOperations LocalRepositoryOperations => F0090.LocalRepositoryOperations.Instance;
        public static F0089.IRepositoryContextOperations RepositoryContextOperations => F0089.RepositoryContextOperations.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
    }
}