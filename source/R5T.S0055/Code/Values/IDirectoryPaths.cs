using System;

using R5T.T0131;


namespace R5T.S0055
{
	[ValuesMarker]
	public partial interface IDirectoryPaths : IValuesMarker
	{
        public string TemporaryRepositoryParent => @"C:\Temp\Repositories";
    }
}