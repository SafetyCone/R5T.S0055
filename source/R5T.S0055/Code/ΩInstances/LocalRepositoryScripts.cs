using System;


namespace R5T.S0055
{
	public class LocalRepositoryScripts : ILocalRepositoryScripts
	{
		#region Infrastructure

	    public static ILocalRepositoryScripts Instance { get; } = new LocalRepositoryScripts();

	    private LocalRepositoryScripts()
	    {
        }

	    #endregion
	}
}