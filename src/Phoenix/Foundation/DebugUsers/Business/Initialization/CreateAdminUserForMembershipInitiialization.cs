using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging.Compatibility;
using System.Configuration.Provider;
using System.Web.Security;

namespace DebugUsers.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CreateAdminUserForMembershipInitiialization : IInitializableModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CreateAdminUserForMembershipInitiialization));

        public void Initialize(InitializationEngine context)
        {
#if DEBUG
            AddUser("Admin", "Grover68!", new[] { "WebAdmins", "WebEditors" });
#endif
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private void AddUser(string username, string password, string[] roles)
        {
            var mu = Membership.GetUser(username);
            
            if (mu == null)
            {
                Membership.CreateUser(username, password, username + "@site.com");
            }

            var existingRoles = Roles.GetRolesForUser(username);
            if(existingRoles.Length > 0)
            {
                Roles.RemoveUserFromRoles(username, existingRoles);
            }
            
            if(roles.Length > 0)
            {
                Roles.AddUserToRoles(username, roles);
            }
        }
    }
}