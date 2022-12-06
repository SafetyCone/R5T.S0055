using System;
using System.Threading.Tasks;


namespace R5T.S0055
{
    class Program
    {
        static async Task Main()
        {
            //await LocalRepositoryScripts.Instance.CreateConsoleRepository();
            await LocalRepositoryScripts.Instance.CreateWebStaticRazorComponents();
        }
    }
}